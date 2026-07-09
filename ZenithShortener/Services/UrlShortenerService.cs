using ZenithShortener.Data;

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
}