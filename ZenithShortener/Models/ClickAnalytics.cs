using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZenithShortener.Models;

public class ClickAnalytics
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public Guid ShortenedLinkId { get; set; }
    
    [Required]
    public DateTime ClickedAt { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string UserAgent { get; set; } = string.Empty;
    
    [MaxLength(2000)]
    public string? Referrer { get; set; }

    [ForeignKey(nameof(ShortenedLinkId))]
    public ShortenedLink ShortenedLink { get; set; } = null!;
}