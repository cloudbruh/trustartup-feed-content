using System.ComponentModel.DataAnnotations.Schema;

namespace CloudBruh.Trustartup.FeedContent.Models;

public class Like : ICreatable
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long LikeableId { get; set; }
    public LikeableType LikeableType { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
}