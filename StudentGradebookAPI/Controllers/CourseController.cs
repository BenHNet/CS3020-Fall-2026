using Microsoft.AspNetCore.Mvc;
using StudentGradebookLibrary.Models;
using System.Collections.Generic;

namespace StudentGradebookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private static readonly List<Course> courses = new List<Course>();

        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            return Ok(courses);
        }
    }
}
