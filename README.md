# Library Management System – C# Console Application
## Assignment Description
This project is a C# console application for managing a library system of books and subscribers. The goal was to apply object-oriented programming principles and appropriate data structures to manage dynamic collections of books and users. The project includes robust input validation using try/catch and TryParse.

## Key Features Implemented
### Book Management

Each book has a unique numeric ID, along with title, author, and number of available copies.

Books are stored in a structure optimized for fast lookup by ID.

Prevents duplicate IDs and validates all book data on input.

Supports checking availability and updating the number of copies upon loan/return.

### Subscriber Management

Each subscriber is uniquely identified by their national ID number.

Maintains a list of books currently loaned to each subscriber using an appropriate data structure (e.g., list or dictionary).

Subscribers can borrow up to 3 books at a time.

### Loan and Return System

When borrowing a book:

The program checks if the subscriber has reached their borrowing limit.

Validates book availability (at least one copy free).

Allows selection when multiple books have the same title but different IDs.

When returning a book:

Confirms the subscriber actually borrowed the specified book.

Updates both the subscriber’s record and the book’s available copies.

### Display Options

Allows listing all books loaned to a specific subscriber.

Can show book information by ID or by title.

Clearly outputs results and errors using structured console messages.

### User Interaction via Menu

Implemented a user-friendly menu system.

Uses an optional enum for action selection combined with a switch statement to manage operations.

## Technical Highlights
Input validation using try-catch and TryParse.

Efficient data handling using dictionaries and lists.

Use of classes to represent books and subscribers.

Designed for clarity, scalability, and ease of use.
