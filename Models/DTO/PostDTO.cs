namespace shereeni_dotnet.Models.DTO;

public class PostDTO
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public int UserId { get; set; }

    public ICollection<CommentDTO> Comments { get; set; }
}