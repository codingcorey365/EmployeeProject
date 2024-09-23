//using EmployeeProject.Interface;
//using EmployeeProject.Models;
//using EmployeeProject.ViewModels;

//namespace EmployeeProject.Repository;

//public class EmployeeViewModelService : IEmployeeViewModelService
//{
//    public EmployeeViewModelService ConvertToViewModel(Employee employee)
//    {
//        var viewModel = new EmployeeViewModel
//        {
//            EmployeeId = employee.EmployeeId,
//            FirstName = employee.FirstName,
//            MiddleName = employee.MiddleName,
//            LastName = employee.LastName,
//            BirthDay = employee.BirthDay,
//            BirthMonth = employee.BirthMonth,
//            BirthYear = employee.BirthYear,
//            Age = employee.Age,
//            PhoneNumber = employee.PhoneNumber,
//            EmailAddress = employee.EmailAddress,
//            HomeAddress = employee.HomeAddress,
//            EmployeeDepartment = employee.EmployeeDepartment,
//            EmployeeTitle = employee.EmployeeTitle,
//            PayRate = employee.PayRate,
//            HoursWorked = employee.HoursWorked
//        };

//        return viewModel;
//    }
//}