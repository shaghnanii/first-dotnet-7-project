using System.ComponentModel.DataAnnotations;
using shereeni_dotnet.Validators;
using System.Text.Json.Serialization;

namespace shereeni_dotnet.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Address { get; set; }

    public ICollection<Post> Posts { get; set; }

}