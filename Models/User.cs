using System.Text.Json.Serialization;

namespace shereeni_dotnet.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
    
    [JsonIgnore]
    public List<Post> Posts { get; set; }

}