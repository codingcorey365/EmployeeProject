using EmployeeProject.Models;

namespace EmployeeProject.ViewModels;

public class EmployeeViewModel
{

    public EmployeeViewModel()
    {
        Employees = new List<Employee>();
    }
    public IEnumerable<Employee> Employees { get; set; }
    public Employee? Employee { get; set; }

    //EmployeeID
    public int EmployeeId { get; set; }

    //Name
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }

    //Birthday
    public int BirthDay { get; set; }
    public int BirthMonth { get; set; }
    public int BirthYear { get; set; }

    //Age
    public int Age { get; set; }

    //Contact
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? HomeAddress { get; set; }

    //Current Position
    public string? EmployeeDepartment { get; set; }
    public int EmployeeTitle { get; set; }
    public int PayRate { get; set; }
    public int HoursWorked { get; set; }

}