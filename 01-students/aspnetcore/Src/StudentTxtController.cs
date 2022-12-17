using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("students.txt")]
[Produces("text/plain; encoding=utf-8")]
public class StudentTxtController : ControllerBase
{
    static string StringifyStudent (Student s, int id) 
    {   
        return $"- id: {id} \n  surname: {s.Surname} \n  name: {s.Name} \n"
             + $"  course: {s.Course} \n  group: {s.Group} \n"
             + $"  points: {String.Join(", ", s.Points)} \n";
    }

    [HttpGet("")]
    [HttpGet("index")]
    public IActionResult List ()
    {
        var students = Program.Students;
        return Content(String.Join("\n", students.Select(StringifyStudent)));
    }

    [HttpGet("group/{group}")]
    public IActionResult GetGroup (string group) 
    {
        var students = Program.Students;
        var selection = students.Where(s => s.Group == group).ToList();
        if (selection.Count > 0) {
            return Content(String.Join("\n", selection.Select(StringifyStudent)));
        } 
        else {
            Response.StatusCode = 404;
            return Content($"Group {group} not found");
        }
    }

    [HttpGet("course/{course}")]
    public IActionResult GetCourse (int course) 
    {
        var students = Program.Students;
        var selection = students.Where(s => s.Course == course).ToList();
        if (selection.Count > 0) {
            return Content(String.Join("\n", selection.Select(StringifyStudent)));
        } 
        else {
            Response.StatusCode = 404;
            return Content($"Course {course} not found");
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult GetStudent (int id) 
    {
        var students = Program.Students;
        if (id >= 0 && id < students.Length) {
            return Content(StringifyStudent(students[id], id));
        }
        else {
            Response.StatusCode = 404;
            return Content($"Student with id={id} not found");
        }
    }

    [Route("{garbage}")]
    public ActionResult<object> Default (string garbage)
    {
        Response.StatusCode = 400;
        return Content($"Nothing here on {HttpContext.Request.Path}");
    }
}
