using Microsoft.EntityFrameworkCore;
using ZenithShortener.Data;
using ZenithShortener.Models;

namespace ZenithShortener.Services;

public class UrlShortenerService
{
    private readonly AppDbContext _db;
    private static readonly Random _random = new();
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    
    public UrlShortenerService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<string> ShortenUrl(string url, int expirationDays = 30)
    {
        var existingLink = await _db.ShortenedLinks
            .FirstOrDefaultAsync(l => l.OriginalUrl == url);
        
        if (existingLink != null)
            return existingLink.ShortCode;

        string shortCode;
        do
        {
            shortCode = GenerateRandomCode(6);
        } while (await _db.ShortenedLinks.AnyAsync(l => l.ShortCode == shortCode));

        var shortenedLink = new ShortenedLink
        {
            Id = Guid.NewGuid(),
            OriginalUrl = url,
            ShortCode = shortCode,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(expirationDays)
        };
        
        _db.ShortenedLinks.Add(shortenedLink);
        await _db.SaveChangesAsync();

        return shortCode;
    }

    private string GenerateRandomCode(int length)
    {
        var chars = new char[length];
        
        for (var i = 0; i < length; i++)
            chars[i] = Alphabet[_random.Next(Alphabet.Length)];
        
        return new string(chars);
    }
}