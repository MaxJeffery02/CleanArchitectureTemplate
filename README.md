# .NET Clean Architecture & CQRS Solution Template

[](https://opensource.org/licenses/MIT)
[](https://dotnet.microsoft.com/download)
[](https://www.docker.com/)
[](https://www.postgresql.org/)

A production-ready, containerized solution template for building scalable, maintainable, and high-performance Web APIs using **.NET**. This template enforces **Clean Architecture** principles and implements **CQRS** with a hybrid data access strategy to ensure optimal performance.

It is fully configured for **PostgreSQL** and includes **Docker Compose** orchestration for instant development environment setup.

## 🚀 Key Features

  * **Clean Architecture:** Strict separation of concerns keeping the Domain and Application layers independent of frameworks and databases.
  * **CQRS Pattern:** Segregation of Read (Queries) and Write (Commands) operations.
  * **Hybrid Data Access:**
      * **EF Core & Unit of Work:** Used for **Commands** (Writes) to ensure transactional consistency and easy domain modeling.
      * **Dapper:** Used for **Queries** (Reads) to execute raw SQL against PostgreSQL for high-performance data retrieval.
  * **Containerization:** Fully Dockerized application and database setup.
  * **Advanced REST APIs:** Implements **HATEOAS** for self-discoverable RESTful services.
  * **Security:** Integrated **ASP.NET Core Identity** with **JWT Authentication**.

-----

## 🛠 Technologies

  * **Core:** .NET / C\#
  * **Database:** PostgreSQL
  * **Containerization:** Docker & Docker Compose
  * **ORM (Writes):** Entity Framework Core (Npgsql)
  * **Micro-ORM (Reads):** Dapper
  * **Authentication:** ASP.NET Core Identity & JWT Bearer
  * **Validation:** FluentValidation

-----

## 🏁 Getting Started

You can run this application using Docker (recommended) or manually.

### Prerequisites

  * [Docker Desktop](https://www.docker.com/products/docker-desktop) (if running with Docker)
  * [.NET SDK](https://dotnet.microsoft.com/download) (if running manually)

### 🐳 Option 1: Run with Docker (Recommended)

This will spin up the API and a PostgreSQL container automatically.

1.  **Clone the repository**

    ```bash
    git clone https://github.com/yourusername/your-repo-name.git
    cd your-repo-name
    ```

2.  **Run Docker Compose**

    ```bash
    docker-compose up --build
    ```

The API will be accessible at `http://localhost:5000` (or your configured port) and the database will be running on port `5432`.

-----

### 🔧 Option 2: Manual Setup

If you prefer to run the application on your local machine (without Docker for the API), follow these steps.

1.  **Configure Database Connection**
    Ensure you have a PostgreSQL instance running. Update `appsettings.json` in the API project:

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Port=5432;Database=CleanArchDb;Username=postgres;Password=yourpassword"
    }
    ```

2.  **Configure JWT Settings**
    Update the `JwtSettings` in `appsettings.json`:

    ```json
    "JwtSettings": {
      "Key": "Your-Super-Secret-Key-Must-Be-Longer-Than-This",
      "Issuer": "YourApp",
      "Audience": "YourAppUser",
      "DurationInMinutes": 60
    }
    ```

3.  **Run Migrations**
    Apply the EF Core migrations to create the PostgreSQL schema.

    ```bash
    dotnet ef database update --project src/Infrastructure --startup-project src/API
    ```

4.  **Run the Application**

    ```bash
    dotnet run --project src/API
    ```

-----

## 📖 API Usage (HATEOAS Example)

This API implements HATEOAS (Richardson Maturity Model Level 3). A typical response includes links to valid next actions:

```json
{
  "id": 1,
  "name": "Clean Code Book",
  "price": 30.00,
  "links": [
    {
      "href": "https://localhost:5001/api/products/1",
      "rel": "self",
      "method": "GET"
    },
    {
      "href": "https://localhost:5001/api/products/1",
      "rel": "update-product",
      "method": "PUT"
    },
    {
      "href": "https://localhost:5001/api/products/1",
      "rel": "delete-product",
      "method": "DELETE"
    }
  ]
}
```

-----

## 🤝 Contributing

1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.
