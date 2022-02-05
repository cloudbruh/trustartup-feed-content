using System.ComponentModel.DataAnnotations.Schema;

namespace CloudBruh.Trustartup.FeedContent.Models;

public class Follow : ICreatable
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long StartupId { get; set; }
    public Startup? Startup { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
}