using Microsoft.EntityFrameworkCore;
using ZenithShortener.Models;

namespace ZenithShortener.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<ShortenedLink> ShortenedLinks => Set<ShortenedLink>();
    public DbSet<ClickAnalytics> ClickAnalytics => Set<ClickAnalytics>();
}