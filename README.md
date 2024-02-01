# Movie Rental System

## Overview

This project is a Movie Rental System, designed to manage movie inventories, rentals, and reservations for a store. It provides features for both customers and managers, allowing them to browse available films, rent movies, and manage inventory.

## Features

- **Customer Portal:**
  - See all available stores and their locations.
  - View and update personal information.
  - View available films.
  - Rent movies.
  - View rental history, including:
    - active rentals.
    - rental history.
    - overdue rentals.
    - days remaining for active rentals.
  - Submit scores for rented movies.
  - View top-selling categories, films, and actors.
  - Search for movies by title, category, year, or actor.
  - View active rentals and request to return them.
  - View payment history.


- **Manager Dashboard:**
  - View details of all customers.
  - View details of all stores.
  - View details of rentals.
    - Number of rentals of each store.
    - Average score of each movie.
    - Number of copies of each movie available at each store.
    - Number of delays for each movie.
  - View details of active rentals.
  - View customers reservations.
  - Check rentals dates(Return date, rent date).
  - Add movies to each store.
  - Search for movies by title, category, year, or actor.
  - View payments of each store.
  - View top-selling categories, films, and actors.


## Technologies Used

- **Backend:**
  - ASP.NET Core 7 (C#)
  - Entity Framework Core for Database Operations (I used raw SQL queries because this project is for a database course)
  - SQL Server for Database Storage

- **Frontend:**
  - HTML, CSS, JavaScript
  - Razor Pages for Dynamic Content
  - Bootstrap for Styling

## Project Structure
- **/Entities:** Contains the database context and entity classes.
- **/Models:** Contains the data models for the application.
- **/Controllers:** Defines the backend logic for handling HTTP requests.
- **/Views:** Contains Razor views for rendering HTML pages.
- **/Services:** Includes database services for accessing and manipulating data.
- **/wwwroot:** Holds static files like stylesheets, scripts, and background image.

## Setup

1. Clone the repository.
2. Configure the database connection in `appsettings.json`.
3. Run database migrations: `dotnet ef database update`.
4. Build and run the application: `dotnet run`.

## Dependencies

- **ASP.NET Core:** The main web framework for building the application.
- **Entity Framework Core:** ORM for database operations.
- **SQL Server:** Database for storing application data.
- **Entity Framework Core Identity:** Provides user management features like authentication and authorization.


