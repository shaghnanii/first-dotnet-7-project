namespace shereeni_dotnet.Models;

public class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public int UserId { get; set; }

    public User User { get; set; }

    public List<Comment> Comments { get; set; }
}