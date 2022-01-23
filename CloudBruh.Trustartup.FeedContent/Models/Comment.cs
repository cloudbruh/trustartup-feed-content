using System.ComponentModel.DataAnnotations.Schema;

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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    public List<Comment> Replies { get; set; } = null!;
}