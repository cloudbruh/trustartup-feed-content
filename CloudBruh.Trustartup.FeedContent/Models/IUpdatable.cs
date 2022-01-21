namespace CloudBruh.Trustartup.FeedContent.Models;

public interface IUpdatable : ICreatable
{
    public DateTime UpdatedAt { get; set; }
}