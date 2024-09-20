using EmployeeProject.Models;

namespace EmployeeProject.Interface;

public interface IEmployeeInterface
{
    public void CreateEmployee(Employee employeeToInsert);
    public Employee GetEmployeeById(int id);
    public IEnumerable<Employee> GetAllEmployees();
    public void UpdateEmployee(Employee employee);
    public void DeleteEmployee(Employee employee);
}