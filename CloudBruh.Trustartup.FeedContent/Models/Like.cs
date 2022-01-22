namespace CloudBruh.Trustartup.FeedContent.Models;

public class Like : ICreatable
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long LikeableId { get; set; }
    public LikeableType LikeableType { get; set; }
    public DateTime CreatedAt { get; set; }
}