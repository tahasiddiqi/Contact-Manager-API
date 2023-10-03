The Contact Manager API is a powerful and easy-to-use RESTful web service built with C# using .NET 6 that allows you to efficiently manage your contacts. Whether you need to create, update, delete, or retrieve contact information, this API has you covered. It seamlessly integrates with a PostgreSQL database to securely store and organize your contact data.

Introduction: Start your README with a brief introduction to the project. Mention that it's a .NET 6 Web API for managing contacts and that it uses PostgreSQL as the database.

Prerequisites: Include a section that lists the prerequisites for running the project. Mention that users should have .NET 6 SDK and PostgreSQL installed.
To get started with the Contact Manager API, follow these simple steps:

Packages Required: (latest versions)
Microsoft.EntityFrameworkCore.Tools 
Npgsql.EntityFramework.PostgreSQL
Swashbuckle.AspNetCore

Build and Run the API:

Build and run the API using the .NET CLI:

dotnet run

Swagger Documentation:

Open your web browser and navigate to https://localhost:7011/swagger to explore and test the API endpoints using the Swagger UI.

API Endpoints
The Contact Manager API provides a comprehensive set of endpoints to help you manage your contacts effortlessly:

POST /api/Contact/CreateContact: Create a new contact.
PUT /api/Contacts/UpdateContact/{id}: Update an existing contact by ID.
DELETE /api/Contact/DeleteContact/{id}: Delete an existing contact by ID.
GET /api/Contacts/ReadContactsById/{id}: Retrieve a specific contact by ID.
GET /api/Contact/ReadAllContacts: Retrieve a list of all your contacts.

The Connection String to connect our app with the PostgreSQL can be set up using the environment variables or alternatively, you can also configure the database connection settings in an appsettings.json or appsettings.Development.json file. 
"ConnectionStrings": {
    "Ef_Postgres_Db": "PUT YOUR CONNECTION STRING HERE;"
  }


Contact Entity
A contact in the Contact Manager API is represented with the following properties and their respective requirements:

Salutation: The salutation of the contact. It must not be empty, must be longer than 2 characters, and can be changed.

Firstname: The first name of the contact. It must not be empty, must be longer than 2 characters, and can be changed.

Lastname: The last name of the contact. It must not be empty, must be longer than 2 characters, and can be changed.

Displayname: The display name of the contact. If empty, it is automatically filled with the combination of Salutation, FirstName, and LastName. It can be changed.

Birthdate: The birthdate of the contact. It can be empty and can be changed.

CreationTimestamp: The time when the contact was created. It cannot be changed.

LastChangeTimestamp: The time when the contact was last changed. It cannot be set.

NotifyHasBirthdaySoon: Describes if the contact's birthday is in the next 14 days. It cannot be set.

Email: The email address of the contact. It must not be empty, can be changed, and must be unique.

Phonenumber: The phone number of the contact. It can be empty and can be changed.