# Expense Tracker CLI

A simple **Command-Line Interface (CLI) Expense Tracker** built with **C#**. This tool allows users to manage personal finances efficiently from the terminal.

## Features
-  **Add an expense** with description and amount
-  **Update an expense**
-  **View all expenses** in a structured format
-  **Delete an expense** by ID
-  **View total expenses** summary
-  **Filter expenses by month**
-  **Set a budget and get warnings when exceeded**
-  **Export expenses to CSV**
-  **Data persistence** using JSON

## Installation & Setup
### 1️⃣ Clone the Repository
```sh
git clone https://github.com/yourusername/ExpenseTrackerCLI.git
cd ExpenseTrackerCLI
```

### 2️⃣ Install Dependencies
Ensure you have .NET SDK installed. Then, install required packages:
```sh
dotnet restore
```

## Usage
Run the application using:
```sh
dotnet run -- <command> [options]
```

### Commands
#### ➕ Add an Expense
```sh
dotnet run -- add --description "Lunch" --amount 20
```
#### 🔄 Update an Expense
```sh
dotnet run -- update --id 1 --description "Dinner" --amount 25
```
#### 📄 List All Expenses
```sh
dotnet run -- list
```
#### ❌ Delete an Expense
```sh
dotnet run -- delete --id 1
```
#### 📊 View Summary
```sh
dotnet run -- summary
```
####  View Expenses for a Specific Month
```sh
dotnet run -- summary --month 8
```
#### 📂 Export to CSV
```sh
dotnet run -- export --format csv
```

## Development
To build the project:
```sh
dotnet build
```
To run tests:
```sh
dotnet test
```

## Project URL
For more details, visit the project page: [Expense Tracker](https://roadmap.sh/projects/expense-tracker)

## Contributing
Pull requests are welcome! For major changes, please open an issue first to discuss the proposed modifications.

## License
MIT License © 2025 Yana Makogon
