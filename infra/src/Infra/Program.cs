using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;
using Infra.Stacks;

namespace Infra
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            _ = new InfraStack(app, "digital-development-playbook", new StackProps
            {
                Description = "Stack to deploy Cloudfront and S3 resources to host the Digital Development Playbook website.",
                Env = new Amazon.CDK.Environment
                {
                    Account = System.Environment.GetEnvironmentVariable("CDK_DEFAULT_ACCOUNT"),
                    Region = System.Environment.GetEnvironmentVariable("CDK_DEFAULT_REGION")
                }
            });
            app.Synth();
        }
    }
}
