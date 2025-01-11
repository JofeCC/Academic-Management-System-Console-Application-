# Academic-Management-System-Console-Application-
Description

This project is a console-based academic management system designed to manage professors, students, and courses. It allows administrators to perform various operations such as adding, updating, searching, and deleting records for professors, students, and courses. The program is developed in C# and leverages structs to manage data for professors, students, and courses.

Features

Professor Management:

Add new professors with details such as ID, name, seniority, and disciplines.
Search and display professor details by ID.
Update professor records (seniority or add new disciplines).
Delete professor records from the system.
List all professors with their details.

Course Management:

Define courses with attributes like ID, title, hours, discipline, and prerequisites.
Check if professors are qualified to teach specific courses based on their disciplines.
Calculate weekly teaching hours based on total course hours.

Student Management:

Register students and track their completed courses.
Verify prerequisites and register students for courses.
Prevent students from registering for courses they have already completed.

Data Validation:

Robust input validation for integers, strings, and floats.
Yes/No validation for user prompts to ensure smooth navigation.

User-Friendly Interface:

Menu-driven navigation for professor-related operations.
Clear prompts and error messages to guide users through input.

Technology Stack

Language: C#
Environment: Console Application
Data Structures: Arrays and Structs

How It Works

The system uses static arrays to store data for up to:

25 professors
100 students
25 courses
Users interact with the system via a text-based menu to perform CRUD (Create, Read, Update, Delete) operations.
Data validation functions ensure that only valid inputs are accepted.
