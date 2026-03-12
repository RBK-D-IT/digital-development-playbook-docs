# Software Development Lifecycle

## Overview

The Software Development Lifecycle (SDLC) describes the structured process used to design, develop, test, and deploy software. It provides a consistent framework for delivering reliable and maintainable software while ensuring collaboration between developers, testers, and stakeholders.  
The lifecycle begins with defining requirements and continues through development, testing, deployment, and ongoing monitoring. The process is iterative, allowing new improvements and fixes to be delivered continuously.
---

## SDLC Stages

1. **Requirements & Planning**

This stage focuses on understanding what needs to be built or changed in the system.

- **Key Activities**:
    - Obtain requirements from the business
    - Define the scope of the work
    - Create sprint tickets and organise them into the backlog for the development team

Clear requirements help ensure that the development team understands the intended outcome before implementation begins.

2. **Design & Analysis**

During this stage, the development team determines how the requirements will be implemented within the system.

- **Key Activities**:
    - Reviewing existing system architecture
    - Designing new components or services
    - Assessing and risks or technical challenges

The goal is to establish a clear technical approach before development begins.

3. **Development**

In this stage, developers implement the required functionality within the codebase.

- **Key Activities**:
    - Creating feature branches
    - Writing application code
    - Implementing business logic
    - Writing tests
    - Running local builds and tests

Development is typically performed in a local development environment before code reviews are performed.

4. **Code Review**

Once development work is complete, the code is reviewed to ensure quality, maintainability, and adherence to coding standards.

- **Key Activities**:
    - Raising a pull request
    - Reviewing code changes
    - Providing feedback and improvements
    - Ensuring tests pass

Code reviews help maintain consistency and reduce the risk of defects entering the system.

5. **Testing & Validation**

Testing ensures that the implemented functionality behaves as expected and does not introduce regressions.

- **Key Activities**:
    - Running automated tests
    - Manual smoke tests
    - User Acceptance Testing (UAT)
    - Verifying requirements have been met

Issues identified during testing may require additional development before the change can proceed to release.

6. **Release & Deployment**

Once testing has been successfully completed, the software is prepared for release and deployment to the production environment.

- **Key Activities**:
    - Promoting the build to the production environment
    - Performing automated health checks
    - Confirming the system is operating correctly through manual smoke tests

Deployment makes the new functionality available to end users.

7. **Monitoring & Maintenance**

After deployment, the system is monitored to ensure reliability, performance, and stability.

- **Key Activities**:
  - Monitoring application logs
  - Detecting and responding to issues
  - Applying fixes or improvements

Insights gathered during this stage often lead to new requirements, continuing the lifecycle.