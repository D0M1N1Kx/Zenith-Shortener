using System.ComponentModel.DataAnnotations;

namespace ZenithShortener.Requests;

public class CreateShortUrlRequest
{
    [Required]
    [Url]
    [MaxLength(500)]
    public string Url { get; set; } = string.Empty;
    
    [Range(1, 30)]
    public int ExpireDays { get; set; } = 30;
}