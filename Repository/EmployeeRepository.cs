﻿using Dapper;
using EmployeeProject.Interface;
using EmployeeProject.Models;
using System.Data;

namespace EmployeeProject.Repository;

public class EmployeeRepository : IEmployeeInterface
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

        return _connection.QuerySingle<Employee>("SELECT * FROM employees where EmployeeId = @id", new { id = id });
    }


    /*--- UPDATE ---*/
    /*-------------*/
    /*------------*/
    public void UpdateEmployee(Employee employee)
    {
        _connection.Execute("Update employees set FirstName = @FirstName where EmployeeId = @EmployeeId",
            new { FirstName = employee.FirstName, EmployeeId = employee.EmployeeId });
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