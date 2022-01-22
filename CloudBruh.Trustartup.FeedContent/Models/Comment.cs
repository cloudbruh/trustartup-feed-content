namespace CloudBruh.Trustartup.FeedContent.Models;

public class Comment : IUpdatable
{
    public Comment(string text)
    {
        Text = text;
    }

    public long Id { get; set; }
    public long CommentableId { get; set; }
    public CommentableType CommentableType { get; set; }
    public long? RepliedId { get; set; }
    public Comment? Replied { get; set; }
    public string Text { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<Comment> Replies { get; set; } = null!;
}