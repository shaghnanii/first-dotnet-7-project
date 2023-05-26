namespace shereeni_dotnet.Models.DTO;

public class CommentDTO
{
    public int Id { get; set; }

    public string Message { get; set; } = string.Empty;

    public int PostId { get; set; }
}