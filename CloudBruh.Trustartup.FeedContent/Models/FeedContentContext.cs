using Microsoft.EntityFrameworkCore;

namespace CloudBruh.Trustartup.FeedContent.Models;

public class FeedContentContext : DbContext
{
    public FeedContentContext(DbContextOptions<FeedContentContext> options) : base(options)
    {
        
    }

    public DbSet<Startup> Startups { get; set; } = null!;
}