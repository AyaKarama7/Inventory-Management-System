# 🏭 Product & Inventory Management System

## Project Overview

The **Product & Inventory Management System** is a desktop application designed to streamline product cataloging and stock management for small to medium-sized businesses. Built with **C#**, **Windows Forms**, and **Entity Framework Core**, this solution offers a user-friendly interface for managing products, categories, and inventory levels with robust data integrity and validation.

---

## Key Features

- **Product Management**  
  - Create, view, update, and delete product records.
  - Associate products with categories and suppliers.

- **Category Management**  
  - Manage product categories for organized cataloging.
  - CRUD operations with validation to prevent orphaned records.

- **Inventory Tracking**  
  - Monitor stock levels in real time.
  - Automatically adjust quantities on product addition, sales, or returns.

- **Search & Filtering**  
  - Quick search by product name, or category.
  - Advanced filters for low-stock and out-of-stock items.

- **User Input Validation**  
  - Form-level checks ensure data correctness.
  - Error messages guide users to resolve invalid entries.


---

## Technologies Used

- **Language & Framework**: C#, .NET 5, Windows Forms  
- **ORM**: Entity Framework Core (Code-First)  
- **Data Querying**: LINQ  
- **Database**: SQL Server Express  
- **Development Tools**: Visual Studio 2022  

---
## Setup Instructions

1. **Prerequisites**  
   - .NET SDK  
   - SQL Server Express (or full edition)  
   - Visual Studio 2022 (any edition)

2. **Clone the Repository**  
   ```bash
   git clone https://github.com/your-username/inventory-system.git
   cd inventory-system
   ```

3. **Configure Database Connection**  
   - Open `App.config` in the `InventoryApp` project.  
   - Update the `DefaultConnection` string with your SQL Server instance details:
     ```xml
     <connectionStrings>
       <add name="DefaultConnection" connectionString="Server=YOUR_SERVER;Database=InventoryDB;Trusted_Connection=True;" providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```

4. **Apply Migrations & Seed Data**  
   - Open Package Manager Console in Visual Studio.  
   - Run:
     ```powershell
     Update-Database
     ```

5. **Run the Application**  
   - Press **F5** in Visual Studio or execute the compiled `.exe` in `bin/Debug`.

---

## Usage

- Launch the app and log in with the default **Admin** credentials to access all features.  
- Navigate between **Products**, **Categories**, and **Inventory** tabs.  
- Perform CRUD operations via the toolbar buttons or context menus.  
- Use the search box to locate specific products or categories quickly.


