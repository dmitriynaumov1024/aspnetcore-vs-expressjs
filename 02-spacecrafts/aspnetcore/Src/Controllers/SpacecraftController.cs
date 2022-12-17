using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("spacecrafts.json")]
public class SpacecraftController : ControllerBase
{
    [HttpGet("")]
    [HttpGet("index")]
    public IActionResult List ()
    {
        return Ok(Program.Crafts);
    }

    [HttpGet("manufacturer/{manufacturer}")]
    public IActionResult GetByManufacturer (string manufacturer) 
    {
        var crafts = Program.Crafts;
        manufacturer = manufacturer.ToLower();
        var selection = crafts.Where(s => s.Manufacturer.ToLower() == manufacturer).ToList();
        if (selection.Count > 0) {
            return Ok(selection);
        } 
        else {
            return NotFound(new {
                Message = $"Manufacturer {manufacturer} not found"
            });
        }
    }

    [HttpGet("category/{category}")]
    public IActionResult GetByCategory (string category) 
    {
        var crafts = Program.Crafts;
        category = category.ToLower();
        var selection = crafts.Where(s => s.Category.ToLower() == category).ToList();
        if (selection.Count > 0) {
            return Ok(selection);
        } 
        else {
            return NotFound(new {
                Message = $"Category {category} not found"
            });
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById (int id) 
    {
        var crafts = Program.Crafts;
        var craft = crafts.FirstOrDefault(s => s.Id == id, null);
        if (craft != null) {
            return Ok(craft);
        }
        else {
            return NotFound(new {
                Message = $"Spacecraft with id={id} not found"
            });
        }
    }

    [Route("{garbage}")]
    public IActionResult Default (string garbage)
    {
        return BadRequest(new {
            Message = $"Nothing here on {HttpContext.Request.Path}"
        });
    }
}
