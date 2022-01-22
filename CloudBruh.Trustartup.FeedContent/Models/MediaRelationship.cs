namespace CloudBruh.Trustartup.FeedContent.Models;

public class MediaRelationship
{
    public long Id { get; set; }
    public long MediaId { get; set; }
    public long MediableId { get; set; }
    public MediableType MediableType { get; set; }
}