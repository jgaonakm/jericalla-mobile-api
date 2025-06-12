# Run the API

We've stated already that the code is divided in three funcional domains. Each domain has it's own .NET WebAPI project in a separate directory, with a Dockerfile for creating the corresponding container image. This way you can run in any environment as standalone containers or with orchestration tools.

The APIs come with "seeded" dummy data to be ready to use. Feel free to fork the repository and add your own database if required.

## Deployment

Using Akamai Cloud, you can easily deploy the APIs on LKE by using AppPlatform. Using this path allows you to have a private image repository with Harbor and run the APIs as Knative Services, without requiring to provide other infrastructure than a your Kubernetes Cluster.

> Read more about the process in the [AppPlatform documentation](https://apl-docs.net/docs/akamai-app-platform/introduction). If needed, you can [create a Linode account](https://login.linode.com/signup?promo=docs05012025) to try this guide with a $100 credit.

If you prefer other options, there are multiple paths you can follow:

- Run all the APIs from the source code using `dotnet run`
- Generate local images and run them
- Create a Docker compose file
- Docker Swarm
- Kubernetes Cluster
- ...

In any case, the end goal is having the three APIs running and accessible through the internet, so they receive traffic from our Zuplo project.

## OAS

You can access the Open API Specification file, commonly known as swagger file, using the URL of each API and adding /swagger at the end

`https://[API URL]/swagger`

![OAS File](img/OAS.png)

You will use the specification files for the three APIs for the [Zuplo configuration prepared for this guide](https://github.com/jgaonakm/jericalla-mobile-api-mgr).

## Traffic Generation

To make it easier to test capabilities like logs and analytics, you can use the traffic generation console app.

Once you've completed the Zuplo configuration execute the application (using `dotnet run` or as a container) providing the base url deployment as an environment variable.

`export API_BASE_URL="https://[Gateway URL]/api/"`

The code selects randomly one of the endpoints from the list to make a call and print the response to the console. The traffic generated is reflected on the Zuplo console and externally if sending logs elsewhere.

**Next >** [Create Zuplo configuration](https://github.com/jgaonakm/jericalla-mobile-api-mgr).
