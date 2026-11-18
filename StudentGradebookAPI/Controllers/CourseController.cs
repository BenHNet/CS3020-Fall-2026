using Microsoft.AspNetCore.Mvc;
using StudentGradebookLibrary.Managers;
using StudentGradebookLibrary.Models;
using System.Collections.Generic;

namespace StudentGradebookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseManager _manager;

        public CourseController(ICourseManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            return Ok(_manager.GetList());
        }
    }
}