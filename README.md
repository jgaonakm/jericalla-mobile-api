# Jericalla Mobile

This sample API showcases the advantages of using Zuplo on a modular and extensible RESTful API representative of a telecommunications carrier's digital services called Jericalla Mobile.

It's divided in two repositories; here, we have the source code of the APIs, and [this is the repository](https://github.com/jgaonakm/jericalla-mobile-api-mgr) with the Zuplo Configuration.

## API

The API simulates core capabilities offered by mobile network operators to their customers, devices, enterprise clients, and integration partners. It demonstrates how such services could be organized across multiple domains including customer management, network operations, and enterprise partnerships.

![Diagram](https://static-assets.us-lax-1.linodeobjects.com/APIs.png)

### Accounts

This domain handles core customer operations, including profile management, contact information, and account activity. Customers can retrieve their personal details, contact support, or query usage history for voice, data, and SMS services. The model simulates interactions like viewing account status, usage metrics, or updating personal contact data, making it ideal for consumer self-service portals and CRM integrations.

### Network

This area exposes APIs related to SIM card lifecycle, signal coverage, device provisioning, and roaming control. Users or support systems can activate or deactivate SIMs, register new devices, retrieve estimated signal strength by location, and toggle roaming settings. It mirrors real-world interactions such as onboarding a new handset, troubleshooting weak signal reports, or managing international roaming preferences.

### Enterprise

This domain supports B2B operations by enabling partners—such as enterprise clients or virtual network operators—to manage their accounts, service agreements, and bulk provisioning needs. Partners can register through the API, provision batches of SIMs, query service contracts, and monitor enterprise-level account usage. This is especially useful in scenarios involving large corporate clients, resellers, or IoT deployments where centralized control and automation are key.

**Next >** [Run the API](run.md)
