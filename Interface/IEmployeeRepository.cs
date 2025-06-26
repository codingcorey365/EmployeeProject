using EmployeeProject.Models; // Importing the Employee model

namespace EmployeeProject.Interface
{
    // Interface defining the contract for employee repository operations
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Inserts a new employee record into the database.
        /// </summary>
        /// <param name="employeeToInsert">Employee object containing details to be inserted</param>
        public void CreateEmployee(Employee employeeToInsert);

        /// <summary>
        /// Retrieves a single employee by their unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the employee</param>
        /// <returns>An Employee object if found, otherwise null</returns>
        public Employee GetEmployeeById(int id);

        /// <summary>
        /// Retrieves all employee records from the database.
        /// </summary>
        /// <returns>A collection of all Employee objects</returns>
        public IEnumerable<Employee> GetAllEmployees();

        /// <summary>
        /// Updates the details of an existing employee.
        /// </summary>
        /// <param name="employee">Employee object containing updated information</param>
        public void UpdateEmployee(Employee employee);

        /// <summary>
        /// Deletes an employee record from the database.
        /// </summary>
        /// <param name="employee">Employee object containing the ID of the employee to delete</param>
        public void DeleteEmployee(Employee employee);

        /// <summary>
        /// Retrieves an employee's data formatted for a
        /// model by their unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the employee</param>
        /// <returns>An Employee view model object if found, otherwise null</returns>
        public Employee GetEmployeeViewModelById(int id);
    }
}