# Blazor Shop Store

* <strike>Sample Blazor Web Assembly Client App</strike>

-----------------------

Creating an Shop Store on Net ecosystem using the latest Net 6 (C# 10) capabilities; this includes an web api and a client interface. The web api was made using the clean architecture guide by implementing CQRS and Mediator.

Web API
* Creating Commands, Queries, Validators and Responses for every Database Entity
* Managing errors flow
* Managing authorization and unauthorized, access resources based on role
* Validating the JWT Token
* Payments Gateway (Stripe)
* Adding Seed Data
* Using Middleware and Filters
* Setting CORS policy
* Using string constant resources
* creating services for identity core entities
* Creating Policies based on User Role (Web Api)
* Setting the AutoMapper, FluentValidation and Mediat at Application Layer

* Creating Commands for Entities
* Creating Queries
* Creating Handlers for Commands and Queries
* Creating Responses Models
* Creating Validators for Commands and Queries
@ Creating Behaviors (unhandler and Validation exception)
creating custom exception
creating mapping helpers

* Implemet Unit of Work & Repository Pattern (for practicing)
* Creating and Adding Migrations to Sql Server Database

Creating GlobalUsings - putting together all the directives statements in a single file (per project)

Override RoleManager (Identity Core) default settings
Stack Used: Entity Framework Core (ORM), JWT Token (Bearer), Identity Core (Authentication, Authorization Role-based), Fluent Validation, AutoMapper, Dependency Injection, Entity Configuration, Adding Custom Configuration to Identity Core Entities

The client interface was made using Blazor Web Assembly


------------------------
* Creating a Clothe Shop Application with CQRS & Mediator for the WebAPI
* The Database is SqlServer with EntityFrameworkCore
* Authentication with JwtBearer Token from Identity.Core
* Authorization based on Roles containing Customer/Admin Areas

* Features
  * Stripe Checkout
  * Admin Manager
  * CRUD Cart
  * View Orders

