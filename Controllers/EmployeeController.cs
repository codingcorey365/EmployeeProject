using EmployeeProject.Interface; // Interface for employee repository
using EmployeeProject.Models; // Employee model definitions
using Microsoft.AspNetCore.Mvc; // MVC framework components

namespace EmployeeProject.Controllers
{
    // Controller for managing employee-related actions
    public class EmployeeController : Controller
    {
        // Field for dependency injection of employee repository
        private readonly IEmployeeRepository _repo;

        // Constructor that injects the repository dependency
        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        // Default Index action, currently returns a blank view
        public IActionResult Index()
        {
            return View();
        }


        /* --- CREATE --- */

        // Displays the form to insert a new employee
        public IActionResult InsertEmployee()
        {
            return View();
        }

        [HttpPost]
        // Adds a new employee to the database and redirects to GetAllEmployees view
        public IActionResult InsertEmployeeToDatabase(Employee employeeToInsert)
        {
            _repo.CreateEmployee(employeeToInsert);
            return RedirectToAction("GetAllEmployees");

            //if (ModelState.IsValid)
            //{
            //    _repo.CreateEmployee(employeeToInsert);
            //    return RedirectToAction("GetAllEmployees");
            //}
            //else
            //{
            //    ViewData["ErrorMessage"] = "Please fill in all required fields.";
            //    return View("InsertEmployee", employeeToInsert);
            //}
        }

        /* --- READ --- */

        // Retrieves and displays a list of all employees, with optional search and sorting
        public IActionResult GetAllEmployees(string searchString, string sortOrder)
        {
            // Define sorting parameters for each column
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) || sortOrder == "id_asc" ? "id_desc" : "id_asc";
            ViewBag.FirstNameSortParm = sortOrder == "firstName_asc" ? "firstName_desc" : "firstName_asc";
            ViewBag.MiddleNameSortParm = sortOrder == "middleName_asc" ? "middleName_desc" : "middleName_asc";
            ViewBag.LastNameSortParm = sortOrder == "lastName_asc" ? "lastName_desc" : "lastName_asc";
            ViewBag.BirthMonthSortParm = sortOrder == "birthMonth_asc" ? "birthMonth_desc" : "birthMonth_asc";
            ViewBag.BirthDaySortParm = sortOrder == "birthDay_asc" ? "birthDay_desc" : "birthDay_asc";
            ViewBag.BirthYearSortParm = sortOrder == "birthYear_asc" ? "birthYear_desc" : "birthYear_asc";
            ViewBag.AgeSortParm = sortOrder == "age_asc" ? "age_desc" : "age_asc";
            ViewBag.PhoneNumberSortParm = sortOrder == "phoneNumber_asc" ? "phoneNumber_desc" : "phoneNumber_asc";
            ViewBag.EmailAddressSortParm = sortOrder == "emailAddress_asc" ? "emailAddress_desc" : "emailAddress_asc";
            ViewBag.HomeAddressSortParm = sortOrder == "homeAddress_asc" ? "homeAddress_desc" : "homeAddress_asc";
            ViewBag.PayRateSortParm = sortOrder == "payRate_asc" ? "payRate_desc" : "payRate_asc";
            ViewBag.DepartmentSortParm = sortOrder == "department_asc" ? "department_desc" : "department_asc";
            ViewBag.HoursWorkedSortParm = sortOrder == "hoursWorked_asc" ? "hoursWorked_desc" : "hoursWorked_asc";

            // Retrieve all employees from repository
            var employees = _repo.GetAllEmployees();

