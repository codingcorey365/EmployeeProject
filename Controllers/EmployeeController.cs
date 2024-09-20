using EmployeeProject.Interface;
using EmployeeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProject.Controllers
{
    public class EmployeeController : Controller
    {
        // Dependency Injection Employee Repository
        private readonly IEmployeeInterface _repo;

        // Constructor to set the connection to private
        public EmployeeController(IEmployeeInterface repo)
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
        public IActionResult GetAllEmployees()
        {
            var employees = _repo.GetAllEmployees();
            return View(employees);
        }

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


