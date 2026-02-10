# Naming Conventions

## Overview

This document outlines the **naming conventions** that our team follows across various aspects of development to ensure consistency, clarity, and maintainability. These guidelines apply to GitHub repositories, AWS resources, APIs, and other key components.

---

## 1. GitHub Repository Naming Conventions

All GitHub repositories must follow a consistent naming convention to improve organisation and clarity. The following rules apply to all GitHub repositories.

**Format**:

```
digital-[project-type]-[project-name]-[optional-context]
```

- `[project-type]`: The type of project (e.g., `api`, `app`, `web`, `cdk`, `lib`, `tool`, `template`).
- `[project-name]`: A descriptive name for the project.
- `[optional-context]`: (Optional) Further context if required to clarify the purpose of the repository.

**Project Types**

1. **API Projects:** `digital-api-[project-name]`
2. **Application Projects:** `digital-app-[project-name]`
3. **Web Projects:** `digital-web-[project-name]`
4. **CDK Projects:** `digital-cdk-[project-name]`
5. **Library Projects:** `digital-lib-[project-name]`
6. **Tool Projects:** `digital-tool-[project-name]`
7. **Template/Example Projects:** `digital-template-[project-type]-[context]`

**Examples of Each Project Type**

1. **API Projects:**

    - `digital-api-spatial-search`
    - `digital-api-middleman-waste`

2. **Application Projects:**

    - `digital-app-free-school-meals`
    - `digital-app-corporate-warnings`

3. **Web Projects:**

    - `digital-web-customer-platform-maps`
    - `digital-web-address-search`

4. **CDK Projects:**

    - `digital-cdk-api-deployment`
    - `digital-cdk-blazor-deployment`

5. **Library Projects:**

    - `digital-lib-authentication`
    - `digital-lib-logging`

6. **Tool Projects:**

    - `digital-tool-dtf-importer`
    - `digital-tool-code-generator`

7. **Template/Example Projects:**
    - `digital-template-api-enhanced`
    - `digital-template-app-crud-basic`

---

## 2. Git Branch and Commit Naming Conventions

Branch names should clearly indicate the type of work being done. They are structured to quickly convey the purpose of the branch and help organise tasks. While similar to conventional commit types, branch naming is broader and identifies a set of changes rather than individual updates. If applicable, the issue ticket reference should be prefixed to the branch name to ensure easy tracking between the code and the associated task or issue.

**Format**:

- `feature/`: For new features or enhancements. Examples: `feature/AB-123-add-login-page`, `feature/add-user-profile`
- `bugfix/`: For resolving bugs. Examples: `bugfix/AB-456-fix-header-alignment`, `bugfix/address-memory-leak`
- `hotfix/`: For urgent production fixes. Examples: `hotfix/critical-security-fix`, `hotfix/security-patch`
- `task/`: For all other tasks, including maintenance, refactoring, updates, and documentation. Examples: `task/AB-789-update-dependencies`, `task/refactor-auth-module`

By using these four prefixes, we ensure that branches are easy to understand and manage without overcomplicating the naming process.

**Commit Naming (Conventional Commits) Format**:

