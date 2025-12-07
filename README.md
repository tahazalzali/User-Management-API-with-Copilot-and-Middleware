# User Management API with Copilot and Middleware (.NET)

A .NET Web API for managing users with full CRUD operations, input validation, and custom middleware for logging and API-key authentication.  
The code was written, enhanced, and debugged with the help of **GitHub Copilot** as part of an API development assignment.

---

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Project Requirements Mapping](#project-requirements-mapping)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Running the API](#running-the-api)
- [Configuration](#configuration)
- [API Endpoints](#api-endpoints)
  - [GET /users](#get-users)
  - [GET /usersid](#get-usersid)
  - [POST /users](#post-users)
  - [PUT /usersid](#put-usersid)
  - [DELETE /usersid](#delete-usersid)
- [Validation](#validation)
- [Middleware](#middleware)
- [Using GitHub Copilot](#using-github-copilot)
- [Future Improvements](#future-improvements)
- [License](#license)

---

## Project Overview

This project is a **User Management REST API** built with **ASP.NET Core (.NET )**.

It exposes endpoints to:

- Create new users
- Get all users
- Get a single user by ID
- Update existing users
- Delete users

For simplicity, the API uses an **in-memory list** as the data store (no external database required).  
The project demonstrates:

- Clean RESTful API design
- Model validation
- Custom middleware for **logging** and **API-key authentication**
- Usage of **GitHub Copilot** for writing, enhancing, and debugging code

---

## Features

- ✅ **CRUD endpoints** for user management (`GET`, `POST`, `PUT`, `DELETE`)
- ✅ **Input validation** using data annotations (`[Required]`, `[EmailAddress]`, etc.)
- ✅ **Custom middleware**:
  - Request logging (logs HTTP method, path, status code, and duration)
  - Simple API-key authentication via `X-Api-Key` header
- ✅ **In-memory user store** (no DB setup needed)
- ✅ **Swagger/OpenAPI** for easy testing (if enabled in `Program.cs`)

---

## Technology Stack

- **Framework:** .NET / ASP.NET Core Web API
- **Language:** C#
- **Packages:**
- `Swashbuckle.AspNetCore` (for Swagger UI, if included)
