using Microsoft.AspNetCore.Mvc;
using StudentGradebookLibrary.Managers;
using StudentGradebookLibrary.Models;
using System;
using System.Collections.Generic;

namespace StudentGradebookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseInstanceController : ControllerBase
    {
        private static readonly List<CourseInstance> courseInstances =
            new List<CourseInstance>();

        private readonly CourseInstanceManager _manager;

        public CourseInstanceController(CourseInstanceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseInstance>> Get()
        {
            return Ok(courseInstances);
        }

        // Find a course instance using the ID from the URL.
        [HttpGet("{id:guid}")]
        public ActionResult<CourseInstance> GetById(Guid id)
        {
            var instance = _manager.Get(id);

            if (instance == null)
            {
                return NotFound();
            }

            return Ok(instance);
        }

        // Use the submitted values to create a course instance.
        [HttpPost]
        public ActionResult<CourseInstance> Create(
            [FromBody] CreateCourseInstanceRequest request)
        {
            var instance = _manager.Create(
                request.CourseID,
                request.CourseTerm,
                request.CourseYear);

            // Include a URL where the new instance can be retrieved.
            return CreatedAtAction(
                nameof(GetById),
                new { id = instance.CourseInstanceID },
                instance);
        }

        // Update the semester and year of an existing instance.
        [HttpPut]
        public IActionResult Update(
            [FromBody] UpdateCourseInstanceRequest request)
        {
            var instance = _manager.Get(request.CourseInstanceID);

            // Make sure the instance exists before updating it.
            if (instance == null)
            {
                return NotFound();
            }

            _manager.Update(
                request.CourseInstanceID,
                request.CourseTerm,
                request.CourseYear);

            return NoContent();
        }

        // Remove the instance with the matching ID.
        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            bool deleted = _manager.Delete(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

    // Data needed to create a course instance.
    public class CreateCourseInstanceRequest
    {
        public Guid CourseID { get; set; }
        public Semester CourseTerm { get; set; }
        public int CourseYear { get; set; }
    }

    // Data needed to update a course instance.
    public class UpdateCourseInstanceRequest
    {
        public Guid CourseInstanceID { get; set; }
        public Semester CourseTerm { get; set; }
        public int CourseYear { get; set; }
    }
}