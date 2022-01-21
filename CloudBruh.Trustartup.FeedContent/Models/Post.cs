namespace CloudBruh.Trustartup.FeedContent.Models;

public class Post : IUpdatable
{
    public long Id { get; set; }
    public long StartupId { get; set; }
    public string? Header { get; set; }
    public string? Text { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}