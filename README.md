# EmotiaMart

**EmotiaMart** is a modern, scalable e-commerce application built using **Angular** (frontend), **.NET Core** (backend), and **GraphQL**. The project follows **Clean Architecture principles** to ensure maintainability, testability, and scalability.

---

## **Folder Structure (Clean Architecture)**


EmotiaMart/
├── src/
│ ├── EmotiaMart.Backend/
│ │ ├── EmotiaMart.API/ # GraphQL API project  # Presentation layer
│ │ ├── EmotiaMart.Application/ # Application services, DTOs, use cases # Application layer
│ │ ├── EmotiaMart.Domain/ # Entities, Value Objects, Enums  # Core layer
│ │ └── EmotiaMart.Infrastructure/ # EF Core, Repositories, external services # Infrastructure layer
│ │
│ └── Web-Spa/ # Angular frontend project
├── tests/ # Unit and integration tests
├── docker-compose.yml # Docker Compose for backend + frontend
└── EmotiaMart.sln # .NET Solution file

---

## **Backend Project Setup (Commands)**

### **Create Projects**

```bashcd
# API
dotnet new webapi -n EmotiaMart.API -o src/EmotiaMart.Backend/EmotiaMart.API

# Application
dotnet new classlib -n EmotiaMart.Application -o src/EmotiaMart.Backend/EmotiaMart.Application

# Domain
dotnet new classlib -n EmotiaMart.Domain -o src/EmotiaMart.Backend/EmotiaMart.Domain

# Infrastructure
dotnet new classlib -n EmotiaMart.Infrastructure -o src/EmotiaMart.Backend/EmotiaMart.Infrastructure


# API → Application & Infrastructure
cd src/EmotiaMart.Backend/EmotiaMart.API
dotnet add reference ../EmotiaMart.Application/EmotiaMart.Application.csproj
dotnet add reference ../EmotiaMart.Infrastructure/EmotiaMart.Infrastructure.csproj

# Application → Domain
cd ../EmotiaMart.Application
dotnet add reference ../EmotiaMart.Domain/EmotiaMart.Domain.csproj

# Infrastructure → Domain & Application
cd ../EmotiaMart.Infrastructure
dotnet add reference ../EmotiaMart.Domain/EmotiaMart.Domain.csproj
dotnet add reference ../EmotiaMart.Application/EmotiaMart.Application.csproj

---

## **Frontend Project Setup (Commands)**

### **Create Projects**

cd /src
ng new EmotiaMart.WebSpa --routing --style=scss

# Hot reloading

Package.Json

"start": "ng serve --host 0.0.0.0 --poll 2000",



# **Database and Entity Framework EmotiaMart.API**
dotnet add package Microsoft.EntityFrameworkCore           # Core ORM functionality
dotnet add package Microsoft.EntityFrameworkCore.SqlServer # SQL Server provider
dotnet add package Microsoft.EntityFrameworkCore.Tools     # Enables dotnet ef commands
dotnet add package Microsoft.EntityFrameworkCore.Design    # Provides design-time services for migrations generated class in migration folder
dotnet add package BCrypt.Net-Next                 


# ** EmotiaMart.Infrastructure**
dotnet add package Microsoft.EntityFrameworkCore   # Core ORM functionality
dotnet add package Microsoft.EntityFrameworkCore.SqlServer # SQL Server provider 
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Quartz
dotnet add package Quartz.Extensions.Hosting
dotnet add package Quartz.Serialization.Json

Add AppDbContext #Entity Framework Core (EF Core) DbContext class (AppDbContext inherits from DbContext, which is the main class in EF Core responsible for interacting with the database.)
Add DependencyInjection to the EmotiaMart.Infrastructure

# **Run migration command**
dotnet ef migrations add InitialCreate -s ../EmotiaMart.API/EmotiaMart.API.csproj -o Data/Migrations
Update database Add Code to Program.cs auto update the database 



## **Program.cs SetUp**
## **Service layer**
AddCors()

## **App layer**
UseCors()
MapGraphQL("/graphql");

# Add configuration Audit trail 
# Add mediatR Configuration Register in Applicationlayer


# Add Certificate 
dotnet dev-certs https --trust --export-path .devcontainer/local_cert.pfx -p EmotiaMart123

# Configuration for GraphQl
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();
app.MapGraphQL("/graphql");

# Angular app# https 
ng serve --ssl true --ssl-cert "D:\EmotiaMart\.devcontainer\server.crt" --ssl-key "D:\EmotiaMart\.devcontainer\server.key"

# Frontend Layout 

src/app/
├── app.module.ts
├── app-routing.module.ts
├── shared/
│   ├── shared.module.ts
│   ├── material.module.ts
│   └── models/
│       ├── user.model.ts
│       ├── category.model.ts
│       ├── brand.model.ts
│       ├── product.model.ts
│       └── order.model.ts
├── auth/
│   ├── auth.module.ts
│   ├── auth-routing.module.ts
│   ├── layouts/
│   │   └── auth-layout/
│   │       ├── auth-layout.component.ts
│   │       └── auth-layout.component.html
│   ├── components/
│   │   ├── login/
│   │   │   ├── login.component.ts
│   │   │   └── login.component.html
│   │   ├── register/
│   │   │   ├── register.component.ts
│   │   │   └── register.component.html
│   │   └── forgot-password/
│   │       ├── forgot-password.component.ts
│   │       └── forgot-password.component.html
│   └── services/
│       └── auth.service.ts
└── admin/
    ├── admin.module.ts
    ├── admin-routing.module.ts
    ├── components/
    │   ├── dashboard/
    │   │   ├── dashboard.component.ts
    │   │   └── dashboard.component.html
    │   ├── users/
    │   │   ├── users.component.ts
    │   │   └── users.component.html
    │   ├── categories/
    │   │   ├── categories.component.ts
    │   │   └── categories.component.html
    │   ├── brands/
    │   │   ├── brands.component.ts
    │   │   └── brands.component.html
    │   ├── products/
    │   │   ├── products.component.ts
    │   │   └── products.component.html
    │   └── orders/
    │       ├── orders.component.ts
    │       └── orders.component.html
    └── services/
        ├── user.service.ts
        ├── category.service.ts
        ├── brand.service.ts
        ├── product.service.ts
        └── order.service.ts

# ng generate module admin --routing --flat  give me both router an module too


# Problem: Could not resolve angular routing  Onload 404 Issue
# Solve https://medium.com/@dulanjayasandaruwan1998/solving-angulars-404-error-on-page-refresh-two-effective-approaches-619cbd544379

# Appllo set up

ng add apollo-angular
# Problem 
We couldn't find 'esnext.asynciterable' in the list of library files to be included in the compilation.
It's required by '@apollo/client/core' package so please add it to your tsconfig.


We couldn't enable 'allowSyntheticDefaultImports' flag.
It's required by '@apollo/client/core' package so please add it to your tsconfig.
# Solve: https://stackoverflow.com/questions/79270208/why-does-a-new-angular-19-app-error-when-executing-ng-add-apollo-angular