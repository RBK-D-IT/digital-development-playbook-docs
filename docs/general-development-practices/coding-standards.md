# Coding Standards

## Overview

To maintain consistency and readability across our codebase, we follow these coding standards for all projects. These standards apply to all programming languages used within the team (e.g., C#, Python, etc.).

---

## General Guidelines

1. **Consistency**:

    - Write consistent code across the team. Follow established patterns and avoid introducing conflicting styles.

2. **Indentation and Formatting**:

    - Use 2 spaces for indentation (unless the project or language specifies otherwise).
    - Ensure proper use of line breaks and spacing between code blocks for readability.

3. **Naming Conventions**:

    - Use descriptive variable and function names that clearly describe their purpose.
    - For example, `getUserData()` is more descriptive than `getData()`.

4. **Comments**:
    - Comment your code where necessary to explain the "why" behind complex logic.
    - Avoid obvious comments, such as:
      ```javascript
      // Add 1 to counter
      counter += 1;
      ```

---

## Commit Message Standards (Conventional Commits)

Use the Conventional Commits specification for commit messages where possible. This ensures that our commit history is structured, easy to understand, and helps with automating semantic versioning and changelog generation.

**Conventional Commits Format**

Each commit message should include a type, an optional scope, and a short description of the change. If applicable, the issue ticket reference should also be included. Optionally, you can also include a body and footer for more details.

```text
<type>[optional scope]: <short description> <(issue-ticket-reference)>

[optional body]

[optional footer]
```

**Commit Types**

- **feat**: A new feature for the user.
- **fix**: A bug fix.
- **docs**: Documentation changes (e.g., updating README files).
- **style**: Code style changes that do not affect functionality (e.g., formatting).
- **refactor**: Code changes that neither fix a bug nor add a feature.
- **perf**: Performance improvements.
- **test**: Adding or updating tests.
- **chore**: Miscellaneous changes (e.g., updating build tasks, package management).
- **build**: Changes that affect the build system or dependencies.
- **ci**: Changes to our CI/CD pipeline or configuration.

**Examples of Conventional Commit Messages**

- `feat(login): add remember me functionality (AB-123)`
- `fix(auth): correct user authentication flow (CD-456)`
- `docs(readme): update API documentation`
- `refactor(user-model): improve user data structure`

**Commit Message Guidelines**

1. **Commit Early and Often**:
    - Each commit should represent a small, logical change that can be independently reviewed.
2. **Atomic Commits**:
    - Keep commits focused. Avoid mixing different types of changes (e.g., don’t include both `feat` and `fix` in the same commit).
3. **Use Descriptive Commit Messages**:
    - Clearly describe what the change is and why it was made.
4. **Reference Issues and PRs**:
    - If applicable, reference the issue ticket reference in the commit message (e.g., `fix(auth): correct authentication (CD-456)`).