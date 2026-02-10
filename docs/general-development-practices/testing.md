# Testing

## Overview

Testing is essential to ensure the quality, stability, and maintainability of our codebase. This document outlines the best practices for writing and maintaining tests, covering unit tests, integration tests, and end-to-end (E2E) tests. The goal is to catch bugs early, ensure code correctness, and maintain a high level of confidence in our applications.

---

## Types of Tests

1. **Unit Tests**:

    - Focus on testing individual components, functions, or methods in isolation.
    - Ensure that each piece of code behaves as expected for a variety of inputs.
    - Aim for high coverage of critical functions to catch bugs early.

2. **Integration Tests**:

    - Verify that multiple components or services work together as expected.
    - Test interactions between modules or external services, such as databases, APIs, or other third-party systems.
    - Focus on ensuring that data flow and communication between components is correct.

3. **End-to-End (E2E) Tests**:
    - Simulate real-world user interactions with the system.
    - Test the entire system from the user interface to the backend, including all key workflows.
    - Use E2E tests to validate the user experience and critical business processes.

---

## Testing Guidelines

1. **Test-Driven Development (TDD)**

- Where appropriate, adopt **Test-Driven Development (TDD)**:
    1. Write a failing test that defines the behavior you want.
    2. Write the minimal amount of code necessary to pass the test.
    3. Refactor the code while ensuring all tests still pass.
- TDD helps drive code design, ensures tests are written for new features, and helps catch issues early in the development process.

2. **Test Coverage**

- Aim for at least 80% test coverage on critical code paths.
- Unit tests should cover edge cases, error handling, and boundary conditions.
- Integration tests should ensure correct data flow between components and services.
- End-to-End tests should cover key user flows and high-priority features.
- Maintain balance: while high test coverage is important, ensure that tests are meaningful and not just written for the sake of reaching a coverage number.

3. **Write Readable and Maintainable Tests**

- Tests should be easy to read and understand, with clear, descriptive names.
- Follow the Arrange-Act-Assert (AAA) pattern:

    - **Arrange**: Set up the test data and objects.
    - **Act**: Perform the action being tested.
    - **Assert**: Verify that the result matches the expected outcome.

  Example:

  ```csharp
  [Fact]
  public void ShouldReturnUserData_ForValidUserId()
  {
      // Arrange
      var userId = 1;
      var expected = new User { Id = 1, Name = "John Doe" };

      // Act
      var userData = GetUserData(userId);

      // Assert
      Assert.Equal(expected.Id, userData.Id);
      Assert.Equal(expected.Name, userData.Name);
  }
  ```

- Write small, focused tests that each cover a specific behaviour or scenario.
- Avoid complex logic within tests. Tests should be simple and test only one thing at a time.

4. **Use Mocks and Stubs Where Necessary**

- Mocks and stubs are useful for isolating the system under test, especially when interacting with external services (e.g., databases, APIs).
- For unit tests, mock or stub external dependencies to ensure that tests remain focused on the function or component being tested.
- Integration tests should minimize the use of mocks, focusing instead on testing the actual interaction between components.
- Avoid over-mocking, as it can make tests brittle and harder to understand.

5. **Automate Testing**

- All tests should run automatically as part of our Continuous Integration (CI) pipeline.
- Unit tests, integration tests, and end-to-end tests should be part of the CI process to ensure that code is fully tested before it reaches production.
- No code should be merged unless all tests pass in CI.

6. **Write Tests for Bugs and Edge Cases**

- When a bug is discovered, write a test case that reproduces the issue before fixing it. This ensures that the bug is covered by tests and helps prevent regressions.
- Cover edge cases in your tests, such as null inputs, invalid data, and boundary conditions, to make your code more robust.

---

## Tools and Frameworks

- Use appropriate testing frameworks and tools for the language or platform you are working with (e.g., xUnit).
- Choose mocking frameworks or tools that fit well with your project and make testing external dependencies easier (e.g., Moq).

---

## Test Structure and Organisation

1. **Organize tests by functionality**:

    - Place tests in a folder structure that mirrors the application's modules or components.
    - Group tests by type (unit, integration, end-to-end) or by the feature or component they cover.

2. **Test Naming Conventions**:

    - Test files should be named descriptively, using a format that clearly indicates what is being tested.
    - Inside test files, use descriptive names for test cases to communicate the behavior or scenario being tested.

   Example:

   ```text
   ShouldReturnUserData_ForValidUserId
   ```

---

## Continuous Integration (CI) and Test Automation

- All tests are run automatically in the CI pipeline for every pull request.
- Ensure that no PR is merged unless:
    - All tests pass successfully.
    - Adequate test coverage is maintained.
- Run tests in parallel where possible to optimise for speed, especially for end-to-end tests.

---

## Testing in Different Environments

- **Local Development**:

    - Run unit and integration tests locally before pushing your code.
    - Ensure that you are not introducing breaking changes by running all applicable tests before submitting a pull request.

- **Development / Test Environments**:

    - Use the development & test environments to test end-to-end flows and perform integration tests that require interaction with external services or databases.

- **Production Environment**:
    - Automated tests should run in the CI/CD pipeline as part of the deployment process, but production deployments should be thoroughly tested in test before being promoted.