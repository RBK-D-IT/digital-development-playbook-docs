using Amazon.CDK;
using Amazon.CDK.AWS.CertificateManager;
using Amazon.CDK.AWS.CloudFront;
using Amazon.CDK.AWS.CloudFront.Origins;
using Amazon.CDK.AWS.IAM;
using Amazon.CDK.AWS.Route53;
using Amazon.CDK.AWS.Route53.Targets;
using Amazon.CDK.AWS.S3;
using Constructs;
using Infra.Constructs;

namespace Infra.Stacks
{
    public class InfraStack : Stack
    {
        public InfraStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // Stack parameters
            string accountId = Aws.ACCOUNT_ID;
            string region = Aws.REGION;
                
            // Import the existing GitHub OIDC provider (created by bootstrap repo)
            var githubOidcProvider = OpenIdConnectProvider.FromOpenIdConnectProviderArn(
                this,
                "ImportedGitHubOidcProvider",
                $"arn:aws:iam::{accountId}:oidc-provider/token.actions.githubusercontent.com"
            );

            // -----------------------------
            // Parameter: Certificate ARN
            // -----------------------------
            var certificateArnParam = new Amazon.CDK.CfnParameter(this, "CertificateArn", new Amazon.CDK.CfnParameterProps
            {
                Type = "String",
                Description = "ARN of the ACM certificate (must be in us-east-1 for CloudFront)"
            });

            var certificateArn = certificateArnParam.ValueAsString;

            var certificate = Certificate.FromCertificateArn(
                this,
                "SiteCertificate",
                certificateArn
            );

            // -----------------------------
            // S3 Bucket (static site storage)
            // -----------------------------
            var siteBucket = new Bucket(this, "DocsSiteBucket", new BucketProps
            {
                BucketName = $"{accountId}-digital-development-playbook-docs-site",
                BlockPublicAccess = BlockPublicAccess.BLOCK_ALL,
                RemovalPolicy = RemovalPolicy.DESTROY,
                AutoDeleteObjects = true
            });
            
            // -----------------------------
            // Policy for S3 deploy role
            // -----------------------------
            var policies = new DeployRolePoliciesConstruct(this, "DeployRolePolicies", accountId, new DeployRolePoliciesConstruct.DeployRolePoliciesConstructProps
            {
                Bucket = siteBucket
            });
            
            // -----------------------------
            // S3 deploy role (used in GitHub Actions to update bucket contents)
            // -----------------------------
            var role = new DeployRoleConstruct(this, "DeployRole", new DeployRoleConstruct.DeployRoleConstructProps
            {
                OidcProvider = githubOidcProvider,
                Policy = policies.DeployPolicy
            });

            // -----------------------------
            // CloudFront Distribution
            // -----------------------------
            var distribution = new Distribution(this, "DocsSiteDistribution", new DistributionProps
            {
                DefaultBehavior = new BehaviorOptions
                {
                    Origin = S3BucketOrigin.WithOriginAccessControl(siteBucket),
                    ViewerProtocolPolicy = ViewerProtocolPolicy.REDIRECT_TO_HTTPS
                },

                DefaultRootObject = "index.html",

                // Custom domain
                DomainNames = new[] { "development-playbook.digital.kscc.uk" },
                Certificate = certificate,

                // Docsify routing fix
                ErrorResponses = new[]
                {
                    new ErrorResponse
                    {
                        HttpStatus = 404,
                        ResponseHttpStatus = 200,
                        ResponsePagePath = "/index.html",
                        Ttl = Duration.Seconds(0)
                    }
                }
            });

            // -----------------------------
            // Route53 - Custom Domain Mapping
            // -----------------------------
            var hostedZone = HostedZone.FromLookup(this, "HostedZone", new HostedZoneProviderProps
            {
                DomainName = "digital.kscc.uk"
            });

            new ARecord(this, "DevelopmentPlaybookAliasRecord", new ARecordProps
            {
                Zone = hostedZone,
                RecordName = "development-playbook",
                Target = RecordTarget.FromAlias(new CloudFrontTarget(distribution))
            });

            // -----------------------------
            // Outputs
            // -----------------------------
            new CfnOutput(this, "BucketName", new CfnOutputProps
            {
                Value = siteBucket.BucketName
            });

            new CfnOutput(this, "CloudFrontUrl", new CfnOutputProps
            {
                Value = $"https://{distribution.DomainName}"
            });

            new CfnOutput(this, "DeployRoleArn", new CfnOutputProps
            {
                Value = role.Role.RoleArn
            });
        }
    }
}
