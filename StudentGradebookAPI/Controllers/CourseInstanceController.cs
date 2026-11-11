using Microsoft.AspNetCore.Mvc;
using StudentGradebookLibrary.Models;
using System.Collections.Generic;

namespace StudentGradebookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseInstanceController : ControllerBase
    {
        private static readonly List<CourseInstance> courseInstances = new List<CourseInstance>();

        [HttpGet]
        public ActionResult<IEnumerable<CourseInstance>> Get()
        {
            return Ok(courseInstances);
        }
    }
}
