# Library Managment System

This week, due to the Hungarian Student Days, I did not have enough time to build a complete application.

In the backend project, the Domain folder contains the main domain entities. The Application folder includes the business logic, while the Infrastructure folder contains the technology-specific implementations of interfaces and other necessary classes.

## Running the Application

Follow these steps to run the application:

### Create the Docker container:
Run the following command: "docker-compose up -d"

### Update the database:
Go to the Backend folder and run: "dotnet ef database update"

### Start the Web API:
Go to the WebAPI folder and run: "dotnet run". The application will be available at: "http://localhost:7065/swagger/index.html".


### Important Notes

The user table records in the database are hardcoded. Currently, only 5 user records are created.

The Docker container password is hardcoded in the JSON file. Although this is not ideal, I chose this approach for simplicity instead of using environment variables.

The application does not have a frontend as I did not have time to implement it. Only the Swagger interface is functional.

## The New Functionality

This system handles the management of books, loans, and reservations. The flow of the application includes:

Loaning Books:
When a user attempts to loan a book, the system checks if any copies are available. If all copies are already loaned out, a reservation is created for the user, indicating their place in line for the next available copy.

Returning Books:
When a book is returned, the system first checks if there are any active reservations. If a reservation exists, the system automatically converts the first reservation into a loan and assigns the returned book to the user who made the reservation.

This process ensures that users are able to "reserve" books when none are available, and those reservations are honored as soon as a copy is returned.