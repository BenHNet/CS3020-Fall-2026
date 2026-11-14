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
        [HttpPost]
        public ActionResult<IStudentCourseInstance> Post([FromBody] EnrollStudentRequest request)
        {
            if (request.StudentID == Guid.Empty || request.CourseInstanceID == Guid.Empty)
            {
                return BadRequest("StudentID and CourseInstanceID are required.");
            }

            try
            {
                var enrollment = _manager.Enroll(request.StudentID, request.CourseInstanceID);
                return StatusCode(StatusCodes.Status201Created, enrollment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Set a student's grade for a course instance
        [HttpPut]
        public IActionResult Put([FromBody] SetGradeRequest request)
        {
            if (request.StudentID == Guid.Empty || request.CourseInstanceID == Guid.Empty)
            {
                return BadRequest("StudentID and CourseInstanceID are required.");
            }

            try
            {
                // Grade is non-null here: [ApiController] returns 400 before this runs if [Required] fails
                _manager.SetGrade(request.StudentID, request.CourseInstanceID, request.Grade!.Value);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        // Unenroll a student from a course instance
        [HttpDelete("{studentId:guid}/{courseInstanceId:guid}")]
        public IActionResult Delete(Guid studentId, Guid courseInstanceId)
        {
            if (studentId == Guid.Empty || courseInstanceId == Guid.Empty)
            {
                return BadRequest("StudentID and CourseInstanceID are required.");
            }

            try
            {
                _manager.UnEnroll(studentId, courseInstanceId);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
