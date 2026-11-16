using Microsoft.AspNetCore.Mvc;
using StudentGradebookLibrary.Models;
using StudentGradebookLibrary.Managers;
using System.Collections.Generic;

namespace StudentGradebookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private static readonly CourseManager courseManager = new CourseManager();

        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            return Ok(courseManager.GetList());
        }

        [HttpGet("{id:guid}")]
        public ActionResult<Course> Get(Guid id)
        {
            var course = courseManager.Get(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public ActionResult<Course> Post([FromBody] Course course)
        {
            if (string.IsNullOrEmpty(course.Title) || string.IsNullOrEmpty(course.Description))
            {
                return BadRequest("Title and description are required.");
            }

            var createdCourse = courseManager.Create(course.Title, course.Description);
            return CreatedAtAction(nameof(Get), new { id = createdCourse.CourseID }, createdCourse);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Course course)
        {
            if (string.IsNullOrEmpty(course.Title) || string.IsNullOrEmpty(course.Description))
            {
                return BadRequest("Title and description are required.");
            }

            if (courseManager.Get(course.CourseID) == null)
            {
                return NotFound();
            }

            courseManager.Update(course.CourseID, course.Title, course.Description);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            if (!courseManager.Delete(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
