using System.ComponentModel.DataAnnotations.Schema;

namespace CloudBruh.Trustartup.FeedContent.Models;

public class Startup : IUpdatable
{
    public Startup(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
    public DateTime EndingAt { get; set; }
    public decimal FundsGoal { get; set; }
    public double Rating { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
}