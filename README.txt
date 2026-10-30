 Flight Search API

About the Project

This project is a simple Flight Search API developed using ASP.NET Core Web API and .NET 8.
The idea behind this application is to allow users to add flight details and search for available flights based on their source airport, destination airport, and travel date.
When a user searches for flights, the API returns matching results sorted by price, starting with the lowest-priced flight.
I built this project as part of the Senior .NET Core Developer assessment, focusing on clean code, proper input validation, asynchronous database operations, and API documentation.

Technologies Used

- C#
- .NET 8 / ASP.NET Core Web API
- Entity Framework Core
- SQL Server Express
- Swagger / OpenAPI
- Dependency Injection
- Asynchronous programming

 Features

- Add new flight details through a POST API.
- Search flights using source, destination, and travel date.
- Display matching flights in ascending order of price.
- Validate required fields and airport codes.
- Prevent users from entering the same source and destination.
- Validate departure time, arrival time, and ticket price.
- Handle unexpected errors through global exception handling.
- Use Entity Framework Core for database operations.
- Use Swagger for API documentation and testing.

Project Structure


PratraFlightSearch

─ Controllers
      ─ FlightsController.cs

─ Data
    ─ FlightDbContext.cs

─ DTOs
    ─ CreateFlightRequest.cs
    ─ FlightResponse.cs
─ Models
    ─ Flight.cs

─ Services
    ─ IFlightService.cs
    ─ FlightService.cs
─ appsettings.json
─ Program.cs

 Getting Started

 Prerequisites

Before running the application, make sure you have:

- Visual Studio 2022 or later.
- .NET 8 SDK.
- SQL Server or SQL Server Express.
- SQL Server Management Studio (SSMS), if you prefer managing the database through a graphical interface.

 1. Clone the Repository

bash
git clone <your-github-repository-url>


Open the solution in Visual Studio.

 2. Configure the Database

Open `appsettings.json` and update the SQL Server connection string to match your local SQL Server instance.

Example:

json
{
  "ConnectionStrings": {
    "FlightConnection": "Server=YOUR_SERVER_NAME;Database=PratraFlightDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}


Replace `YOUR_SERVER_NAME` with your SQL Server instance name.

 3. Apply Database Migrations

Open the Package Manager Console in Visual Studio and run:

powershell
Update-Database


This creates the database and the required tables using Entity Framework Core migrations.

 4. Run the Application

Build and run the project from Visual Studio.

Once the application starts, open the Swagger URL displayed in the browser or application output.

 API Endpoints

1. Add a Flight

Method: POST

Endpoint:

http/api/Flights

Sample Request:

json
{
  "airlineName": "Air India",
  "flightNumber": "AI305",
  "source": "BLR",
  "destination": "DXB",
  "departureTime": "2026-11-15T08:00:00",
  "arrivalTime": "2026-11-15T11:00:00",
  "price": 18500
}
```

Expected Response: 201 Created

The response contains the newly created flight details, including its generated ID.

2. Search Flights

**Method:** GET

Endpoint:

http/api/Flights/search?from=MAA&to=DXB&date=2026-11-15

Search Parameters:

| Parameter | Description |

| from | Source airport code |
| to | Destination airport code |
| date | Travel date |

**Expected Response:** `200 OK`

The API returns matching flights sorted by price in ascending order.

## Error Handling and Validation

The application includes input validation to prevent invalid flight details from being stored.

Some examples:

- Airline name and flight number are required.
- Airport codes must contain exactly three letters.
- Source and destination cannot be the same.
- Arrival time must be later than departure time.
- Flight price must be greater than zero.
- Invalid requests return `400 Bad Request`.
- Unexpected server errors are handled centrally and return `500 Internal Server Error`.

If no matching flights are found, the search API returns `200 OK` with an empty list.

 Design and Implementation

I have kept the application structure straightforward by separating the controller, service, database context, entity model, and DTOs.

- Controllers: Handle incoming HTTP requests and return appropriate HTTP responses.
- Services: Contain the flight creation and search logic.
- Entity Framework Core: Handles database queries and inserts.
- DTOs: Separate API request and response models from the database entity.
- Dependency Injection: Injects the flight service and database context where required.
- Async/Await: Used for database operations to avoid blocking request-processing threads.

The search query filters flights by source, destination, and travel date, and then sorts the results by price.

 API Documentation

Swagger is configured in the application.

It can be used to view the available endpoints, inspect request and response models, and test both GET and POST APIs directly from the browser.
