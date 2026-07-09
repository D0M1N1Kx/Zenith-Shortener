using Microsoft.AspNetCore.Mvc;
using ZenithShortener.Data;

namespace ZenithShortener.Controllers;

[ApiController]
public class RedirectController : ControllerBase
{
    private readonly AppDbContext _db;
    
    public RedirectController(AppDbContext db)
    {
        _db = db;
    }
}