
using Microsoft.AspNetCore.Mvc;

namespace CampusEats.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    [HttpGet]
    public IActionResult GetMenu()
    {
        var menu = new[]
        {
            new { Id = 1, Name = "Chicken Rice", Price = 850 },
            new { Id = 2, Name = "Fried Rice", Price = 750 },
            new { Id = 3, Name = "Burger", Price = 1200 }
        };

        return Ok(menu);
    }
}
