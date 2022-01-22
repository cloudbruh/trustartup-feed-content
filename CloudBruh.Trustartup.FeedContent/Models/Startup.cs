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
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}