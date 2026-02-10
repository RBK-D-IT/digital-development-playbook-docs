# Code Review Process and Standards

## Overview

Code reviews are a critical part of our development workflow, ensuring code quality, consistency, and sharing of knowledge across the team. Every pull request (PR) must be reviewed and approved before being merged. The review process helps catch bugs, improve design, and ensure maintainability.

---

## Code Review Workflow

1. **Submit a Pull Request**:

    - After completing a feature or bug fix, submit a pull request (PR) targeting the `develop` branch.
    - Include the following in the PR description:
        - A clear summary of the changes made.
        - Issue ticket reference (if applicable).
        - Screenshots, logs, or any other supporting information when necessary (optional).

2. **Review the PR**:

    - At least one team member must review the PR before it can be merged.
    - The reviewer will:
        - **Check for Code Quality**: Ensure that the code is clean, well-structured, and follows the team's [coding standards](../general-development-practices/coding-standards.md).
        - **Test Coverage**: Confirm that the new code has appropriate unit tests, and ensure that existing tests pass.
        - **Functionality**: Verify that the feature works as expected by testing locally when applicable.
        - **Security**: Check for potential security vulnerabilities, especially when dealing with sensitive data (e.g., authentication, authorisation).
        - **Performance**: Look for possible performance optimizations, especially for high-impact areas like database queries or API calls.

3. **Address Feedback**:

    - If the reviewer requests changes, the author should update the code in the same branch and notify the reviewer once the changes are complete.
    - Keep the feedback loop fast by responding promptly and addressing issues as clearly as possible.

4. **Approval and Merge**:

    - Once the reviewer is satisfied, they will approve the PR.
    - Ensure all CI checks (tests, linters, etc.) have passed before merging.
    - Merge the PR into `develop`, and delete the feature branch to keep the repository clean.

5. **Continuous Integration (CI) Checks**:
    - Before merging, the PR must pass all automated CI checks, including:
        - Unit tests
        - Integration tests
        - Linting (e.g., ESLint, Pylint)
        - Any other configured tests (e.g., end-to-end tests)

---

## Code Review Guidelines

### For Reviewers

1. **Be Constructive**:

    - Provide clear, actionable feedback.
    - Use comments to suggest improvements rather than just point out problems.
    - Encourage learning by explaining why something should be done differently if necessary.

2. **Focus on the Code, Not the Person**:

    - Review the code objectively. Avoid criticizing the author personally.

3. **Be Timely**:

    - Aim to review PRs as soon as possible, ideally within 24 hours.
    - A delayed review can hold up the progress of a feature and affect the team's velocity.

4. **Test Locally**:

    - If the change is significant or affects a key part of the application, pull the branch locally and test the functionality yourself.

5. **Ensure Alignment with Team Standards**:
    - Verify that the code aligns with team conventions and coding standards, such as code formatting, naming conventions, and architectural patterns.

### For Authors

1. **Keep PRs Small and Focused**:

    - PRs should address a single issue or feature to make them easier to review. Avoid bundling multiple changes into one PR.

2. **Provide Context**:

    - Write clear PR descriptions. Assume the reviewer is not familiar with the full context of your changes.

3. **Be Open to Feedback**:

    - Code reviews are an opportunity to learn. Be receptive to suggestions and improvements.
    - Discuss and clarify feedback where necessary, but always keep the review process respectful and productive.

4. **Write Meaningful Commit Messages**:

    - Follow the [Conventional Commits](../general-development-practices/coding-standards.md#commit-message-standards-conventional-commits) specification to ensure your commit history is clean and informative.

5. **Ensure All Tests Pass**:
    - Run all applicable tests locally before pushing your branch to GitHub. Ensure that automated tests pass as well before requesting a review.

---

## Merge Strategy

- We use **squash and merge** for pull requests to keep the `develop` branch history clean and avoid clutter with numerous small commits.
- Ensure the final commit message after squashing follows the [Conventional Commits](../general-development-practices/coding-standards.md#commit-message-standards-conventional-commits) format.
- For promoting between `develop` and `main`, a merge commit is used.