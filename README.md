# SalesApp

### Applying the concepts of [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

This is a sample project, created with Angular 8, ASP.NET Core 3 and MS MSQL following the principles of Clean Architecture.

## Main Functionalities
* Ability to post sales date, which comes in the following format
  - "Article Number": Alphanumeric - up to 32 characters
  - Sales Price: Numerical value in EUR
* Ability to request the following data / information from the API
  - Number of sold articles per day
  - Total revenue per day
  - Statistics: Revenue grouped by articles (TODO: calculation should be within the DB, not in business logic!)
  
## Further Functionalities
* ID Solution + JWT Auth (already implemented)

## TODOS
 - CI / CD Azure Devops
 - Statistics: Revenue grouped by articles (TODO: calculation should be within the DB, not in business logic!
 - Dockerfile for Tests

## Technologies
* .NET Core 3.1
* ASP .NET Core 3.1
* Entity Framework Core 3.1
* Angular 8
* Docker & Docker-Compose
* MS SQL

## Getting Started

1. Install the latest [.NET Core SDK](https://dotnet.microsoft.com/download)
2. (optional, if MS SQL is not installed) Install the latest [Docker Engine](https://www.docker.com/get-started)
3. (optional, if MS SQL is not installed) Run `docker-compose up -d` to spin up the MS SQL Container.
5.  run `dotnet run` to launch the project. Angular-Url: `https://localhost:5001/`. Swagger-Url: `https://localhost:5001/api`

WIP: Dockerfile and docker-compose service.
## Architecture Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.


### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.


### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### WebUI

This layer is a single page application based on Angular 8 and ASP.NET Core 3. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.

## Notes

### Database Migrations

To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

- `--project src/Infrastructure` (optional if in this folder)
- `--startup-project src/WebUI`
- `--output-dir Persistence/Migrations`

For example, to add a new migration from the root folder:

 `dotnet ef migrations add "SampleMigration" --project src\Infrastructure --startup-project src\WebUI`

## License

This project is licensed with the [MIT license](LICENSE).
Solution Template based on [CleanArchitecture](https://github.com/jasontaylordev/CleanArchitecture).

Special thanks to [Uncle Bob (Robert C. Martin)](https://blog.cleancoder.com/) ❤️ 