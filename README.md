# CosmosApi

## Description
This is a minimal implementation of a project that allows to configure a MongoDB instance in Cosmos DB
and do some basic interaction with it over MongoDB.Driver API.

The aim is to aid getting started with MongoDB development in Cosmos DB.

The project uses .NET core and C# programming language to interact with MongoDB in Cosmos DB. 
There's an accompanied Bicep file to help configure a MongoDB instance in Azure cloud.
Please read further to find the Azure CLI commands
to create the database in Azure from the Bicep configuration file. 

The project also contains a small program implemented in C# language to add a product into "products" collection. 
Running the program the user can verify that they actually
can connect to the MongoDB in Cosmos DB and interact with it.

## Background
This project is strictly based on the following tutorials:

* [Quickstart: Azure Cosmos DB for MongoDB for .NET with the MongoDB driver](https://learn.microsoft.com/en-us/azure/cosmos-db/mongodb/quickstart-dotnet?tabs=azure-cli%2Cwindows)
* [Quickstart: Create an Azure Cosmos DB and a container using Bicep](https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/quickstart-template-bicep?tabs=CLI)
* [Quickstart: Create an Azure Cosmos DB for MongoDB vCore cluster by using a Bicep template](https://learn.microsoft.com/en-us/azure/cosmos-db/mongodb/vcore/quickstart-bicep?tabs=azure-cli)
* [Manage Azure Cosmos DB for MongoDB resources using Bicep](https://learn.microsoft.com/en-us/azure/cosmos-db/mongodb/manage-with-bicep#api-for-mongodb-with-autoscale-provisioned-throughput)
* [Generate Bicep parameter file](https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/bicep-cli#generate-params)
* [How to list Azure resources](https://learn.microsoft.com/en-us/cli/azure/group?view=azure-cli-latest#az-group-list)

## Prerequisites
* An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/en-us/free/)
* Azure command line interface. [Install Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)
* .NET 8.0 [Install .NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* Linux operating system (either a native Linux or a Linux subsystem in WSL2 on Windows)

## Instructions
### Create a resource group
First, create resource group in Azure to serve as the basement for your MongoDb in Cosmos DB:
```
az group create \
    --name exampleRG \
    --location eastus
```

### Verify the resource group
To be sure that you successfully created a resource group, type:
```
az group list
```
The group that you created should be listed now in the output.

### Create a MongoDB in Cosmos DB
Then, create a MongoDB instance in Cosmos DB with some collections, "products" and "customers":

```
az deployment group create --resource-group exampleRG --template-file 'main.bicep' --parameters main.parameters.json
```

### Find and update MongoDB connection string
To connect to MongoDB API, you need to find the connection string for the database that you just created.
List available connection strings for your database:
```
 az cosmosdb keys list --type connection-strings \
      --resource-group exampleRG \
      --name mongo-store-2024-03-19
```

Then, take the primary connection string (the first one on the list) and 
set it to the environment variable COSMOS_CONNECTION_STRING.

If you are using a native Linux or a Linux subsystem on Windows,
you can edit .bashrc file and addd the connection string as a global variable:

```
export COSMOS_CONNECTION_STRING="<your-connection-string-here>"
```

## Running the app
Run the application:
```
dotnet run
```
Every time the program is run, it adds a new Product object to database's *products* collection.
After the addition, it also lists all added product objects to the console.

### Clean up
To remove the resource grup from Azure (and your MongoDB within):
```
az group delete --name exampleRG
```
