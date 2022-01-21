namespace CloudBruh.Trustartup.FeedContent.Models;

public interface ICreatable
{
    public DateTime CreatedAt { get; set; }

    public static void OnCreate(ICreatable entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
    }
}