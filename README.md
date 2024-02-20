Mobile Store

Description

Mobile Store is a web application designed to serve as an online platform for purchasing mobile phones. It provides users with the ability to create accounts, browse available mobile phones, search for specific models, filter by brand, and place orders securely. The application is built using .NET 8 and follows the CQRS (Command Query Responsibility Segregation) architecture and Clean Architecture along with the Mediator and Repository design patterns for efficient and scalable development.

Technology
- .NET 8
- Clean Architecture 
- CQRS (Command Query Responsibility Segregation)
- Mediator Design Pattern
- Repository Design Pattern

Authentication and Authorization
Authentication and authorization in Mobile Store are handled using JWT (JSON Web Tokens) with role-based authorization. Users are required to authenticate with their credentials (email and password) to access specific features, and their roles determine the level of access granted within the application.

Features and Endpoints
- Create (Register) User: `/api/auth/register` (POST)
- Login User: `/api/auth/login` (POST)
- View Available Items: `/api/items` (GET)
- Search for Items: `/api/items/search` (GET)
- Filter by Category: `/api/items/category/{categoryId}` (GET)
- Create, Update, Delete Item (Admin Only): `/api/items` (POST, PUT, DELETE)
- Create, Update, Delete Category (Admin Only): `/api/categories` (POST, PUT, DELETE)
- Create Order: `/api/orders` (POST)
- Get Order: `/api/orders/{orderId}` (GET)
- Cancel Order (Admin Only): `/api/orders/{orderId}` (DELETE)

How to Run the Project

1. Clone the project repository to your local machine.
2. Navigate to the project directory.
3. Run `dotnet add package Microsoft.EntityFrameworkCore.Design` to add the necessary package for Entity Framework Core design.
4. Run `dotnet ef database update` to apply the initial migration and create the database schema.
5. Start the application using `dotnet run`.
6. Access the application through your preferred web browser.

Note: Upon running the project, some initial data will be seeded into the database, and an admin user will be created automatically with the following credentials:
- Email: admin@example.com
- Password: 12345678

 Contribution

Contributions to Mobile Store are welcome! To contribute, please fork the repository, make your changes, and submit a pull request. For major changes, please open an issue first to discuss the proposed changes.

