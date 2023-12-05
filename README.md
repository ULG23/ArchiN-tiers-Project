# JeBalance

## Pour faire une mise à jour de la base avec EFCore il faut appliquer la commande 
$ dotnet ef database update\
Cependant il faut pour cela avoir la commande dotnet ef dans son environnement\
Sur mac M2 j'ai eu un peu de mal donc voici la commande qui permet d'utiliser dotnet ef dans la session courante :\
$ export PATH="$PATH:/Users/gauthiermiguet/.dotnet/tools"

## About this solution

This is a layered startup solution based on [Domain Driven Design (DDD)](https://docs.abp.io/en/abp/latest/Domain-Driven-Design) practises. All the fundamental ABP modules are already installed. 

### Pre-requirements

* [.NET 7.0+ SDK](https://dotnet.microsoft.com/download/dotnet)
* [Node v18 or 20](https://nodejs.org/en)

### Configurations

The solution comes with a default configuration that works out of the box. However, you may consider to change the following configuration before running your solution:

* Check the `ConnectionStrings` in `appsettings.json` files under the `JeBalance.Web` and `JeBalance.DbMigrator` projects and change it if you need.

### Before running the application

* Run `abp install-libs` command on your solution folder to install client-side package dependencies. This step is automatically done when you create a new solution with ABP CLI. However, you should run it yourself if you have first cloned this solution from your source control, or added a new client-side package dependency to your solution.
* Run `JeBalance.DbMigrator` to create the initial database. This should be done in the first run. It is also needed if a new database migration is added to the solution later.

### Solution structure

This is a layered monolith application that consists of the following applications:

* `JeBalance.DbMigrator`: A console application which applies the migrations and also seeds the initial data. It is useful on development as well as on production environment.
* `JeBalance.Web`: ASP.NET Core MVC / Razor Pages application that is the essential web application of the solution.

## Deploying the application

Deploying an ABP application is not different than deploying any .NET or ASP.NET Core application. However, there are some topics that you should care about when you are deploying your applications. You can check ABP's [Deployment documentation](https://docs.abp.io/en/abp/latest/Deployment/Index) before deploying your application.

### Additional resources

You can see the following resources to learn more about your solution and the ABP Framework:

* [Web Application Development Tutorial](https://docs.abp.io/en/abp/latest/Tutorials/Part-1)
* [Application Startup Template Structure](https://docs.abp.io/en/abp/latest/Startup-Templates/Application)
* [LeptonX Lite MVC UI](https://docs.abp.io/en/abp/latest/Themes/LeptonXLite/AspNetCore)
