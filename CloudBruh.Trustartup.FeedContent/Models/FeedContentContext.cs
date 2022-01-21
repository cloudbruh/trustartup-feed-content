using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CloudBruh.Trustartup.FeedContent.Models;

public class FeedContentContext : DbContext
{
    public FeedContentContext(DbContextOptions<FeedContentContext> options) : base(options)
    {
        
    }

    public DbSet<Startup> Startups { get; set; } = null!;

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        SetProperties();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new())
    {
        SetProperties();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void SetProperties()
    {
        foreach (EntityEntry entry in ChangeTracker.Entries().Where(entry => entry.State == EntityState.Added))
        {
            if (entry.Entity is ICreatable entity)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }
        }
        
        foreach (EntityEntry entry in ChangeTracker.Entries().Where(entry => entry.State == EntityState.Modified))
        {
            if (entry.Entity is IUpdatable entity)
            {
                entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}