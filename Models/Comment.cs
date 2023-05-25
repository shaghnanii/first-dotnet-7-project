using System.Text.Json.Serialization;

namespace shereeni_dotnet.Models;

public class Comment
{
    public int Id { get; set; }

    public string Message { get; set; } = string.Empty;

    public int PostId { get; set; }
    
    [JsonIgnore]
    public Post Post { get; set; }
}