### Overview

**Service** designed to calculate income tax in the United Kingdom (UK).  
The project implements JWT-based authentication, provides an endpoint for calculating income tax, and includes a health check to verify that the service is running.

#### Dependencies & Libraries Used

- **MediatR**
- **Microsoft.AspNetCore.Authentication.JwtBearer**
- **Microsoft.EntityFrameworkCore**
- **Microsoft.EntityFrameworkCore.InMemory**
- **Swashbuckle.AspNetCore**
- **xUnit**

---

#### Project Structure

```
.
├── src
│   ├── Services.Tax.Api                # Web layer — controllers, DI setup, configuration
│   ├── Services.Tax.Domain             # Business logic, entities, models
│   └── Services.Tax.Infrastructure     # Repositories, services, utilities, and interface implementations
│
└── tests
    └── Services.Tax.Infrastructure.Tests  # Unit tests for the Infrastructure layer
```

---

#### HTTP Methods

##### **1. Authentication**
```csharp
[HttpPost("login")]
```
- Used to **generate a JWT token**.  
- Accepts `UserName` and `Password`.  
- On success, returns a `token` which must be included in subsequent requests using the header:  
  `Authorization: Bearer <token>`.

---

##### **2. Income Tax Calculation**
```csharp
[HttpPost("calculate")]
```
- The **main API method** that calculates the income tax for a given income amount.  

---

##### **3. Health Check**
```csharp
[HttpGet("health")]
```
- Checks whether the **application is up and running**.  
- Returns HTTP `200 OK` if the service is healthy.

---

#### Configuring User Secrets

Before running the application, you must **configure User Secrets** to store the JWT secret key securely.

1. Open a terminal in the `Services.Tax.Api` project directory.  
2. Initialize User Secrets:
   ```bash
   dotnet user-secrets init
   ```
3. Add your JWT secret key:
   ```bash
   dotnet user-secrets set "Security:JwtSecretKey" "q+zN1T0sR7EjLdxry8t4E9+7TnYkFSvdpKNU5uM6c9o="
   ```

**Alternatively**, you can use a `secrets.json` file for local development:

```json
{
  "Security:JwtSecretKey": "q+zN1T0sR7EjLdxry8t4E9+7TnYkFSvdpKNU5uM6c9o="
}
```

---

#### Running the Application Locally

```bash
cd src/Services.Tax.Api
dotnet run
```

By default, the API will be available at:  
👉 http://localhost:8080/swagger

---

#### Running the Application in Docker

1. Build the Docker image:
   ```bash
   docker build -t income-tax-api .
   ```

2. Run the container:
   ```bash
   docker run -e ASPNETCORE_ENVIRONMENT=Development -p 8080:8080 income-tax-api
   ```

3. Open your browser at:  
   👉 [http://localhost:8080/swagger](http://localhost:8080/swagger)

---

#### Running Tests

To execute unit tests:

```bash
cd tests/Services.Tax.Infrastructure.Tests
dotnet test
```

---