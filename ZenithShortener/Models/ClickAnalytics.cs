namespace ZenithShortener.Models;

public class ClickAnalytics
{
    public int Id { get; set; }
    public Guid ShortenedLinkId { get; set; }
    public DateTime ClickedAt { get; set; }
    public string UserAgent { get; set; } = string.Empty;
    public string? Referrer { get; set; }

    public ShortenedLink ShortenedLink { get; set; } = null!;
}