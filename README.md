# Modular monolith

Mono-repo style .NET 10 solution with shared domain/common libraries, a modular service stack (ModuleA), a background worker host, and a minimal API host.

## What is in this repo

- `Common`: lightweight messaging abstractions (request/handler interfaces and DI helpers).
- `Domain`: domain entities and core domain types.
- `ModuleA/ModuleA.Services`: application services and request handlers.
- `ModuleA/ModuleA.DataAccess`: EF Core + PostgreSQL DbContext, repositories, migrations, and test-data seeding.
- `Main`: worker host (`BackgroundService`) that continuously queries random users.
- `MainApi`: minimal API exposing user endpoints.

## Solution layout

Projects included by `modmono01.slnx`:

- `Common/Common.csproj`
- `Domain/Domain.csproj`
- `Main/Main.csproj`
- `MainApi/MainApi.csproj`
- `ModuleA/ModuleA.DataAccess.Abstractions/ModuleA.DataAccess.Abstractions.csproj`
- `ModuleA/ModuleA.DataAccess/ModuleA.DataAccess.csproj`
- `ModuleA/ModuleA.Services.Abstractions/ModuleA.Services.Abstractions.csproj`
- `ModuleA/ModuleA.Services/ModuleA.Services.csproj`

## Prerequisites

- .NET SDK 10.0
- PostgreSQL running locally and reachable at the configured connection string

Default connection string in both `Main/appSettings.json` and `MainApi/appSettings.json`:

```json
Server=127.0.0.1;Port=5432;Database=fuszenecker;Username=fuszenecker;Password=admin;
```

Adjust this before running in non-local environments.

## Quick start

1. Restore dependencies:

```bash
dotnet restore modmono01.slnx
```

2. Install local tools (includes `dotnet-ef`):

```bash
dotnet tool restore
```

3. Apply EF Core migrations:

```bash
dotnet ef database update --project ModuleA/ModuleA.DataAccess --startup-project MainApi/MainApi.csproj
```

4. Run one of the hosts:

Minimal API:

```bash
dotnet run --project MainApi/MainApi.csproj
```

Worker host:

```bash
dotnet run --project Main/Main.csproj
```

Both hosts seed test data at startup via `ITestDataSeeder`.

## API endpoints

When `MainApi` is running, available routes:

- `GET /users/{userId}`: fetch a single user by ID.
- `GET /users/count`: fetch total user count.

Example:

```bash
curl http://localhost:5000/users/count
curl http://localhost:5000/users/1
```

If your runtime binds to a different port, replace `5000` accordingly.

## EF Core migrations

Create a new migration:

```bash
dotnet ef migrations add <MigrationName> --project ModuleA/ModuleA.DataAccess --startup-project MainApi/MainApi.csproj
```

Apply migrations:

```bash
dotnet ef database update --project ModuleA/ModuleA.DataAccess --startup-project MainApi/MainApi.csproj
```

Existing migrations are under `ModuleA/ModuleA.DataAccess/Migrations`.

## Notes

- Package versions are centrally managed in `Directory.Packages.props`.
- This repository currently targets `net10.0` across projects.
- `Main` and `MainApi` currently share the same local connection string defaults.
