# Digital Development Playbook

The **Digital Development Playbook** is a guide for our development team outlining best practices, standards, and workflows to follow during the development lifecycle. It provides documentation for building, testing, and deploying digital solutions.

---

## Overview

This repository hosts a static documentation site (built with [Docsify](https://docsify.js.org/)).

The site is deployed as a static website using:

- Amazon S3 (storage)
- Amazon CloudFront (distribution, SSL, WAF)
- AWS Route53 (custom domain)

---

## Initial Deployment

The infrastructure for the site is deployed using AWS CDK.

### Global Services Requirement

Some components (CloudFront) rely on resources in the **global AWS region (`us-east-1`)**:

- The **ACM SSL certificate** must also exist in `us-east-1`

---

### Deployment Command

To deploy the site, run:

```bash
cdk deploy digital-api-portal \
  --profile digital-prod \
  --parameters CertificateArn=<CERTIFICATE_ARN>
```

Where:
- `<CERTIFICATE_ARN>` is the ARN of the ACM certificate (must be in `us-east-1`)

---

### Custom Domain

The site is exposed via:

`https://development-playbook.digital.kscc.uk`

This is configured via:

- CloudFront alternate domain name
- Route53 alias record pointing to the distribution

---

## Website Updates

When changes are applied to the website pages in the `docs` folder, a GitHub Actions workflow automatically runs which will sync these changes to the S3 bucket that stores the website files. This will update the website with the relevant changes.