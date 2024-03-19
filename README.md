# CosmosApi
## Description
This isn example API to demonstrate how to use .NET core and C# programming language
to interact with MongoDB in Cosmos DB.

## Background
This project is strictly based on following tutorials:

* [Quickstart: Azure Cosmos DB for MongoDB for .NET with the MongoDB driver](https://learn.microsoft.com/en-us/azure/cosmos-db/mongodb/quickstart-dotnet?tabs=azure-cli%2Cwindows)
* [Quickstart: Create an Azure Cosmos DB and a container using Bicep](https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/quickstart-template-bicep?tabs=CLI)
* [Quickstart: Create an Azure Cosmos DB for MongoDB vCore cluster by using a Bicep template](https://learn.microsoft.com/en-us/azure/cosmos-db/mongodb/vcore/quickstart-bicep?tabs=azure-cli)
* [Manage Azure Cosmos DB for MongoDB resources using Bicep] (https://learn.microsoft.com/en-us/azure/cosmos-db/mongodb/manage-with-bicep#api-for-mongodb-with-autoscale-provisioned-throughput)

## Prerequisites

* An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/en-us/free/)
* Azure command line interface. [Install Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)
* .NET 8.0 [Install .NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* Linux operating system (either a native Linux or a Linux subsystem in WSL2 on Windows)

## Installation

### Create Mongo database
Create a Mongo database account in CosmosDB by running following commands:
```
az group create --name exampleRG --location eastus
az deployment group create --resource-group exampleRG --template-file main.bicep --parameters primaryRegion=useast secondaryRegion=uswest
```
### Validate the deployment
Make sure that the deploment was successful, list the created reasources:
```
az resource list --resource-group exampleRG
```

## Find the created account
You need the account name of the MongoDB account that you just created. To find it,
run the following command: 
```
az resource list --resource-group exampleRG | egrep "name"
```

## Find the connection string for the created MongoDB instance:
```
az cosmosdb keys list --type connection-strings --resource-group exampleRG --name <account-name>
```