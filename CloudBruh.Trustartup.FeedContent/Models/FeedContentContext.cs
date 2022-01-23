using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CloudBruh.Trustartup.FeedContent.Models;

public class FeedContentContext : DbContext
{
    public FeedContentContext(DbContextOptions<FeedContentContext> options) : base(options)
    {
        
    }

    public DbSet<Startup> Startups { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Like> Likes { get; set; } = null!;
    public DbSet<MediaRelationship> MediaRelationships { get; set; } = null!;
    public DbSet<Follow> Follows { get; set; } = null!;
    public DbSet<Reward> Rewards { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>()
            .HasOne(comment => comment.Replied)
            .WithMany(comment => comment.Replies);

        modelBuilder.Entity<Startup>().Property(startup => startup.CreatedAt).HasDefaultValueSql("now()");
        modelBuilder.Entity<Post>().Property(post => post.CreatedAt).HasDefaultValueSql("now()");
        modelBuilder.Entity<Comment>().Property(comment => comment.CreatedAt).HasDefaultValueSql("now()");
        modelBuilder.Entity<Like>().Property(like => like.CreatedAt).HasDefaultValueSql("now()");
        modelBuilder.Entity<Follow>().Property(follow => follow.CreatedAt).HasDefaultValueSql("now()");
        modelBuilder.Entity<Reward>().Property(reward => reward.CreatedAt).HasDefaultValueSql("now()");
        
        modelBuilder.Entity<Startup>().Property(startup => startup.UpdatedAt).HasDefaultValueSql("now()");
        modelBuilder.Entity<Post>().Property(post => post.UpdatedAt).HasDefaultValueSql("now()");
        modelBuilder.Entity<Comment>().Property(comment => comment.UpdatedAt).HasDefaultValueSql("now()");
        modelBuilder.Entity<Reward>().Property(reward => reward.UpdatedAt).HasDefaultValueSql("now()");
    }

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
        // foreach (EntityEntry entry in ChangeTracker.Entries().Where(entry => entry.State == EntityState.Added))
        // {
        //     if (entry.Entity is ICreatable entity)
        //     {
        //         entity.CreatedAt = DateTime.UtcNow;
        //     }
        // }
        //
        // foreach (EntityEntry entry in ChangeTracker.Entries()
        //              .Where(entry => entry.State is EntityState.Added or EntityState.Modified)) 
        // {
        //     if (entry.Entity is not IUpdatable entity)
        //     {
        //         continue;
        //     }
        //
        //     entity.UpdatedAt = DateTime.UtcNow;
        //     if (entry.State == EntityState.Added)
        //     {
        //         entity.CreatedAt = entity.UpdatedAt;
        //     }
        // }
    }
}