using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EmployeeProject.Models;

public class Employee
{
    //EmployeeID
    [Required]
    public int EmployeeId { get; set; }
    
    // First Name: Required, length between 2 and 10 characters
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(35, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 35 characters.")]
    public required string FirstName { get; set; }

    // Middle Name: Optional, but if provided, should follow the same length constraints
    [StringLength(35, MinimumLength = 2, ErrorMessage = "Middle name must be between 2 and 35 characters.")]
    public string? MiddleName { get; set; }

    // Last Name: Required, length between 2 and 10 characters
    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(35, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 35 characters.")]
    public string? LastName { get; set; }


    // ✅ BirthDay: 1 to 31, two digits max
    [Required(ErrorMessage = "Birth day is required.")]
    [Range(1, 31, ErrorMessage = "Birth day must be between 1 and 31.")]
    [RegularExpression(@"^\d{1,2}$", ErrorMessage = "Birth day must be 1 or 2 digits.")]
    public int BirthDay { get; set; }

    // ✅ BirthMonth: 1 to 12, two digits max
    [Required(ErrorMessage = "Birth month is required.")]
    [Range(1, 12, ErrorMessage = "Birth month must be between 1 and 12.")]
    [RegularExpression(@"^\d{1,2}$", ErrorMessage = "Birth month must be 1 or 2 digits.")]
    public int BirthMonth { get; set; }

    // ✅ BirthYear: Reasonable 4-digit year, e.g. 1900 to 2100
    [Required(ErrorMessage = "Birth year is required.")]
    [Range(1900, 2100, ErrorMessage = "Birth year must be between 1900 and 2100.")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "Birth year must be a 4-digit number.")]
    public int BirthYear { get; set; }

    //Age: Required, must be a number between 0 and 130, up to 3 digits
    [Required(ErrorMessage = "Age is required.")]
    [Range(0, 130, ErrorMessage = "Age must be between 0 and 130.")]
    [RegularExpression(@"^\d{1,3}$", ErrorMessage = "Age must be a number with up to 3 digits.")]
    public int Age { get; set; }

    // 📞 Phone Number: Required and must follow a valid phone format
    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    [RegularExpression(@"^(\(\d{3}\)\s?|\d{3}[-.])?\d{3}[-.]\d{4}$",
        ErrorMessage = "Phone number must be in a valid U.S. format like 123-456-7890 or (123) 456-7890.")]
    public string? PhoneNumber { get; set; }


    // 📧 Email Address: Required and must be a valid email format
    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com)$", ErrorMessage = "Email address must end with .com.")]
    public string? EmailAddress { get; set; }


    // 🏠 Home Address: Optional, but you can enforce basic length or required if needed
    [Required(ErrorMessage = "Home address is required.")]
    [StringLength(100, ErrorMessage = "Home address cannot exceed 100 characters.")]

    public string? HomeAddress { get; set; }


    // 📌 Department: Required, letters only, min 2 characters
    [Required(ErrorMessage = "Department is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Department must be between 2 and 50 characters.")]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Department must contain only letters and spaces.")]
    public string? EmployeeDepartment { get; set; }

    // 🏷 Title: Must be a positive integer (e.g., 1 = Manager, 2 = Supervisor, etc.)
    [Required(ErrorMessage = "Employee title is required.")]
    [Range(1, 10, ErrorMessage = "Employee title must be a number between 1 and 10.")]
    public int EmployeeTitle { get; set; }

    // 💵 Pay Rate: Must be realistic pay (e.g., $7.25 – $1000/hour)
    [Required(ErrorMessage = "Pay rate is required.")]
    [RegularExpression(@"^\$?\d{1,3}(,\d{3})*(\.\d{2})?$|^\$?\d+(\.\d{2})?$",
        ErrorMessage = "Pay rate must be a valid USD format (e.g., 12.50 or $1,000.00).")]
    [StringLength(15, ErrorMessage = "Pay rate format is too long.")]
    public string? PayRate { get; set; }


    // ⏱ Hours Worked: Between 0 and 168 (max hours in a week)
    [Required(ErrorMessage = "Hours worked is required.")]
    [Range(0, 168, ErrorMessage = "Hours worked must be between 0 and 168.")]
    public int HoursWorked { get; set; }

}