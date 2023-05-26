using System.ComponentModel.DataAnnotations;

namespace shereeni_dotnet.Models.DTO.User;

public class UserDTO
{
    [Required]
    public required string Name { get; set; }
    
    [Required]
    public required string Email { get; set; }
    
    [Required]
    public required string Password { get; set; }
    
    [Required]
    [Range(0, 90, ErrorMessage = "The {0} field must be a positive integer.")]
    public required int Age { get; set; }
    
    [Required]
    public required string Address { get; set; }
    
  
}