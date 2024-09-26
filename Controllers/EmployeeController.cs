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

       

        public IActionResult GetAllEmployees(string searchString, string sortOrder)
        {
            ViewBag.IdSortParm = sortOrder == "id_asc" ? "id_desc" : "id_asc";
            
            var employees = _repo.GetAllEmployees();


            // If a search string is provided, filter employees
            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees
                    .Where(e => IsMatch(e, searchString))
                    .ToList();
            }

            // Sort by column
            employees = sortOrder switch
            {
                "name_asc" => employees.OrderBy(e => e.FirstName).ToList(),
                "name_desc" => employees.OrderByDescending(e => e.FirstName).ToList(),
                "id_asc" => employees.OrderBy(e => e.EmployeeId).ToList(),
                "id_desc" => employees.OrderByDescending(e => e.EmployeeId).ToList(),
                "age_asc" => employees.OrderBy(e => e.Age).ToList(),
                "age_desc" => employees.OrderByDescending(e => e.Age).ToList(),
                _ => employees.OrderBy(e => e.FirstName).ToList(), // Default sorting
            };


            return View(employees);
        }

        private bool IsMatch(Employee e, string searchString)
        {
            var search = searchString.Trim().ToLower();

            return MatchesName(e, search) ||
                   MatchesBirthday(e, search) ||
                   MatchesContactInfo(e, search) ||
                   MatchesEmployeeInfo(e, search);
        }

        private bool MatchesName(Employee e, string searchString)
        {
            return (!string.IsNullOrEmpty(e.FirstName) && e.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                   (!string.IsNullOrEmpty(e.MiddleName) && e.MiddleName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                   (!string.IsNullOrEmpty(e.LastName) && e.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        }

        private bool MatchesBirthday(Employee e, string searchString)
        {
            return e.BirthDay.ToString().Contains(searchString) ||
                   e.BirthMonth.ToString().Contains(searchString) ||
                   e.BirthYear.ToString().Contains(searchString) ||
                   e.Age.ToString().Contains(searchString);
        }

        private bool MatchesContactInfo(Employee e, string searchString)
        {
            return (!string.IsNullOrEmpty(e.PhoneNumber) && e.PhoneNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                   (!string.IsNullOrEmpty(e.EmailAddress) && e.EmailAddress.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                   (!string.IsNullOrEmpty(e.HomeAddress) && e.HomeAddress.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        }

        private bool MatchesEmployeeInfo(Employee e, string searchString)
        {
            return (!string.IsNullOrEmpty(e.EmployeeDepartment) && e.EmployeeDepartment.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                   e.EmployeeTitle.ToString().Contains(searchString) ||
                   e.PayRate.ToString().Contains(searchString) ||
                   e.HoursWorked.ToString().Contains(searchString);
        }


        public IActionResult ViewSingleEmployeeById(int id)
        {
            // Example: Fetch the list of employees from a repository or database
            var employees = _repo.GetAllEmployees().ToList();

            // Example: Fetch a single employee (e.g., by ID or other criteria)
            var employee = employees.FirstOrDefault(x => x.EmployeeId == id);



            // Pass the ViewModel to the view
            return View();
        }


        //public IActionResult GetAllEmployees()
        //{
        //    var employees = _repo.GetAllEmployees();
        //    return View(employees);
        //}

         /*View A Single Employee*/
        public IActionResult ViewSingleEmployee(int id)
        {
            var employee = _repo.GetEmployeeById(id);
            return View(employee);
        }

        /*public IActionResult ViewSingleEmployee(int id)
        {
            var employee = _repo.GetEmployeeById(id);
            return View(employee);
        }*/

        /*--- UPDATE ---
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


