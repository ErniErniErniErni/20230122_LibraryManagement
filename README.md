# Library Management System

The Library Management System is a web application for managing books, authors, customers, and library branches. This README provides an overview of the project, installation instructions, and usage guidelines.

## Author

Erni Wo

## Features

- View all books, authors, branches and customers stored in the database.
- Add new books, authors, branhes, and customers.
- Manage authors and library branches.

## Getting Started

Instructions on how to run the application:

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/get-started/)

### Installation

1. Clone the repository:

   ```git clone https://github.com/ErniErniErniErni/20230122_LibraryManagement.git```

2. Navigate to the project directory:

   ```cd LibraryManagement```

3. Restore dependencies:

   ```dotnet restore```

4. Apply database migrations to create the database:

   ```dotnet ef database update```

5. Start the application:

   ```dotnet run```

The application should now be running at a location similar to http://localhost:5000 (e.g.: http://localhost:5108). See terminal message for the exact URL.

## Usage

- Open your web browser and navigate to the location shown on your terminal (e.g.: http://localhost:5000).
- Use the application to navigate to all the pages including Book, Author, Customer, and Branch.
- Add data as needed.

