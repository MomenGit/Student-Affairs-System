# Student Affairs System

The **Student Affairs System** is a web application designed to manage university student affairs. It features functionalities for managing students, professors, courses, departments, study programs, and more. The application provides an admin web interface for university administrators and a separate client web app for students and instructors, both communicating through a central API.

## Features

1. **User Management**: Manage university users such as Students, Professors, and Admins.
2. **Faculty & Department Management**: Administer faculties and departments, linking them to study programs.
3. **Study Programs**: Define programs of study, associate courses, and track student progress across semesters.
4. **Course Management**: Administer courses, associate them with study programs, and manage enrollments.
5. **Semester Management**: Define and track semesters, associating courses and student enrollments.
6. **Course Enrollment & Grading**: Enroll students in courses and manage grading for individual courses.
7. **Admin Dashboard**: A Blazor-based interface for administrative tasks, with direct access to data via the API or Entity Framework.
8. **Client Web App**: A separate front-end for students and professors to view and manage their information. You can find it here [Client]()

## Architecture

The project is designed following **Domain-Driven Design (DDD)** principles and separated into three main layers:

1. **API Layer** (`WebApi`):  
   Provides a RESTful API for all clients to interact with the system's core functionalities.
   
2. **Admin Dashboard** (`AdminDashboard`):  
   Built with Blazor, it allows university administrators to manage users, study programs, courses, and departments.

3. **Client Web Application** (`ClientWebApp`):  
   A separate client-facing web application used by students and professors, built with Blazor and connected to the central API. You can find it here [Client]()

### Domain Structure

The solution follows a domain-based structure where each module (e.g., Users, Courses, University Management) is encapsulated as a separate class library. Each domain handles its own entities, repositories, and services.

Domains:
- **Users Domain**: Handles users, including students, professors, and admins.
- **University Domain**: Manages faculties, departments, and study programs.
- **Courses Domain**: Deals with courses, course enrollments, and semester courses.

### Database

- **Database**: PostgreSQL
- **ORM**: Entity Framework Core with Fluent API configurations.
  
The database schema consists of the following key entities:
- **User**: Base class for students, professors, and admins.
- **Study Program**: Defines programs of study across multiple semesters.
- **Course**: Represents individual courses that can belong to multiple programs.
- **Course Enrollment**: Tracks student enrollment in courses.
- **Semester**: Manages academic semesters, linking courses to programs.

## Prerequisites

- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Azure](https://azure.microsoft.com) (for hosting)
  
## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/MomenGit/StudentAffairsSystem.git
cd StudentAffairsSystem
```

### 2. Set Up Database

Ensure that PostgreSQL is installed and running. Create a database and configure the connection string in the `appsettings.json` of both the Web API and Admin Dashboard.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=StudentAffairs;Username=postgres;Password=yourpassword"
  }
}
```

### 3. Migrate the Database

Run the migrations to set up the database schema:

```bash
cd Shared
dotnet ef database update
```

### 4. Run the Solution

Start the Web API and Admin Dashboard:

```bash
# In separate terminals
cd WebApi
dotnet run

cd AdminDashboard
dotnet run
```

### 5. Access the Application

- **Admin Dashboard**: `https://localhost:5001`
- **API**: `https://localhost:5000`
- **[Client Web App]()**: Will need to be run separately.

## Project Structure

```
StudentAffairsSystem/
├── WebApi/                    # API Project
├── AdminWebApp/               # Admin Dashboard (Blazor)
├── Infrastructure/            # Business Logic
├── Shared/                    # Shared models, utilities, base classes, Repositories, 
├                                Unit of Work, and EF Core configurations
└── Domains/                   # Domains:
    ├── Users/                 # Users Domain
    ├── Students/              # Students Domain
    ├── Professors/            # Professors Domain
    ├── Admins/                # Admins Domain
    ├── Courses/               # Courses Domain
    ├── StudyProgramCourses/   # StudyProgram Courses Domain
    ├── SemesterCourses/       # Semester Courses Domain
    ├── CourseEnrollments/     # CourseEnrollments Domain
    ├── Faculties/             # Facultys Management Domain
    ├── Departments/           # Departments Management Domain
    ├── StudyPrograms/         # StudyPrograms Management Domain
    └── Semesters/             # Semesters Management Domain
```

## API Documentation

The API exposes the following key endpoints:
- **Users**: `/api/users`
- **Students**: `/api/students`
- **Professors**: `/api/professors`
- **Courses**: `/api/courses`
- **Study Programs**: `/api/studyprograms`

Use tools like [Postman](https://www.postman.com/) or [Swagger](https://swagger.io/) for testing.

## Testing

Unit tests are located in the `Tests` project. To run the tests:

```bash
cd Tests
dotnet test
```

## Deployment

The project is designed to be hosted on **Azure**. Follow these steps for deployment:
1. Publish the API and the Blazor Admin Dashboard to an Azure Web App.
2. Publish [Client Web App]() to separate Azure App Services.
3. Configure your PostgreSQL instance on Azure Database for PostgreSQL.

## Contributing

Contributions are welcome! Please follow the steps below:
1. Fork the repository.
2. Create a feature branch: `git checkout -b feature/my-feature`
3. Commit your changes: `git commit -m 'Add new feature'`
4. Push to the branch: `git push origin feature/my-feature`
5. Open a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
