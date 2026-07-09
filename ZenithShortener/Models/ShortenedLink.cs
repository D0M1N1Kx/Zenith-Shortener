namespace ZenithShortener.Models;

public class ShortenedLink
{
    public Guid Id { get; set; }
    public string ShortCode { get; set; } = string.Empty;
    public string OriginalUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    
    public ICollection<ClickAnalytics> Clicks { get; set; } = new List<ClickAnalytics>();
}