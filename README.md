# UserValidationApi


## UserValidationApi

Project to demonstrate basic CRUD operations for a user.

#### Running the Project

- The test database is a SQLite database located in this same repository.
- To run the project, simply clone the repository and execute `dotnet run` in your terminal.

---

#### What's Implemented

This is a simple User CRUD API.

To view the API documentation, run the project and visit `localhost:8080/swagger-ui`.

1. **User Validation**
   - Validation is done using the `XPTO` library. All API inputs are validated by this library.
   - You can find the validation tests in [./test](./test).

2. **Dependency Injection**
