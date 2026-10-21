<div align="center">

# 🏥 Hospital Management System API

### An ASP.NET Core REST API for managing doctors, patients, and healthcare data relationships

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-512BD4?style=for-the-badge)
![EF Core](https://img.shields.io/badge/Entity%20Framework%20Core-9.0-5C2D91?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge)
![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

**[Features](#-features) · [Tech Stack](#-tech-stack) · [API Endpoints](#-api-endpoints) · [Getting Started](#-getting-started) · [Connect](#-connect-with-me)**

</div>

---

## 📖 Overview

**Hospital Management System API** is a backend project built with **ASP.NET Core 8 Web API**, **Entity Framework Core**, and **SQL Server**. It demonstrates how to design a RESTful healthcare-data API with organized controllers, database access through repositories, and clearly defined Data Transfer Objects (DTOs).

The implementation focuses on **patient and doctor records**, including their relationships with departments and associated patient devices. The codebase is a practical example of backend engineering fundamentals such as **asynchronous data access**, **dependency injection**, **object mapping**, and **relational data modeling**.

> **Project scope:** This repository is a backend learning/portfolio project. It should not be used to process real medical information without implementing appropriate security, privacy, and operational safeguards.

## ✨ Features

- **Doctor records:** Add doctors and retrieve individual doctor details.
- **Patient records:** Create, list, update, and delete patients.
- **Doctor–department association:** Validate a department before adding a doctor, and load department information when retrieving a doctor.
- **Patient–doctor relationships:** Associate patients with multiple doctors and update those assignments.
- **Patient device details:** Support device data as part of patient records.
- **DTO-based API contracts:** Keep API request/response models separate from persistence entities with **AutoMapper**.
- **Repository-based data access:** Combine a **Generic Repository** with specialized doctor/patient repositories.
- **Asynchronous operations:** Use `async`/`await` for database operations.
- **Basic request validation and status codes:** Use ASP.NET Core model validation with standard success and error responses.
- **Interactive API documentation:** Explore the endpoints through Swagger in Development mode.

## 🛠️ Tech Stack

| Area | Technology |
| --- | --- |
| Language | C# |
| Framework | ASP.NET Core 8 Web API |
| ORM | Entity Framework Core 9 |
| Database | Microsoft SQL Server |
| Data access | Generic Repository and specialized repositories |
| Object mapping | AutoMapper |
| API documentation | Swagger / Swashbuckle |
| Dependency management | Built-in ASP.NET Core Dependency Injection |
| Database versioning | EF Core Migrations |

## 🏗️ Project Structure

```text
Hospital-System-API-EVA/
├── Controllers/                # HTTP endpoints for patients and doctors
├── DTO/                        # Request and response data contracts
├── Data/                       # AppDbContext and database configuration
├── Helper/                     # Mapping profile and supporting helpers
├── Migrations/                 # Entity Framework database migrations
├── Models/                     # Domain entities
├── Repo/                       # Generic and specialized repositories
├── Properties/                 # Launch settings
├── Program.cs                  # Application startup and DI configuration
├── appsettings.json            # Application configuration
├── Hospital System EVA API.csproj
└── HospitalSystemEvaApi.sln
```

### How a request is processed

```text
HTTP Request
     ↓
API Controller
     ↓
DTO Validation / AutoMapper
     ↓
Generic or Specialized Repository
     ↓
Entity Framework Core (AppDbContext)
     ↓
SQL Server
```

## 🗃️ Data Model

The EF Core context defines four principal entity sets:

| Entity | Purpose |
| --- | --- |
| `Doctor` | Doctor information and department association |
| `Patient` | Patient information and doctor assignments |
| `Department` | Department data associated with doctors |
| `Device` | Device information associated with patients |

The project demonstrates working with related entities, including assigning multiple doctors to a patient and retrieving a doctor's department details.

## 🌐 API Endpoints

These routes are declared in the current controllers:

| Method | Endpoint | Description |
| --- | --- | --- |
| `POST` | `/api/Doctor` | Add a doctor after checking that the department exists |
| `GET` | `/api/Doctor/{id}` | Retrieve a doctor by ID |
| `GET` | `/api/Patient` | Retrieve all patients |
| `POST` | `/api/Patient` | Add a patient and associate existing doctors |
| `PUT` | `/api/Patient/{id}` | Update a patient, device details, and doctor assignments |
| `DELETE` | `/api/Patient/{id}` | Delete a patient |

**Response behavior:** The controllers use standard HTTP results such as `200 OK`, `400 Bad Request`, and `404 Not Found`, depending on the operation and input.

> Exact request and response shapes can be inspected in Swagger after starting the project.

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server or SQL Server Express
- Visual Studio, VS Code, or another .NET-compatible IDE
- EF Core CLI (`dotnet-ef`) for applying migrations

### 1. Clone the repository

```bash
git clone https://github.com/MMohamedHeshamm/Hospital-System-API-EVA.git
cd Hospital-System-API-EVA
```

### 2. Configure SQL Server

**Important:** The current `Program.cs` reads `ConnectionStrings:x`, but the committed `appsettings.json` contains `ConnectionStrings:HomeDB`. These keys must match before the application can connect to the database.

**Recommended fix:** In `Program.cs`, change:

```csharp
builder.Configuration.GetConnectionString("x")
```

to:

```csharp
builder.Configuration.GetConnectionString("HomeDB")
```

Then configure your SQL Server instance in `appsettings.Development.json` (or use ASP.NET Core User Secrets). For example:

```json
{
  "ConnectionStrings": {
    "HomeDB": "Server=localhost\\SQLEXPRESS;Database=HospitalSystemAPIEvaDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Never commit real credentials or production connection strings.

### 3. Restore packages

```bash
dotnet restore
```

### 4. Apply database migrations

If the EF CLI is not installed, install a compatible EF Core 9 version:

```bash
dotnet tool install --global dotnet-ef --version 9.0.0
```

Apply existing migrations:

```bash
dotnet ef database update --project "Hospital System EVA API.csproj"
```

### 5. Run the API

```bash
dotnet run --project "Hospital System EVA API.csproj"
```

Use the local URL printed in the terminal. In the **Development** environment, open:

```text
https://localhost:<your-port>/swagger
```

Swagger lists the available endpoints and lets you test request and response payloads.

## 🧠 Backend Engineering Concepts Demonstrated

- **RESTful API design:** Organizing resource-oriented HTTP endpoints using controllers.
- **Separation of concerns:** Keeping controller, DTO, entity, and data-access responsibilities distinct.
- **Repository Pattern:** Centralizing common database operations while extending behavior for specific entities.
- **Dependency Injection:** Registering repositories and mapping services with the built-in container.
- **Entity relationships:** Working with department, doctor, patient, and device associations in EF Core.
- **Data mapping:** Using AutoMapper to translate between entities and API-facing DTOs.
- **Async programming:** Performing asynchronous database operations with EF Core.

## 🗺️ Potential Improvements

These are **future enhancements**, not features currently claimed as implemented:

- [ ] Add JWT authentication and role-based authorization
- [ ] Introduce a dedicated service layer for business logic
- [ ] Complete CRUD operations for doctors and other entities
- [ ] Add pagination, filtering, and sorting
- [ ] Introduce centralized exception handling and structured logging
- [ ] Add comprehensive automated unit and integration tests
- [ ] Add appointment and medical-record workflows
- [ ] Introduce Docker support and CI/CD pipelines
- [ ] Secure sensitive healthcare-related information for production use

## 👨‍💻 Author

**Mohamed H. Eldesouky**  
*Backend Engineer | .NET Developer*

## 🔗 Connect With Me

- **LinkedIn:** [linkedin.com/in/mohamedhhh](https://www.linkedin.com/in/mohamedhhh/)
- **GitHub:** [github.com/MMohamedHeshamm](https://github.com/MMohamedHeshamm)

---

<div align="center">

**If you find this project useful, consider giving the repository a ⭐!**

</div>
