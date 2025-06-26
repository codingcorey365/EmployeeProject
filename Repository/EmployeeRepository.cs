using Dapper; // For simplified data access
using EmployeeProject.Interface; // To implement repository interface
using EmployeeProject.Models; // For employee model definitions
using System.Data; // For database connection interface

namespace EmployeeProject.Repository
{
    // Repository class for employee CRUD operations
    public class EmployeeRepository : IEmployeeRepository
    {
        /*--- FIELDS AND CONSTRUCTOR ---*/

        // Field to store database connection, encapsulated with readonly modifier
        private readonly IDbConnection _connection;

        // Constructor to initialize the database connection via dependency injection
        public EmployeeRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        /*--- CRUD OPERATIONS ---*/

        /*--- CREATE ---*/

        /// <summary>
        /// Inserts a new employee record into the database.
        /// </summary>
        /// <param name="employeeToInsert">Employee object with details to be inserted</param>
        public void CreateEmployee(Employee employeeToInsert)
        {
            _connection.Execute(
                @"INSERT INTO employees (
                                                FirstName,
                                                MiddleName,
                                                LastName,
                                                BirthDay,
                                                BirthMonth,
                                                BirthYear,
                                                Age,
                                                PhoneNumber,
                                                EmailAddress,
                                                HomeAddress,
                                                EmployeeDepartment,
                                                EmployeeTitle,
                                                PayRate,
                                                HoursWorked
                                            ) VALUES (
                                                @FirstName,
                                                @MiddleName,
                                                @LastName,
                                                @BirthDay,
                                                @BirthMonth,
                                                @BirthYear,
                                                @Age,
                                                @PhoneNumber,
                                                @EmailAddress,
                                                @HomeAddress,
                                                @EmployeeDepartment,
                                                @EmployeeTitle,
                                                @PayRate,
                                                @HoursWorked
                                            );",
                new
                {
                    FirstName = employeeToInsert.FirstName,
                    MiddleName = employeeToInsert.MiddleName,
                    LastName = employeeToInsert.LastName,
                    BirthDay = employeeToInsert.BirthDay,
                    BirthMonth = employeeToInsert.BirthMonth,
                    BirthYear = employeeToInsert.BirthYear,
                    Age = employeeToInsert.Age,
                    PhoneNumber = employeeToInsert.PhoneNumber,
                    EmailAddress = employeeToInsert.EmailAddress,
                    HomeAddress = employeeToInsert.HomeAddress,
                    EmployeeDepartment = employeeToInsert.EmployeeDepartment,
                    EmployeeTitle = employeeToInsert.EmployeeTitle,
                    PayRate = employeeToInsert.PayRate,
                    HoursWorked = employeeToInsert.HoursWorked
                });
        }

        /*--- READ ---*/

        /// <summary>
        /// Retrieves all employee records from the database.
        /// </summary>
        /// <returns>A collection of Employee objects</returns>
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _connection.Query<Employee>("SELECT * FROM employees;");
        }

        /// <summary>
        /// Retrieves a single employee by their unique ID.
        /// </summary>
        /// <param name="id">Employee's unique ID</param>
        /// <returns>Employee object if found; otherwise null</returns>
        public Employee GetEmployeeById(int id)
        {
            return _connection.QuerySingleOrDefault<Employee>(
                "SELECT * FROM employees WHERE EmployeeId = @id", new { id });
        }

        /// <summary>
        /// Retrieves an employee as a
        /// model by their unique ID.
        /// </summary>
        /// <param name="id">Employee's unique ID</param>
        /// <returns>Employee view model object if found; otherwise null</returns>
        public Employee GetEmployeeViewModelById(int id)
        {
            return _connection.QuerySingleOrDefault<Employee>(
                "SELECT * FROM employees WHERE EmployeeId = @id", new { id });
        }

        /*--- UPDATE ---*/

        /// <summary>
        /// Updates the full details of an existing employee record in the database.
        /// </summary>
        /// <param name="employee">Employee object containing updated information</param>
        public void UpdateEmployee(Employee employee)
        {
            _connection.Execute(
                @"UPDATE employees 
                  SET FirstName = @FirstName, 
                      MiddleName = @MiddleName, 
                      LastName = @LastName, 
                      BirthDay = @BirthDay, 
                      BirthMonth = @BirthMonth, 
                      BirthYear = @BirthYear, 
                      Age = @Age, 
                      PhoneNumber = @PhoneNumber, 
                      EmailAddress = @EmailAddress, 
                      HomeAddress = @HomeAddress, 
                      EmployeeDepartment = @EmployeeDepartment, 
                      EmployeeTitle = @EmployeeTitle, 
                      PayRate = @PayRate, 
                      HoursWorked = @HoursWorked 
                  WHERE EmployeeId = @EmployeeId",
                new
                {
                    employee.FirstName,
                    employee.MiddleName,
                    employee.LastName,
                    employee.BirthDay,
                    employee.BirthMonth,
                    employee.BirthYear,
                    employee.Age,
                    employee.PhoneNumber,
                    employee.EmailAddress,
                    employee.HomeAddress,
                    employee.EmployeeDepartment,
                    employee.EmployeeTitle,
                    employee.PayRate,
                    employee.HoursWorked,
                    employee.EmployeeId
                });
        }

        /// <summary>
        /// Updates only the name of an existing employee.
        /// </summary>
        /// <param name="employeeId">Employee's unique ID</param>
        /// <param name="updatedName">New name for the employee</param>
        public void UpdateEmployeeName(int employeeId, string updatedName)
        {
            _connection.Execute(
                "UPDATE employees SET Name = @name WHERE EmployeeId = @employeeId",
                new { name = updatedName, employeeId });
        }

        /*--- DELETE ---*/

        /// <summary>
        /// Deletes an employee record from the database.
        /// </summary>
        /// <param name="employee">Employee object with ID of the record to delete</param>
        public void DeleteEmployee(Employee employee)
        {
            _connection.Execute(
                "DELETE FROM employees WHERE EmployeeId = @id;",
                new { id = employee.EmployeeId });
        }
    }
}
