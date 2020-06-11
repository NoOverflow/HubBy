# HubBy
HUB Project for EPITECH 2024. 

HubBy is a website powered by Blazor ASP.net core where you can find all EPITECH Hub projects and activities,
managing these activities is made easy thanks to its REST API (detailed in this readme). (To test this API use the provided Postman runner)

All of this data is stored in a Mongo NoSQL database 

## What is the goal of this project 
I made this project so we can have a better view of EPITECH's hub activities and projects, but also to make it easy to see all of it
using a simple REST API (So anyone can make a webapp / mobile app / embedded display)

## How does it work ?
HubBy is powered by Blazor ASP.net core and all data is stored in a Mongo NoSQL database
The webapp and database are hosted on Azure thanks to Azure CosmosDB

## Testing
I included in the tests/ repository a postman configuration to automatically test the REST API.

## Deploying
Deploying is automatic thanks to Github Actions and Azure Pipelines when a push is made on the master branch.

## API Usage
Please refer to the wiki to learn more about it.
