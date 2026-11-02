# Learning Clean Architecture & CQRS

A learning project based on Essam Abdelnaby's course, built with ASP.NET Core and .NET 10.

## Technologies
- .NET 10
- Entity Framework Core
- SQLite
- MediatR
- FluentValidation

## Architecture
- Domain
- Application
- Infrastructure
- API

## Concepts Practiced
- Clean Architecture
- CQRS
- MediatR
- Validation Pipeline
- Global Exception Handling

## Run
```bash
dotnet restore CQRS-Demo.slnx
dotnet build CQRS-Demo.slnx
dotnet run --project src/API
```
