# Employee Management System

## 📖 Project Overview

The **Employee Management System** is a comprehensive ASP.NET Core MVC web application designed to demonstrate full CRUD (Create, Read, Update, Delete) functionality for managing employee records. This project showcases modern web development practices, data validation, and database integration using MySQL and Dapper ORM.

### 🎯 Project Scope

This application serves as a practical demonstration of:
- **Full CRUD Operations**: Complete employee lifecycle management
- **Data Validation**: Comprehensive input validation with regex patterns and custom error messages
- **Repository Pattern**: Clean separation of data access logic
- **MVC Architecture**: Model-View-Controller design pattern implementation
- **Database Integration**: MySQL database connectivity using Dapper ORM
- **Responsive UI**: Bootstrap-styled user interface

**Note**: While the database includes models for Sales and Products, these are not fully integrated into the current application. They serve as examples of additional functionality that could be implemented using the same patterns demonstrated with the Employee model.

## 🏗️ Architecture

### Tech Stack
- **Framework**: ASP.NET Core 8.0 (MVC)
- **Database**: MySQL
- **ORM**: Dapper 2.1.35
- **Frontend**: HTML5, CSS3, Bootstrap, JavaScript
- **Validation**: Data Annotations with custom regex patterns

### Project Structure
```
EmployeeProject/
├── Controllers/
│   ├── EmployeeController.cs    # Employee CRUD operations
│   └── HomeController.cs        # Home page controller
├── Models/
│   ├── Employee.cs              # Employee model with validation
│   └── ErrorViewModel.cs        # Error handling model
├── Views/
│   ├── Employee/
│   │   ├── GetAllEmployees.cshtml    # Employee list with search/sort
│   │   ├── InsertEmployee.cshtml     # Create new employee
│   │   ├── UpdateEmployee.cshtml     # Edit employee
│   │   └── ViewSingleEmployee.cshtml # Employee details
│   ├── Home/
│   └── Shared/
├── Repository/
│   └── EmployeeRepository.cs    # Data access layer
├── Interface/
│   └── IEmployeeRepository.cs   # Repository contract
├── Database/                    # Database scripts (if any)
└── wwwroot/                    # Static files (CSS, JS, images)
```

## 🚀 Features

### Core Functionality
- **Employee Management**
  - ✅ Create new employee records
  - ✅ View all employees with search and sorting
  - ✅ View individual employee details
  - ✅ Update employee information
  - ✅ Delete employee records

### Data Validation
- **Name Fields**: Letters and spaces only, 2-35 characters
- **Email**: Must end with `.com` and follow standard email format
- **Phone**: US format validation (123-456-7890 or (123) 456-7890)
- **Birth Date**: Valid day (1-31), month (1-12), year (1900-2100)
- **Age**: Realistic range (0-130)
- **Pay Rate**: Valid USD format with appropriate range
- **Hours Worked**: 0-168 hours (maximum week)

### User Interface
- **Responsive Design**: Bootstrap-based responsive layout
- **Search Functionality**: Filter employees by multiple criteria
- **Sorting**: Sort by any column (ascending/descending)
- **Form Validation**: Real-time client and server-side validation
- **User Feedback**: Clear error messages and success notifications

## 🛠️ Installation & Setup

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (8.0 or later)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/downloads)

### Step 1: Clone the Repository
```bash
git clone <repository-url>
cd EmployeeProject
```

### Step 2: Database Setup
1. **Install MySQL Server** and ensure it's running on port 3306
2. **Create Database**: Create a database named `finalproject`
   ```sql
   CREATE DATABASE finalproject;
   ```
3. **Create Employee Table**: 
   ```sql
   USE finalproject;
   
   CREATE TABLE employees (
       EmployeeId INT AUTO_INCREMENT PRIMARY KEY,
       FirstName VARCHAR(35) NOT NULL,
       MiddleName VARCHAR(35),
       LastName VARCHAR(35) NOT NULL,
       BirthDay INT NOT NULL,
       BirthMonth INT NOT NULL,
       BirthYear INT NOT NULL,
       Age INT NOT NULL,
       PhoneNumber VARCHAR(20),
       EmailAddress VARCHAR(100) NOT NULL,
       HomeAddress VARCHAR(100),
       EmployeeDepartment VARCHAR(50) NOT NULL,
       EmployeeTitle INT NOT NULL,
       PayRate VARCHAR(15) NOT NULL,
       HoursWorked INT NOT NULL DEFAULT 0
   );
   ```

