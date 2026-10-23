# Bank Management System

Desktop application for managing bank clients, accounts and transactions, built with C# and SQL Server.

## Features
- People and clients management
- Users management
- Account management
- Transactions (deposit, withdraw, transfer)
- Transaction logs

## Tech Stack
C# | WinForms | .NET Framework 4.8 | SQL Server | T-SQL | ADO.NET | Stored Procedures

## Architecture
Three-tier:
- **UI** | presentation layer
- **BLL** | business logic
- **DAL** | data access with stored procedures

## Getting Started
1. Clone the repo
```bash
git clone https://github.com/salmasaady27/Bank_System.git
```
2. Restore the database from `Bank/Database/BankDB.sql`
3. In `App.config`, change `Server=` if your SQL Server instance has a different name
4. Install the UI package (only if it was not restored automatically)
```bash
dotnet add package FastUI.WinForms
```
5. Open the `.sln` in Visual Studio, then press **F5**

## Author
**Salma Saady** | [GitHub](https://github.com/salmasaady27)