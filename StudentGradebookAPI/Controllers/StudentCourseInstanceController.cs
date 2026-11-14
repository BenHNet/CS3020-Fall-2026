using Microsoft.AspNetCore.Mvc;
using StudentGradebookLibrary.Managers;
using StudentGradebookLibrary.Models;

namespace StudentGradebookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentCourseInstanceController : ControllerBase
    {
        private readonly IStudentCourseInstanceManager _manager;

        public StudentCourseInstanceController(IStudentCourseInstanceManager manager)
        {
            _manager = manager;
        }

        // Enroll a student in a course instance
        [HttpPost(Name = "EnrollStudent")]
        public ActionResult<IStudentCourseInstance> Post([FromBody] EnrollStudentRequest request)
        {
            if (request.StudentID == Guid.Empty || request.CourseInstanceID == Guid.Empty)
            {
                return BadRequest("StudentID and CourseInstanceID are required.");
            }

            return Ok(_manager.Enroll(request.StudentID, request.CourseInstanceID));
        }

        // Set a student's grade for a course instance
        [HttpPut(Name = "SetStudentGrade")]
        public IActionResult Put([FromBody] SetGradeRequest request)
        {
            if (request.StudentID == Guid.Empty || request.CourseInstanceID == Guid.Empty)
            {
                return BadRequest("StudentID and CourseInstanceID are required.");
            }

            _manager.SetGrade(request.StudentID, request.CourseInstanceID, request.Grade!.Value);
            return NoContent();
        }
    }
}
