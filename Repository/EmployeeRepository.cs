using Dapper;
using EmployeeProject.Interface;
using EmployeeProject.Models;
using System.Data;
using EmployeeProject.ViewModels;

namespace EmployeeProject.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    // Create encapsulation
    // This is a field
    private readonly IDbConnection _connection;

    // Constructor
    // sets field to be a private value
    public EmployeeRepository(IDbConnection connection)
    {
        _connection = connection;
    }


    /*--- CRUD OPERATIONS ---*/

    /*--- CREATE ---*/
    /*-------------*/
    /*------------*/
    
    public void CreateEmployee(Employee employeeToInsert)
    {
        _connection.Execute("INSERT INTO employees (FirstName, MiddleName, LastName) VALUES (@FirstName, @MiddleName, @LastName);", new { firstname = employeeToInsert.FirstName, middlename = employeeToInsert.MiddleName, lastname = employeeToInsert.LastName });
    }

    
    /*--- READ ---*/
    /*-----------*/
    /*----------*/
    public IEnumerable<Employee> GetAllEmployees()
    {
        return _connection.Query<Employee>("SELECT * FROM employees;");
    }

    public Employee GetEmployeeById(int id)
    {

        return _connection.QuerySingleOrDefault<Employee>("SELECT * FROM employees where EmployeeId = @id", new { id = id });
    }

    public Employee GetEmployeeViewModelById(int id)
    {

        return _connection.QuerySingleOrDefault<Employee>("SELECT * FROM employees where EmployeeId = @id", new { id = id });
    }

    /*--- UPDATE ---*/
    /*-------------*/
    /*------------*/
    public void UpdateEmployee(Employee employee)
    {
        _connection.Execute(@"UPDATE employees 
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

    public void UpdateEmployeeName(int employeeId, string updatedName)
    {
        _connection.Execute("Update employees set Name = @name where employeeId = @employeeId",
            new { name = updatedName, employeeId = employeeId });
    }


    /*--- DELETE ---*/
    /*-------------*/
    /*------------*/

    public void DeleteEmployee(Employee employee)
    {
        _connection.Execute("DELETE FROM EMPLOYEES WHERE EmployeeId = @id;", new { id = employee.EmployeeId });
    }
}