using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ZenithShortener.Models;

[Index(nameof(ShortCode), IsUnique = true)]
public class ShortenedLink
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string ShortCode { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(500)]
    public string OriginalUrl { get; set; } = string.Empty;
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ExpiresAt { get; set; }
    
    public ICollection<ClickAnalytics> Clicks { get; set; } = new List<ClickAnalytics>();
}