using System.Collections.Generic;
using Amazon.CDK.AWS.IAM;
using Constructs;

namespace Infra.Constructs;

public class DeployRoleConstruct : Construct
{
    public Role Role { get; }
    
    public DeployRoleConstruct(
        Construct scope,
        string id,
        DeployRoleConstructProps props
    ) : base(scope, id)
    {
        // GitHub OIDC principal with repo restriction
        var githubOidcPrincipal = new OpenIdConnectPrincipal(props.OidcProvider, new Dictionary<string, object>
        {
            ["StringLike"] = new Dictionary<string, object>
            {
                ["token.actions.githubusercontent.com:aud"] = "sts.amazonaws.com",
                ["token.actions.githubusercontent.com:sub"] = "repo:RBK-D-IT/*"
            }
        });
        
        Role = new Role(this, "DigitalDevelopmentPlaybook-DeployRole", new RoleProps
        {
            RoleName = "DigitalDevelopmentPlaybook-DeployRole",
            AssumedBy = githubOidcPrincipal,
            ManagedPolicies = new[]
            {
                props.Policy
            }
        });
    }
    
    public class DeployRoleConstructProps
    {
        public IOpenIdConnectProvider OidcProvider { get; set; }
        public ManagedPolicy Policy { get; set; }
    }
}