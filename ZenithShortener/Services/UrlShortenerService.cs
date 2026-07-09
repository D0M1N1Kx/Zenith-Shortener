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

    private string GenerateRandomCode(int length)
    {
        var chars = new char[length];
        
        for (var i = 0; i < length; i++)
            chars[i] = Alphabet[_random.Next(Alphabet.Length)];
        
        return new string(chars);
    }
}