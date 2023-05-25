using System.ComponentModel.DataAnnotations;

namespace shereeni_dotnet.Models.DTO;

public class UserDTO
{
    public required int Id { get; set; }
    
    [Required]
    public required string Name { get; set; }
    
    public required string Email { get; set; }
    
    [Required]
    public required string Password { get; set; }
    
    [Required]
    [Range(0, 90, ErrorMessage = "The {0} field must be a positive integer.")]
    [RegularExpression(@"^\d+$", ErrorMessage = "The {0} field must be a positive integer.")]
    public required int Age { get; set; }
    
    [Required]
    public required string Address { get; set; }

    public ICollection<PostDTO> Posts { get; set; }
}