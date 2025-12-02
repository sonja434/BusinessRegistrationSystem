# Business Registration System

## Description

A full-stack web application for registering companies in Serbia. The system allows users to submit registration requests, track the status of their applications, receive notifications via email when statuses change, and view detailed information about different company types and required steps. Admin users can approve requests, provide feedback, and maintain historical records of all registration processes.

## Technologies

* **Frontend:** Angular, JavaScript, HTML/CSS
* **Backend:** C#, .NET Core, Entity Framework
* **Database:** PostgreSQL
* **Other Tools:** REST APIs, Git/GitHub
* **Development Practices:** OOP, MVC Architecture, Agile methodology

## Role

Full-Stack Developer – responsible for implementing both frontend and backend, including user registration and login, multi-step registration requests, admin approval workflows, email notifications, status tracking, and database management.

## Features

* User registration and login
* Multi-step company registration requests
* Status tracking and email notifications for users
* Admin dashboard for approving requests and providing feedback
* Historical record of all registration requests
* Viewing all types of companies and required steps
* Viewing all business activity codes categorized by type

## How to Run

### Prerequisites

* .NET SDK (e.g., 7.0)
* Node.js & npm
* Angular CLI (version 20.3.1)
* PostgreSQL
* Optional: Visual Studio / VS Code

### Backend

1. Open a terminal and navigate to the backend folder:

   ```bash
   cd backend
   ```
2. Restore dependencies:

   ```bash
   dotnet restore
   ```
3. Configure the database connection string in `appsettings.json`:

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=YourDB;Username=YourUser;Password=YourPassword"
   }
   ```
4. Apply database migrations:

   ```bash
   dotnet ef database update
   ```
5. Run the backend:

   ```bash
   dotnet run
   ```

   The backend server will start at `https://localhost:5001`

### Frontend

1. Open a terminal and navigate to the frontend folder:

   ```bash
   cd BusinessRegistrationClient
   ```
2. Install dependencies:

   ```bash
   npm install
   ```
3. Start the Angular development server:

   ```bash
   ng serve
   ```

   Open your browser at `http://localhost:4200/`. The app reloads automatically on source file changes.

### Optional Commands

* **Build production:** `ng build` → outputs build artifacts in `dist/`
* **Generate component:** `ng generate component component-name`
* **Unit tests:** `ng test`
* **End-to-end tests:** `ng e2e`

> ⚠ Make sure the backend server is running before starting the frontend.

# Screenshot
