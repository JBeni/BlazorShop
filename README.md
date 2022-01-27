# Blazor Shop Store

* This repository contains the code of an online shop, both the front-end and the back-end, the database was built using the Code-First approach (the migrations are also present, just migrate them to your local SQL Server Database). The interface is built using pages but using the razor component functionalities. The server is based on Net 6 with C# 10 capabilities. The server is a Web API implemented using the guidelines of CQRS and Mediator architectural pattern.

* Video Demo Link: (In the Future)

# Web API functionalities:
	* Unit of Work Project to demonstrate the Unit of Work with Repository Pattern design pattern
	* Worker Service Project - to deactivate a user subscription
	* Unit Test Project (Under Development)

	* Create global _Imports file for C# using statements
	* Creating logger for errors

	* Domain Layer - creating the database entities and identity entities (to manage users and their authorization claims)

	* Application Layer
		* Creating commands, queries and handlers for entities
		* Creating validators for commands and queries
		* Creating mapping from database model to view model
		* Creating custom exception flow and mapping helpers
		* Creating generic response model
		* Configure AutoMapper, FluentValidation and Mediator

	* Infrastructure Layer
		* Implement Identity Core Services (Account, User and Role)
		* Configure Entity Framework Core Database (Identity DbContext)
		* Configure configurations for entities
		* Creating and Adding Migrations to SQL Server Database
		* Create Seed Data
		* Configure SqlServer Database
		* Configure Authorization policies and specifically implement IdentityUser with IdentityRole Managers
		* Inject Services

	* Web API Layer
		* Configure Application and Infrastructure layers
		* Configure Authentication using Jwt Bearer tokens (with validation parameters)
		* Configure Stripe Gateway Payments
		* Configure Stripe WebHook for the local testing environment (Ngrok provider)
		* Setting CORS policy
		* Adding Filters and Middleware
		* Using StringResources for Roles
		* Creating controllers for API endpoints
<br/>

# Blazor Web Assembly

* The application design was built mainly using Bootstrap 5. The client interfaces have been built with the latest version of Blazor Web Assembly. Some of the functionalities of the Blazor Web application are:

* Creating Authorization Policies based on Role
* Making requests through HTTP to the Web API using HttpClient library
* Using Local Storage to save the JWT Token - setting the token to HTTP Authorization Header
* Using Blazor ToastService to show messages
* Using MatBlazor and Radzen Blazor libraries for design and bootstrap
* Using Authentication State Provider to authorize user access to application
* Using razor components to create pages
<br/>

# Application Features

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
