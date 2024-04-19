## UserValidationApi

Project to demonstrate the use case for Sinqia-Bofa.

### Running the Project

- To run the project, simply clone the repository and execute `dotnet run` in your terminal.

---

### What's Implemented

This is a simple User API.

To view the API documentation, run the project and visit `https://localhost:7194/swagger/index.html`. 
If you are using Visual Studio, it should open by default on the Swagger page.

1. **User Validation**
    - Validation is done using the `UserController.cs` controller and the `UserService` service.
    - You can find the validation tests in `UserValidationApi\UserValidationApi.Test\Services\UserServiceTests.cs`.

2. **Dependency Injection**
    - The dependency injection can be verified in `Controllers\UserController.cs` and `Program.cs`.

3. **Factory Method**  
    - The Factory can be verified in `Factory\UserFactory` and `Services\UserService`.

4. **Observation Mechanism**  
    - The Observation can be verified in `Services\Observes` and `Services\UserService`.

5. **Singleton Manager**  
    - The Singleton can be verified in `Services\SingletonManger.cs`, `Services\UserService`, and `Factory\UserFactory.cs`.

---

### Run Tests and Generate a Coverage Report

1. **Install the tool dotnet-coverage** 
    ```bash
    dotnet tool install --global dotnet-coverage 
    ```
    - **Observation:** Only run this command once to install the tool. If already installed, skip this step.
   
2. **Run tests and collect coverage data**
    ```bash
    dotnet test --collect:"XPlat Code Coverage"
    ```

3. **Generate a coverage report**
    ```bash
    reportgenerator -reports:".\TestResults\{guid}\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
    ```
    - **Observation:** Don't forget to replace the {guid} created in the previous step.

The coverage should look like this:
![image](https://github.com/antoniel-besson/UserValidationApi/assets/90410879/aa6e7893-9b13-4c05-97a5-97160e0989c9)



