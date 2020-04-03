# CourseManager
Sample Application used for demonstrating  how to structure the code in a ASP .NET Core MVC Application

# Initial Setup
The initial setup must be done for the two DbContexts in the application:
  1. `ApplicationDbContext` - used for Authorization and Authentication
  2. `CourseManagerDbContext` - used for implemention application's core functionality

In order to configure dabtabase contexts you have to open the `Package Manager Console` window (from View->Other Windows)
  * For `ApplicationDbContext`, make sure you have selected the `CourseManager` project as the `Default Project` (in the Package Manager Console window) and run `Update-Database -Context ApplicationDbContext` 
  * For `CourseManagerDbContext`,  make sure you have selected the `CourseManager.DataAccess` project as the `Default Project` (in the Package Manager Console window) and run `Update-Database -Context CourseManagerDbContext` 
