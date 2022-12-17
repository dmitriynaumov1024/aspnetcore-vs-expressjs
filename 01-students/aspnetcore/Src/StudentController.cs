using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("students.json")]
public class StudentController : ControllerBase
{
    [HttpGet("")]
    [HttpGet("index")]
    public IActionResult List ()
    {
        var students = Program.Students;
        return Ok(students);
    }

    [HttpGet("group/{group}")]
    public IActionResult GetGroup (string group) 
    {
        var students = Program.Students;
        var selection = students.Where(s => s.Group == group).ToList();
        if (selection.Count > 0) {
            return Ok(selection);
        } 
        else {
            return NotFound(new {
                Message = $"Group {group} not found"
            });
        }
    }

    [HttpGet("course/{course}")]
    public IActionResult GetCourse (int course) 
    {
        var students = Program.Students;
        var selection = students.Where(s => s.Course == course).ToList();
        if (selection.Count > 0) {
            return Ok(selection);
        } 
        else {
            return NotFound(new {
                Message = $"Course {course} not found"
            });
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult GetStudent (int id) 
    {
        var students = Program.Students;
        if (id >= 0 && id < students.Length) {
            return Ok(students[id]);
        }
        else {
            return NotFound(new {
                Message = $"Student with id={id} not found"
            });
        }
    }

    [Route("{garbage}")]
    public ActionResult<object> Default (string garbage)
    {
        return BadRequest(new {
            Message = $"Nothing here on {HttpContext.Request.Path}"
        });
    }
}
