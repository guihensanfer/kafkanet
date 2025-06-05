# Microservices Project - UsersAPI & ProductsAPI

## Overview

This project is a complete **microservices-based architecture** developed with **.NET Core 8** and **PostgreSQL**, providing two isolated and private APIs:

1. **UsersAPI** – handles user registration and authentication with **JWT**.
2. **ProductsAPI** – manages product catalog and inventory.

Both services are independently deployable and documented via **Swagger**.

An **Angular frontend** application consumes these APIs through an **API Gateway**, providing a unified interface for users while encapsulating the complexity of multiple backend services.

---

## Architecture

- **UsersAPI**:  
  ✅ User registration with ASP.NET Core Identity  
  ✅ Secure authentication using **JWT**  
  ✅ Endpoints protected by token-based authorization  

- **ProductsAPI**:  
  ✅ Product creation, listing, and management  
  ✅ Private API, only accessible via API Gateway  

---

## Key Technologies

- **.NET Core 8** – Web API framework
- **Entity Framework Core** – ORM for PostgreSQL
- **PostgreSQL** – Relational database
- **ASP.NET Core Identity** – User management and security
- **JWT** – Token-based authentication
- **Swagger / OpenAPI** – API documentation
- **Angular** – Frontend consuming APIs via Gateway

---

## Features

✅ Microservices architecture with independent deployment  
✅ Secure user authentication and authorization (JWT)  
✅ Product management microservice  
✅ PostgreSQL integration  
✅ API documentation with Swagger  
✅ Angular SPA consuming APIs through API Gateway  

## Authentication

Both APIs require **JWT Bearer tokens** for secure access to protected endpoints.

## API Documentation

Each microservice provides **Swagger** UI for testing and exploration:

- UsersAPI: `https://localhost:{port}/swagger`
- ProductsAPI: `https://localhost:{port}/swagger`

Accessible endpoints are listed with input/output models and response examples.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [PostgreSQL](https://www.postgresql.org/)
- [Node.js & Angular CLI](https://angular.io/guide/setup-local)
- API testing tool (e.g., Postman)
