# Deployment Process

## Overview

This document outlines the process for deploying builds across **Development, Test, and Production environments** using **GitHub Actions**, **AWS CDK**, and **AWS CloudFormation**. Our deployment strategy ensures consistency, automation, and reliability while incorporating validation and rollback mechanisms.

### Deployment Workflow

- **Development (`main` branch merges)**
    - Automatically deployed to **Development** upon merge to `main`.
- **Test (manual trigger)**
    - Manually deployed to **Test** upon promotion of build artifact.
- **Production (manual trigger)**
    - Manually deployed to **Production** upon promotion of test approved build artifact.

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
    - A PR is merged into `main`.
- **Steps**:
    - The pipeline builds, tests, and validates the code.
    - A build artifact is created and uploaded to the development environment.
    - AWS CDK provisions or updates infrastructure.
    - Health checks and E2E tests verify core functionality.
- **Who is involved?**
    - Developers trigger and monitor deployments.

---

2. **Test Environment**

- **Trigger**:
    - Manual promotion of a build artifact.
- **Steps**:
    - The pipeline promotes a selected build artifact from the development environment.
    - AWS CDK provisions the test environment.
    - E2E tests and smoke tests run.
    - UAT carried out to test end to end workflow.
- **Who is involved?**
    - Developers ensure smooth deployment.
    - Testers validate functionality in the Test environment.
    - Stakeholders may review key features.

---

3. **Production Environment**

- **Trigger**:
    - Manual promotion of a test approved build artifact.
- **Steps**:
    - The pipeline promotes a selected test approved build artifact from the test environment.
    - AWS CDK provisions the production environment.
    - Health check and tests run.
    - Smoke tests confirm a successful deployment.
    - Monitoring tools like AWS CloudWatch track performance.
- **Who is involved?**
    - Developers oversee deployments and monitor performance.
    - Stakeholders validate post-deployment success.

---

## Rollback Strategy

### Automatic Rollback with Build Artifacts

- If a production deployment fails, the GitHub Actions workflow immediately rolls back and deploys the previous production build.

### Manual Intervention

- In severe incidents, developers can initiate a manual rollback via GitHub Actions.

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

- **Automated Tests**: Automatically run tests after each deployment to validate that critical functionality is working.
- **Monitoring Tools**: Use AWS CloudWatch or similar tools to monitor the health and performance of the application post-deployment.
- **Alerts**: Set up automatic alerts for any failures or performance degradations in the production environment.

---

## Tools and Technologies

- **GitHub Actions**: Used for automating the deployment process across environments.
- **AWS CDK**: Manages infrastructure as code for all environments (development, test, production).
- **AWS CloudFormation**: Used by AWS CDK to deploy and manage resources.
- **AWS IAM**: Manages access and roles for deployment to different environments.
- **Monitoring Tools**: AWS CloudWatch for performance monitoring and alerting.