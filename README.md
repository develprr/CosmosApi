# CosmosApi
## Description
This isn example API to demonstrate how to use .NET core and C# programming language
to interact with MongoDB in Cosmos DB.

## Background
This project is strictly based on following tutorials:

* [Quickstart: Azure Cosmos DB for MongoDB for .NET with the MongoDB driver](https://learn.microsoft.com/en-us/azure/cosmos-db/mongodb/quickstart-dotnet?tabs=azure-cli%2Cwindows)
* [Quickstart: Create an Azure Cosmos DB and a container using Bicep](https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/quickstart-template-bicep?tabs=CLI)
* [Quickstart: Create an Azure Cosmos DB for MongoDB vCore cluster by using a Bicep template](https://learn.microsoft.com/en-us/azure/cosmos-db/mongodb/vcore/quickstart-bicep?tabs=azure-cli)
* [Manage Azure Cosmos DB for MongoDB resources using Bicep](https://learn.microsoft.com/en-us/azure/cosmos-db/mongodb/manage-with-bicep#api-for-mongodb-with-autoscale-provisioned-throughput)
* [Generate Bicep parameter file](https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/bicep-cli#generate-params)
## Prerequisites

* An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/en-us/free/)
* Azure command line interface. [Install Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)
* .NET 8.0 [Install .NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* Linux operating system (either a native Linux or a Linux subsystem in WSL2 on Windows)

## Installation

### Deploy a resource group
First, create resource group to serve as the basement for your MongoDb in Cosmos DB:
```
az group create \
    --name exampleRG \
    --location eastus
```
### Create a MongoDB in Cosmos DB
Then, create a MongoDB instance in Cosmos DB with some collections, "products" and "customers":

```
az deployment group create --resource-group exampleRG --template-file 'main.bicep' --parameters main
```