# Blazor Shop Store (Report Work: Still In Progress)

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
* configure stripe payment - secret key on web api

* Checking Stripe payment integrity by checking stripe signature with web hook secret key, using a local test environment to make payments.. for web hook was used ngrok to create a web hook and configure it in the stripe dashboard ...... command run ngrok http https://localhost:44351 -host-header="localhost:44351" (be aware, changes to routes will apply)



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


----------
The client interface was made using Blazor Web Assembly

* Creating Authorization Policies based on Role
* Making request through Http to the web api using HttpClient
* Using Local Sorage to save the JWT Token - settting the token to HTTP Authroization Header
* Using Blazor ToastService
* Using MatBlazor and Radzen Blazor libraries for design an bootstrap
* Injecting service
* Using Authentication State Provider to authorize user access to application
* Using razor components to create pages



Other Project: Unit or Work - Demonstrating the concept


Worker Service Project - to invalidate a user subscription

Unit Test Project (Under Development)


* Features
	* Stripe Checkout
	* Stripe Subscription Manager

	* Account Feature
		* Login, Register, Logout, Reset Password
	* Admin
		* Managing Clothes, Musics, Subscriptions
		* Managing Roles and Users
		* Managing Subscribers
	* Shopping Cart Feature
	* Clothes Feature
	* Musics Feature
	* Orders Feature
	* Receipts Feature
	* Subscriptions Feature
	* User Profile
