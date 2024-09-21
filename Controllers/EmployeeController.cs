using EmployeeProject.Interface;
using EmployeeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProject.Controllers
{
    public class EmployeeController : Controller
    {
        // Dependency Injection Employee Repository
        private readonly IEmployeeRepository _repo;

        // Constructor to set the connection to private
        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        // Index
        public IActionResult Index()
        {

            return View();
        }

        /*--- CRUD OPERATIONS ---* /

        /*--- CREATE ---*/
        /*-------------*/
        /*------------*/

        // View Insert Employee
        public IActionResult InsertEmployee()
        {
            return View();
        }

        // Add Employee to Database
        public IActionResult InsertEmployeeToDatabase(Employee employeeToInsert)
        {
            _repo.CreateEmployee(employeeToInsert);

            return RedirectToAction("GetAllEmployees");
        }

        /*--- READ ---*/
        /*-----------*/
        /*----------*/

        // Get All Employees

        public IActionResult GetAllEmployees(string searchString)
        {
            var employees = _repo.GetAllEmployees();

            // Apply search filter if searchString is provided
            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e =>
                        e.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                        e.MiddleName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                        e.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                        e.BirthDay.ToString().Contains(searchString) ||
                        e.BirthMonth.ToString().Contains(searchString) ||
                        e.BirthYear.ToString().Contains(searchString) ||
                        e.Age.ToString().Contains(searchString) ||
                        e.PhoneNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                        e.EmailAddress.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                        e.HomeAddress.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                        e.EmployeeDepartment.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                        e.EmployeeTitle.ToString().Contains(searchString) ||
                        e.PayRate.ToString().Contains(searchString) ||
                        e.HoursWorked.ToString().Contains(searchString))
                    .ToList();
                
              

            }

            return View(employees);
        }

        //public IActionResult GetAllEmployees()
        //{
        //    var employees = _repo.GetAllEmployees();
        //    return View(employees);
        //}

        // View A Single Employee
        public IActionResult ViewSingleEmployee(int id)
        {
            var employee = _repo.GetEmployeeById(id);
            return View(employee);
        }

        /*--- UPDATE ---*/
        /*-------------*/
        /*------------*/

        public IActionResult UpdateEmployee(int id)
        {
            Employee test = _repo.GetEmployeeById(id);
            return View(test);
        }


        public IActionResult UpdateEmployeeToDatabase(Employee employee)
        {
            _repo.UpdateEmployee(employee);

            return RedirectToAction("ViewSingleEmployee", new { id = employee.EmployeeId });
        }

        /*--- DELETE ---*/
        /*-------------*/
        /*------------*/

        public IActionResult DeleteEmployee(Employee employee)
        {
            _repo.DeleteEmployee(employee);
            return RedirectToAction("GetAllEmployees");
        }
    }
}


