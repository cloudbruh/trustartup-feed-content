using System.ComponentModel.DataAnnotations.Schema;

namespace CloudBruh.Trustartup.FeedContent.Models;

public class Post : IUpdatable
{
    public Post(string header, string text)
    {
        Header = header;
        Text = text;
    }

    public long Id { get; set; }
    public long StartupId { get; set; }
    public Startup Startup { get; set; } = null!;
    public string Header { get; set; }
    public string Text { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
}