- For consistency, all commit messages should follow the Conventional Commits format.
- This structure helps to automate versioning, changelogs, and makes it easier to understand the purpose of each change.
- For more details on how to write proper commit messages, see the [Coding Standards](coding-standards.md#commit-message-standards-conventional-commits) page.

---

## 3. Pull Request Naming Conventions

To keep our workflow consistent and make it easier to link pull requests to work items in our issue tracking system (e.g., JIRA), please follow this naming convention for all pull requests when creating new features / bug fixes.

**Format**:

```
[JIRA-TICKET-ID] Short, descriptive summary
```

- `[JIRA-TICKET-ID]`: JIRA ticket number of the feature / bug fix.

**Examples**:

- `[AB-123] Add user authentication to login page`
- `[CD-456] Refactor calendar file upload`
- `[EF-789] Improve error handling in shared logger`
- `Add additional logging to payment processing` _(if no ticket number applies / given)_

**Promoting Between Branches**:

When raising Pull Requests to promote changes between long lived branches (e.g., from `develop` to `main`), it should be formatted as below:

**Format**:

```
Promote [base-branch] to [target-branch]
```

- `[base-branch]`: The branch where the changes are coming from.
- `[target-branch]`: The branch where the changes are being merged into.

**Note for Promoting to `main`**

When promoting to the main branch, prefix the PR with `Release:` to indicate they are changes being pushed into the production environment.

**Examples**:

- `Promote develop to test` (Only if the version control process dictates a requirement for multiple long lived branches)
- `Release: Promote develop to main` (Normal convention)

---

## 4. AWS Resource Naming Conventions

Consistent naming in AWS resources helps to quickly identify the purpose and environment of resources. The following conventions apply to common AWS services such as IAM roles, Lambda functions, and S3 buckets.

**General Guidelines**:

The following conventions apply unless there are explicit guidelines for resource types:

- Use lowercase letters, numbers, and hyphens (`-`) to separate words.
- Include the service type in the name (e.g., `lambda`, `s3`, `iam`).
- Keep names short but descriptive.

**Parameter Store**

Parameters are stored using a group/path convention, as follows:

**Format**:

`/[parameter-group]/[parameter-path]`

- `/[parameter-group]`: The group the parameter belongs to (either application specific, e.g., `digital-api-waste-notifications`, or global e.g., `system`, `application`).
- `[parameter-path]`: The path of the parameter (e.g., `tagging/common/global`, `domain/digital-public`, `s3/file-path`).

**Examples**:

`/system/domain/digital-public`
`/digital-api-waste-notifications/storage/s3-bucket-path`

### Secrets Manager

Similar to the parameter store, secrets are stored in a similar convention:

**Format**:

`/[secret-group]/[secret-path]`

- `/[secret-group]`: The group the secret belongs to (e.g., `digital-api-waste-notifications`).
- `[secret-path]`: The path of the secret (e.g., `authorisation/api-key`).

**Examples**:

`/digital-api-waste-notifications/authorisation/api-key`

### S3 Buckets

To ensure consistency and clarity across our S3 usage, the following naming convention should be used when creating new S3 buckets. This aligns with our general naming conventions and follows a similar structure to how we name Parameter Store entries.

**Format**:

`[service|team]-[type]-[purpose]`

- `[service|team]`: The name of the application, API or business/team area (e.g., `api-waste-notifications` or `rbk-housing`).
- `[type]`: Describes what type of storage the bucket is used for (`data`, `assets`, `logs`, `exports`, `imports`, `archive`, etc.).
- `[purpose]`: Optional - What is being stored in the bucket (e.g., `waste-calendars`, `site-photos`).

**Examples**:

`waste-data-collection-calendars`
`rbk-parking-data-car-park-photos`
`s3-file-transfer-logs`

### IAM Roles and Policies

IAM roles and policies must follow a consistent naming convention to improve clarity and maintainability. The format for IAM roles and policies is as follows:

**Format**:

`Digital-[purpose][Role|RolePolicy]`

- `Digital-`: All IAM roles and policies start with `Digital-`.
- `[purpose]`: A descriptive term for the function of the role (e.g., `APILambdaDeployment`, `S3BackupManagement`).
- `[Role | RolePolicy]`: Ends with either `Role` or `RolePolicy` depending on whether it's a role or a policy.

**Examples**:

- **IAM Role**: `Digital-APILambdaDeploymentRole`
- **IAM Role Policy**: `Digital-APILambdaDeploymentRolePolicy`

### Lambda Functions

Lambda function names follow a consistent pattern based on the project name and function name, ensuring clarity in identifying what each function does and to which project it belongs.

**Format**:

`[ProjectName]-[FunctionName]`

- `[ProjectName]`: The name of the project, representing the overall service or functionality.
- `[FunctionName]`: The specific name of the Lambda function, based on its purpose or the functionality it provides.

**Examples**:

- `BaseAPI-GetSystemStatus`
- `WasteAPI-AddUser`

### API Gateway

The API Gateway is responsible for managing and routing API requests to Lambda functions. In the AWS infrastructure context, we focus on how the API Gateway is named and structured.

**Format**:

`[ProjectName]Api`

- `[ProjectName]`: The name of the project or service.

**Examples**:

- `WasteNotificationsApi`
- `WasteAPI-AddUser`

**Resource Path Naming**:

`/api/[resource-path]`

- `/api/`: Base path for all API resources.
- `[resource-path]`: Path based on the function and the resource being accessed.

**Examples**:

- **API Gateway Name**: `UserManagementApi`
- **API Gateway Resource Path**: `/api/create-user`, `/api/orders/get-order`

**API Gateway Stage Names**:

The stage name is based on the environment (e.g., `dev`, `test`, `prod`).

**Examples**:

- **Stage Names**: `development`, `production`

---

## 5. API Design Naming Conventions

In this section, we focus on how to design and structure API endpoints, independent of the AWS infrastructure. This covers how APIs should be named and accessed from a development perspective.

**General Guidelines**:

- Use nouns to represent resources (e.g., `users`, `orders`).
- Use HTTP methods (GET, POST, PUT, DELETE) to indicate the action being performed.
- Use lowercase letters and hyphens (`-`) in URLs.
- Keep URLs short and descriptive.

**URL Structure**:

```
`/api/[resource-name]/[resource-id]
```

- `[resource-name]`: The resource being accessed (e.g., `users`, `orders`).
- `[resource-id]`: The unique identifier for individual resources (when applicable).

**Examples**:

- **Get all users**: `GET /api/users`
- **Get a single user**: `GET /api/users/[userId]`
- **Create a new user**: `POST /api/users`
- **Update a user**: `PUT /api/users/[userId]`
- **Delete a user**: `DELETE /api/users/[userId]`