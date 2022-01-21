namespace CloudBruh.Trustartup.FeedContent.Models;

public interface IUpdatable : ICreatable
{
    public DateTime UpdatedAt { get; set; }
    
    public static void OnCreate(IUpdatable entity)
    {
        entity.UpdatedAt = entity.CreatedAt = DateTime.UtcNow;
    }

    public static void OnUpdate(IUpdatable entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
    }
}