# Deployment Process

## Overview

This document outlines the process for deploying code across **Development, Test, and Production environments** using **GitHub Actions**, **AWS CDK**, and **AWS CloudFormation**. Our deployment strategy ensures consistency, automation, and reliability while incorporating validation and rollback mechanisms.

### Deployment Workflow

- **Development (manual trigger)**
    - Can be deployed on-demand from local machines or triggered via GitHub Actions.
- **Test (`develop` branch merges)**
    - Automatically deployed to **Test** upon merge to `develop`.
- **Production (`main` branch merges)**
    - Automatically deployed to **Production** upon merge to `main`.

---

## AWS Deployment Workflow Overview

The deployment process follows an automated pipeline using **GitHub Actions**, **AWS CDK**, and **CloudFormation**:

### Deployment Architecture Steps

1. **Build and Test**: On a PR merge, GitHub Actions runs build and test processes.
2. **OIDC Authentication**: GitHub Actions authenticates with AWS using OpenID Connect (OIDC).
3. **IAM Role Assumption**: GitHub assumes an AWS IAM role to perform the deployment.
4. **CDK Synthesis**: AWS CDK generates CloudFormation templates.
5. **AWS Deployment**: CloudFormation provisions infrastructure and deploys the application.

This automation ensures zero manual intervention for deployments to Test and Production.

---

## Deployment Stages

1. **Development Environment**

- **Trigger**:
    - On-demand deployment via local machine.
    - On-demand deployment via GitHub Actions (if a developer raises a PR to `develop`).
- **Steps**:
    - The pipeline builds, tests, and validates the code.
    - AWS CDK provisions or updates infrastructure.
    - Smoke tests verify core functionality.
- **Who is involved?**
    - Developers trigger and monitor deployments.

---

2. **Test Environment**

- **Trigger**:
    - A merge into `develop` automatically triggers deployment.
- **Steps**:
    - GitHub Actions builds, tests, and deploys the application.
    - AWS CDK provisions the test environment.
    - Integration tests and smoke tests run.
- **Who is involved?**
    - Developers ensure smooth deployment.
    - Testers validate functionality in the Test environment.
    - Stakeholders may review key features.

---

3. **Production Environment**

- **Trigger**:
    - A merge into `main` automatically triggers deployment.
- **Steps**:
    - GitHub Actions builds, tests, and deploys the application.
    - AWS CDK provisions production infrastructure.
    - Smoke tests confirm a successful deployment.
    - Monitoring tools like AWS CloudWatch track performance.
- **Who is involved?**
    - Developers oversee deployments and monitor performance.
    - Stakeholders validate post-deployment success.

---

## Rollback Strategy

### Automatic Rollback with AWS CloudFormation

- If a CloudFormation deployment fails, AWS automatically rolls back to the previous stable state.

### Application Rollback

- If an issue is detected in production:
    - The pipeline can redeploy the last stable version.
    - Developers can manually rollback to a previous Git commit.

### Manual Intervention

- In severe incidents, developers can initiate a rollback via AWS CDK or GitHub Actions.

---

## Deployment Responsibilities

### Developers

- Manage CI/CD pipelines.
- Monitor deployments for issues.
- Fix bugs and rollback if necessary.

### Testing Team

- Validate deployments in Test environments.
- Report issues and verify fixes.

### Stakeholders

- Provide UAT feedback for Test environment deployments.
- Validate production features after deployment.

---

## Deployment Validation and Monitoring

For every deployment, the following validation and monitoring steps are performed:

- **Smoke Tests**: Automatically run smoke tests after each deployment to validate that critical functionality is working.
- **Monitoring Tools**: Use AWS CloudWatch or similar tools to monitor the health and performance of the application post-deployment.
- **Alerts**: Set up automatic alerts for any failures or performance degradations in the production environment.

---

## Tools and Technologies

- **GitHub Actions**: Used for automating the deployment process across environments.
- **AWS CDK**: Manages infrastructure as code for all environments (development, test, production).
- **AWS CloudFormation**: Used by AWS CDK to deploy and manage resources.
- **AWS IAM**: Manages access and roles for deployment to different environments.
- **Monitoring Tools**: AWS CloudWatch for performance monitoring and alerting.