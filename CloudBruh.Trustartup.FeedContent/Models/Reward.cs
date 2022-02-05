using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public Startup? Startup { get; set; }
    public string Name { get; set; }
    public decimal DonationMinimum { get; set; }
    public long MediaId { get; set; }
    public string Description { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
}