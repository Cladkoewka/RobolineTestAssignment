## Product Management API

This project is a RESTful API for managing products and product categories, built using ASP.NET Core. It provides endpoints to create, read, update, and delete products and their categories.

### Technologies

- **.NET Core 8**: For building the web API.
- **Entity Framework Core**: For database interactions.
- **PostgreSQL**: As the database.
- **FluentValidation**: For model validation.
- **Swagger**: For API documentation.


### API Endpoints

#### Product Category Endpoints

- **GET** `/ProductCategory`: Retrieve all product categories.
- **GET** `/ProductCategory/{id:int}`: Retrieve a specific product category by ID.
- **POST** `/ProductCategory`: Create a new product category.
- **PUT** `/ProductCategory/{id:int}`: Update an existing product category by ID.
- **DELETE** `/ProductCategory/{id:int}`: Delete a product category by ID.

#### Product Endpoints

- **GET** `/Product`: Retrieve all products.
- **GET** `/Product/{id:int}`: Retrieve a specific product by ID.
- **POST** `/Product`: Create a new product.
- **PUT** `/Product/{id:int}`: Update an existing product by ID.
- **DELETE** `/Product/{id:int}`: Delete a product by ID.

### Prerequisites

1. **.NET SDK**: Ensure you have the .NET SDK installed. You can download it from [here](https://dotnet.microsoft.com/download).
2. **PostgreSQL**: You need to have PostgreSQL installed. You can download and install it from [here](https://www.postgresql.org/download/).
3. **Visual Studio or IDE of choice**: For development and debugging.

### Installation Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/ProductManagementAPI.git
   cd ProductManagementAPI
   ```

2. Open the project in your preferred IDE (Visual Studio, Visual Studio Code, etc.).

3. Configure the database connection:
   - Open the `appsettings.json` file.
   - Update the `DefaultConnection` string with your PostgreSQL database credentials:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=yourdb;Username=yourusername;Password=yourpassword"
     }
     ```

4. Run the database migrations:
   ```bash
   dotnet ef database update
   ```

5. Install required packages:
   Ensure that you have the following NuGet packages installed:
   - `Microsoft.EntityFrameworkCore`
   - `Npgsql.EntityFrameworkCore.PostgreSQL`
   - `FluentValidation.AspNetCore`
   - `Swashbuckle.AspNetCore`

   You can install them using the following command:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore
   dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
   dotnet add package FluentValidation.AspNetCore
   dotnet add package Swashbuckle.AspNetCore
   ```

### Running the Application

1. Open a terminal in the project directory.
2. Run the application:
   ```bash
   dotnet run
   ```

3. Once the application starts, navigate to `http://localhost:5000/swagger` to view the API documentation and test the endpoints.


