# ACME Learning Center Platform

## Summary
ACME Learning Center Platform API Application, made with Microsoft C#, ASP.NET Core, Entity Framework Core and MySQL persistence. It also illustrates open-api documentation configuration and integration with Swagger UI.

## Features
- RESTful API
- OpenAPI Documentation
- Swagger UI
- ASP.NET Framework
- Entity Framework Core
- Audit Creation and Update Date
- Custom Route Naming Conventions
- Custom Object-Relational Mapping Naming Conventions.
- MySQL Database
- Domain-Driven Design

## Bounded Contexts
This version of ACME Learning Center Platform is divided into two bounded contexts: Profiles, and Publishing.

### Profiles Context

The Profiles Context is responsible for managing the profiles of the users. It includes the following features:

- Create a new profile.
- Get a profile by id.
- Get all profiles.

This context includes also an anti-corruption layer to communicate with the Publishing Context. The anti-corruption layer is responsible for managing the communication between the Profiles Context and the Publishing Context. It offers the following capabilities to other bounded contexts:
- Create a new Profile, returning ID of the created Profile on success.
- Get a Profile by Email, returning the associated Profile ID on success.

### Publishing Context

The Publishing Context is responsible for managing the publishing lifecycle of learning resources, like tutorials and their owned assets (reading content, images, videos). Its features include:

- Create a Category.
- Get a Category by id.
- Get All Categories.
- Create a Tutorial.
- Get a Tutorial by Id
- Get Tutorials by Category Id.
- Get All Tutorials.
- Add a Video Asset to an existing Tutorial.