            // Filter employees based on search string if provided
            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => IsMatch(e, searchString)).ToList();
            }

            // Sort employees based on selected sorting option
            employees = sortOrder switch
            {
                "id_desc" => employees.OrderByDescending(e => e.EmployeeId).ToList(),
                "id_asc" => employees.OrderBy(e => e.EmployeeId).ToList(),
                "firstName_desc" => employees.OrderByDescending(e => e.FirstName).ToList(),
                "firstName_asc" => employees.OrderBy(e => e.FirstName).ToList(),
                "middleName_asc" => employees.OrderByDescending(e => e.MiddleName).ToList(),
                "middleName_desc" => employees.OrderBy(e => e.MiddleName).ToList(),
                "lastName_desc" => employees.OrderByDescending(e => e.LastName).ToList(),
                "lastName_asc" => employees.OrderBy(e => e.LastName).ToList(),
                "birthMonth_desc" => employees.OrderByDescending(e => e.BirthMonth).ToList(),
                "birthMonth_asc" => employees.OrderBy(e => e.BirthMonth).ToList(),
                "birthDay_desc" => employees.OrderByDescending(e => e.BirthDay).ToList(),
                "birthDay_asc" => employees.OrderBy(e => e.BirthDay).ToList(),
                "birthYear_desc" => employees.OrderByDescending(e => e.BirthYear).ToList(),
                "birthYear_asc" => employees.OrderBy(e => e.BirthYear).ToList(),
                "age_desc" => employees.OrderByDescending(e => e.Age).ToList(),
                "age_asc" => employees.OrderBy(e => e.Age).ToList(),
                "phoneNumber_desc" => employees.OrderByDescending(e => e.PhoneNumber).ToList(),
                "phoneNumber_asc" => employees.OrderBy(e => e.PhoneNumber).ToList(),
                "emailAddress_desc" => employees.OrderByDescending(e => e.EmailAddress).ToList(),
                "emailAddress_asc" => employees.OrderBy(e => e.EmailAddress).ToList(),
                "homeAddress_desc" => employees.OrderByDescending(e => e.HomeAddress).ToList(),
                "homeAddress_asc" => employees.OrderBy(e => e.HomeAddress).ToList(),
                "payRate_desc" => employees.OrderByDescending(e => e.PayRate).ToList(),
                "payRate_asc" => employees.OrderBy(e => e.PayRate).ToList(),
                "department_desc" => employees.OrderByDescending(e => e.EmployeeDepartment).ToList(),
                "department_asc" => employees.OrderBy(e => e.EmployeeDepartment).ToList(),
                "hoursWorked_desc" => employees.OrderByDescending(e => e.HoursWorked).ToList(),
                "hoursWorked_asc" => employees.OrderBy(e => e.HoursWorked).ToList(),
                _ => employees.OrderBy(e => e.EmployeeId).ToList() // Default sorting
            };

            return View(employees); // Return the sorted and filtered list to the view
        }

        // Helper method to check if employee matches search criteria
        private bool IsMatch(Employee e, string searchString)
        {
            var search = searchString.Trim().ToLower();

            return MatchesName(e, search) ||
                   MatchesBirthday(e, search) ||
                   MatchesContactInfo(e, search) ||
                   MatchesEmployeeInfo(e, search);
        }

        // Helper method to check if name matches search
        private bool MatchesName(Employee e, string searchString)
        {
            return (!string.IsNullOrEmpty(e.FirstName) &&
                    e.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                   (!string.IsNullOrEmpty(e.MiddleName) &&
                    e.MiddleName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                   (!string.IsNullOrEmpty(e.LastName) &&
                    e.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        }

        // Helper method to check if birth details match search
        private bool MatchesBirthday(Employee e, string searchString)
        {
            return e.BirthDay.ToString().Contains(searchString) ||
                   e.BirthMonth.ToString().Contains(searchString) ||
                   e.BirthYear.ToString().Contains(searchString) ||
                   e.Age.ToString().Contains(searchString);
        }

        // Helper method to check if contact info matches search
        private bool MatchesContactInfo(Employee e, string searchString)
        {
            return (!string.IsNullOrEmpty(e.PhoneNumber) &&
                    e.PhoneNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                   (!string.IsNullOrEmpty(e.EmailAddress) &&
                    e.EmailAddress.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                   (!string.IsNullOrEmpty(e.HomeAddress) &&
                    e.HomeAddress.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        }

        // Helper method to check if employee department or title matches search
        private bool MatchesEmployeeInfo(Employee e, string searchString)
        {
            return (!string.IsNullOrEmpty(e.EmployeeDepartment) &&
                    e.EmployeeDepartment.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                   e.EmployeeTitle.ToString().Contains(searchString) ||
                   e.PayRate.ToString().Contains(searchString) ||
                   e.HoursWorked.ToString().Contains(searchString);
        }

        // Displays a single employee’s details by ID
        public IActionResult ViewSingleEmployee(int id)
        {
            var employee = _repo.GetEmployeeById(id);
            return View(employee);
        }

        /* --- UPDATE --- */

        // Displays the update form for an employee based on ID
        public IActionResult UpdateEmployee(int id)
        {
            Employee test = _repo.GetEmployeeById(id);
            return View(test);
        }

        // Updates an employee’s details in the database and redirects to single employee view
        public IActionResult UpdateEmployeeToDatabase(Employee employee)
        {
            _repo.UpdateEmployee(employee);
            return RedirectToAction("ViewSingleEmployee", new { id = employee.EmployeeId });
        }

        /* --- DELETE --- */

        // Deletes an employee record and redirects to the employee list
        public IActionResult DeleteEmployee(Employee employee)
        {
            _repo.DeleteEmployee(employee);
            return RedirectToAction("GetAllEmployees");
        }
    }
}
