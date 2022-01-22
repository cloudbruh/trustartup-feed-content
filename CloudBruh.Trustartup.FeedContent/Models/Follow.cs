namespace CloudBruh.Trustartup.FeedContent.Models;

public class Follow : ICreatable
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long StartupId { get; set; }
    public DateTime CreatedAt { get; set; }
}