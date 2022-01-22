namespace CloudBruh.Trustartup.FeedContent.Models;

public class Follow : ICreatable
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long StartupId { get; set; }
    public Startup Startup { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}