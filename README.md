# Employee Feedback API

A simple web API where employees can leave feedback about their workplace.

## What does this do?

This is a REST API that lets employees:
- Submit anonymous feedback with a rating (1 to 5 stars)
- View all feedback that has been submitted
- Get summary statistics by department (like HR, Engineering, etc.)

## Technologies Used

- .NET 9 (C#)
- ASP.NET Core Web API
- Entity Framework Core (for database)
- SQLite (lightweight database file)

![Get All Feedback](screenshot1.png)
*Screenshot showing the GET all feedback endpoint working*

## API Endpoints (What you can do)

| What it does | HTTP Method | URL | Example |
|-------------|-------------|-----|---------|
| Add new feedback | POST | `/feedback` | See below |
| Get all feedback | GET | `/feedback` | Just visit the URL |
| Get department summary | GET | `/feedback/summary?department=HR` | Replace HR with any department |

