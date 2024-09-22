using EmployeeProject.Interface;
using EmployeeProject.Models;
using EmployeeProject.Repository;
using EmployeeProject.ViewModels;
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
        //public IActionResult Index()
        //{

        //    return View();
        //}

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
                //employees = employees.Where(e =>
                //        e.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                //        e.MiddleName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                //        e.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                //        e.BirthDay.ToString().Contains(searchString) ||
                //        e.BirthMonth.ToString().Contains(searchString) ||
                //        e.BirthYear.ToString().Contains(searchString) ||
                //        e.Age.ToString().Contains(searchString) ||
                //        e.PhoneNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                //        e.EmailAddress.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                //        e.HomeAddress.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                //        e.EmployeeDepartment.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                //        e.EmployeeTitle.ToString().Contains(searchString) ||
                //        e.PayRate.ToString().Contains(searchString) ||
                //        e.HoursWorked.ToString().Contains(searchString))
                employees = employees.Where(e =>
                    (!string.IsNullOrEmpty(e.FirstName) && e.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(e.MiddleName) && e.MiddleName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(e.LastName) && e.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                    (e.BirthDay != null && e.BirthDay.ToString().Contains(searchString)) ||
                    (e.BirthMonth != null && e.BirthMonth.ToString().Contains(searchString)) ||
                    (e.BirthYear != null && e.BirthYear.ToString().Contains(searchString)) ||
                    (e.Age != null && e.Age.ToString().Contains(searchString)) ||
                    (!string.IsNullOrEmpty(e.PhoneNumber) && e.PhoneNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(e.EmailAddress) && e.EmailAddress.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(e.HomeAddress) && e.HomeAddress.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(e.EmployeeDepartment) && e.EmployeeDepartment.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                    (e.EmployeeTitle.ToString().Contains(searchString)) ||
                    (e.PayRate != null && e.PayRate.ToString().Contains(searchString)) ||
                    (e.HoursWorked != null && e.HoursWorked.ToString().Contains(searchString))
                    ).ToList();
            }
            else
            {
                
            }
            
            return View(employees);
        }

        public IActionResult ViewSingleEmployeeById(int id)
        {
            // Example: Fetch the list of employees from a repository or database
            var employees = _repo.GetAllEmployees();

            // Example: Fetch a single employee (e.g., by ID or other criteria)
            var employee = _repo.GetEmployeeById(id);

            // Create the ViewModel
            var viewModel = new EmployeeViewModel
            {
                Employees = employees,
                Employee = employee
            };

            // Pass the ViewModel to the view
            return View(viewModel);
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

        //public IActionResult ViewSingleEmployee(int id)
        //{
        //    var employee = _repo.GetEmployeeById(id);
        //    return View(employee);
        //}

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


