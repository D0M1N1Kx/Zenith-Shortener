using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithShortener.Data;
using ZenithShortener.Models;

namespace ZenithShortener.Controllers;

[ApiController]
public class RedirectController : ControllerBase
{
    private readonly AppDbContext _db;
    
    public RedirectController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet("/{shortCode}")]
    public async Task<IActionResult> RedirectToOriginal(string shortCode)
    {
        var link = await _db.ShortenedLinks
            .FirstOrDefaultAsync(l => l.ShortCode == shortCode);
        
        if (link == null)
            return NotFound("Code not exists or expired");

        var analytics = new ClickAnalytics
        {
            Id = Guid.NewGuid(),
            ShortenedLinkId = link.Id,
            ClickedAt = DateTime.UtcNow,
            UserAgent = Request.Headers["User-Agent"].ToString() ?? "Unknown",
            Referrer = Request.Headers["Referer"].ToString() ?? "Direct",
        };
        
        _db.ClickAnalytics.Add(analytics);
        await _db.SaveChangesAsync();
        
        return Redirect(link.OriginalUrl);
    }
}