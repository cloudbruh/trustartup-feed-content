using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CloudBruh.Trustartup.FeedContent.Models;

[Index(nameof(UserId), nameof(LikeableId), nameof(LikeableType), IsUnique = true)]
public class Like : ICreatable
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long LikeableId { get; set; }
    public LikeableType LikeableType { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
}