### Step 3: Configure Connection String
1. Open `appsettings.json`
2. Update the connection string with your MySQL credentials:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=finalproject;uid=root;Pwd=YOUR_PASSWORD;Port=3306;"
     }
   }
   ```

### Step 4: Install Dependencies
```bash
dotnet restore
```

### Step 5: Build the Project
```bash
dotnet build
```

## 🏃‍♂️ Running the Application

### Development Environment
```bash
dotnet run
```

The application will be available at:
- **HTTP**: `http://localhost:5169`
- **HTTPS**: `https://localhost:7169` (if configured)

### Production Deployment
```bash
dotnet publish -c Release -o ./publish
```

## 📱 Usage Guide

### Creating a New Employee
1. Navigate to **Employee** > **Create New Employee**
2. Fill in all required fields (marked with *)
3. Ensure email ends with `.com`
4. Use valid phone format: `123-456-7890`
5. Click **Create Employee**

### Viewing Employees
1. Go to **Employee** > **View All Employees**
2. Use the search box to filter results
3. Click column headers to sort
4. Click **View Details** to see individual employee information

### Updating Employee Information
1. From the employee list, click **Edit**
2. Modify the desired fields
3. Click **Update Employee**

### Deleting Employees
1. From the employee list, click **Delete**
2. Confirm the deletion

## 🔧 Configuration

### Database Configuration
- **Connection String**: Configured in `appsettings.json`
- **Database Provider**: MySQL with Dapper ORM
- **Connection Pooling**: Enabled by default

### Validation Rules
All validation rules are defined in the `Employee.cs` model using Data Annotations:
- Email regex: `^[^@\s]+@[^@\s]+\.(com)$`
- Phone regex: `^(\(\d{3}\)\s?|\d{3}[-.])?\d{3}[-.]\d{4}$`
- Name validation: Letters and spaces only

## 🧪 Testing

### Manual Testing
1. **Form Validation**: Try submitting forms with invalid data
2. **CRUD Operations**: Test all create, read, update, delete functions
3. **Search & Sort**: Verify filtering and sorting functionality
4. **Responsive Design**: Test on different screen sizes

### Test Data
Sample employee data for testing:
```json
{
  "FirstName": "John",
  "LastName": "Doe",
  "BirthDay": 15,
  "BirthMonth": 6,
  "BirthYear": 1990,
  "Age": 34,
  "PhoneNumber": "555-123-4567",
  "EmailAddress": "john.doe@company.com",
  "HomeAddress": "123 Main St, Anytown, ST 12345",
  "EmployeeDepartment": "Information Technology",
  "EmployeeTitle": 2,
  "PayRate": "$25.50",
  "HoursWorked": 40
}
```

## 🚧 Known Issues & Future Enhancements

### Current Limitations
- Sales and Products models are not integrated
- No user authentication/authorization
- No audit trail for changes
- Limited reporting capabilities

### Planned Enhancements
- [ ] Integrate Sales and Products functionality
- [ ] Add user authentication
- [ ] Implement role-based access control
- [ ] Add employee photo upload
- [ ] Generate reports (PDF/Excel)
- [ ] Add bulk operations
- [ ] Implement audit logging
- [ ] Add API endpoints
- [ ] Unit and integration tests

## 🤝 Contributing

This project is part of a learning module. If you'd like to contribute:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is created for educational purposes as part of TrueCoders Module 16.

## 📞 Support

For questions or issues:
- Create an issue in the repository
- Contact the development team

---

**Built with ❤️ for TrueCoders Module 16 - Demonstrating ASP.NET Core MVC and CRUD Operations**