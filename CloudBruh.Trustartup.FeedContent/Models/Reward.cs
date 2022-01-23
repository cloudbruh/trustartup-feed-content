using System.ComponentModel.DataAnnotations.Schema;

namespace CloudBruh.Trustartup.FeedContent.Models;

public class Reward : IUpdatable
{
    public Reward(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public long Id { get; set; }
    public long StartupId { get; set; }
    public Startup Startup { get; set; } = null!;
    public string Name { get; set; }
    public decimal DonationMinimum { get; set; }
    public long MediaId { get; set; }
    public string Description { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
}