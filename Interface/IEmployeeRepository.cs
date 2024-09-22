using EmployeeProject.Models;
using EmployeeProject.ViewModels;
using System.Data.Common;

namespace EmployeeProject.Interface;

public interface IEmployeeRepository
{
    public void CreateEmployee(Employee employeeToInsert);
    public Employee GetEmployeeById(int id);
    public IEnumerable<Employee> GetAllEmployees();
    public void UpdateEmployee(Employee employee);
    public void DeleteEmployee(Employee employee);
    public Employee GetEmployeeViewModelById(int id);

}