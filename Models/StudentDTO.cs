using System.ComponentModel.DataAnnotations;

namespace shereeni_dotnet.Models;

public class StudentDTO
{
    public int Id{ get; set; }
    
    [Required(ErrorMessage = "The filed student name is required.")]
    [StringLength(20)]
    public string Name { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Address { get; set; }
    
    [Required]
    [Range(18,90)]
    public int Age { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
    
    public DateTime AdmissionDate { get; set; } 
}