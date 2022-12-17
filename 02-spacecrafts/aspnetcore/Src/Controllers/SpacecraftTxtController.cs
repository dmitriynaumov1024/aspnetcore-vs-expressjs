using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("spacecrafts.txt")]
[Produces("text/plain; encoding=utf-8")]
public class SpacecraftTxtController : ControllerBase
{
    static string StringifySpacecraft (Spacecraft s) 
    {   
        return @$"- id: {s.Id} 
  manufacturer: {s.Manufacturer}
  manufactureYear: {s.ManufactureYear}
  category: {s.Category}
  cargo: {s.Cargo}
  guns: {s.Guns}
  missiles: {s.Missiles}
  thrusters: {s.Thrusters}
  agility: {s.Agility}
";
    }

    [HttpGet("")]
    [HttpGet("index")]
    public IActionResult List ()
    {
        var crafts = Program.Crafts;
        return Content(String.Join("\n", crafts.Select(StringifySpacecraft)));
    }

    [HttpGet("manufacturer/{manufacturer}")]
    public IActionResult GetByManufacturer (string manufacturer) 
    {
        var crafts = Program.Crafts;
        manufacturer = manufacturer.ToLower();
        var selection = crafts.Where(s => s.Manufacturer.ToLower() == manufacturer).ToList();
        if (selection.Count > 0) {
            return Content(String.Join("\n", selection.Select(StringifySpacecraft)));
        } 
        else {
            Response.StatusCode = 404;
            return Content($"Manufacturer {manufacturer} not found");
        }
    }

    [HttpGet("category/{category}")]
    public IActionResult GetByCategory (string category) 
    {
        var crafts = Program.Crafts;
        category = category.ToLower();
        var selection = crafts.Where(s => s.Category.ToLower() == category).ToList();
        if (selection.Count > 0) {
            return Content(String.Join("\n", selection.Select(StringifySpacecraft)));
        } 
        else {
            Response.StatusCode = 404;
            return Content($"Category {category} not found");
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById (int id) 
    {
        var crafts = Program.Crafts;
        var craft = crafts.FirstOrDefault(s => s.Id == id, null);
        if (craft != null) {
            return Content(StringifySpacecraft(craft));
        }
        else {
            Response.StatusCode = 404;
            return Content($"Spacecraft with id={id} not found");
        }
    }

    [Route("{garbage}")]
    public IActionResult Default (string garbage)
    {
        Response.StatusCode = 400;
        return Content($"Nothing here on {HttpContext.Request.Path}");
    }
}
