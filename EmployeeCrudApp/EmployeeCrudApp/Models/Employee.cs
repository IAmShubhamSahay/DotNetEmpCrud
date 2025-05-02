using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace EmployeeCrudApp.Models;
public class Employee
{
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "First Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Surname is required.")]
    public string Surname { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public string Gender { get; set; }

   [Required(ErrorMessage = "Street Address is required.")]
    public string StreetAddress { get; set; }

    [Required(ErrorMessage = "City is required.")]
    public string City { get; set; }

    [Required(ErrorMessage = "State is required.")]
    public string State { get; set; }

    [Required(ErrorMessage = "Country is required.")]
    public string Country { get; set; }

    [Required(ErrorMessage = "Pincode is required.")]
    [RegularExpression(@"^\d{6}$", ErrorMessage = "Pincode must be 6 digits.")]
    public string Pincode { get; set; }
    //[Required]
    //public string Address { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
    public string Phone { get; set; }
    
    [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
    public decimal Salary { get; set; }
    
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Date of Birth is required.")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Date of Joining is required.")]
    [DataType(DataType.Date)]
    public DateTime DateOfJoining { get; set; }

    [Required(ErrorMessage = "Marital Status is required.")]
    public string MaritalStatus { get; set; }
}
