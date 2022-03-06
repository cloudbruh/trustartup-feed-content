using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CloudBruh.Trustartup.FeedContent.Models;

[Index(nameof(UserId), nameof(StartupId), IsUnique = true)]
public class Follow : ICreatable
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long StartupId { get; set; }
    [JsonIgnore]
    public Startup? Startup { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
}