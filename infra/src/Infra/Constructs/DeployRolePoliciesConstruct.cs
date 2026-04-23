using Amazon.CDK.AWS.IAM;
using Amazon.CDK.AWS.S3;
using Constructs;

namespace Infra.Constructs;

public class DeployRolePoliciesConstruct : Construct
{
    public ManagedPolicy DeployPolicy { get; }
    
    public DeployRolePoliciesConstruct(
        Construct scope,
        string id,
        string accountId,
        DeployRolePoliciesConstructProps props)
        : base(scope, id)
    {
        // Deploy Policy
        DeployPolicy = new ManagedPolicy(this, "DigitalDevelopmentPlaybook-DeployPolicy", new ManagedPolicyProps
        {
            Description = "Policy for deployment role with permissions to manage CloudFormation stacks and related resources",
        });
        
        DeployPolicy.AddStatements(new PolicyStatement(new PolicyStatementProps
        {
            Effect = Effect.ALLOW,
            Actions = new[] { "sts:AssumeRole" },
            Resources = new[]
            {
                // CDK bootstrap roles (created by cdk bootstrap)
                $"arn:aws:iam::{accountId}:role/cdk-hnb659fds-deploy-role-{accountId}-eu-west-2",
                $"arn:aws:iam::{accountId}:role/cdk-hnb659fds-file-publishing-role-{accountId}-eu-west-2",
                $"arn:aws:iam::{accountId}:role/cdk-hnb659fds-lookup-role-{accountId}-eu-west-2"
            }
        }));
        
        DeployPolicy.AddStatements(new PolicyStatement(new PolicyStatementProps
        {
            Effect = Effect.ALLOW,
            Actions = new[]
            {
                "s3:PutObject",
                "s3:DeleteObject",
                "s3:GetObject",
                "s3:ListBucket"
            },
            Resources = new[]
            {
                props.Bucket.BucketArn,
                $"{props.Bucket.BucketArn}/*"
            }
        }));
    }
    
    public class DeployRolePoliciesConstructProps
    {
        public IBucket Bucket { get; init; }
    }
}