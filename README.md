# Authentication with .Net Core 5

This is a simple project to authenticate an user separated by project layers and responsibilities.

## Features

- Create user
- Retrieve user by username
- Login user

## Technologies

- ASP.Net Core 5
- Micro ORM Dapper
- Postgres Database
- JWT
- BCrypt

## Patterns

- Repository
- Inversion of control

## Folders structure

- Authentication - (webapi project)
- Core
- Core.Interfaces
- Core.Ioc
- Domain
- Infrastructure
- Infrastructure.Interfaces
- Infrastructure.Ioc
- Tests (xunit)

### Core

This project with all logic of application.

### Infrastructure

This project contains all structure and logic to access the data.

### Domain

This project contains all Entities and DTOs of the application.

### Tests

This is a xunit project to test the rules of application.

## References

[Balta.io](https://balta.io/artigos/aspnet-5-autenticacao-autorizacao-bearer-jwt)

[BCrypt](https://github.com/BcryptNet/bcrypt.net)

[Hash and Verify Passwords](https://jasonwatmore.com/post/2020/07/16/aspnet-core-3-hash-and-verify-passwords-with-bcrypt)
