using System.ComponentModel.DataAnnotations;

public class Employee
{
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Gender is required.")]
    public string Gender { get; set; }
    [Required(ErrorMessage = "State is required.")]
    public string State { get; set; }
    [Required]
    public string Address { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
    public string Phone { get; set; }
    
    [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
    public decimal Salary { get; set; }
    
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string Email { get; set; }
}
