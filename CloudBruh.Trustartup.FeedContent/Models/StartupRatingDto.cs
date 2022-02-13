namespace CloudBruh.Trustartup.FeedContent.Models;

public record StartupRatingDto
{
    public long Id { get; init; }
    
    public double Rating { get; init; }
}