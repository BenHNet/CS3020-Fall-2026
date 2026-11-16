using Microsoft.AspNetCore.Mvc;
using StudentGradebookLibrary;
using StudentGradebookLibrary.Managers;
using StudentGradebookLibrary.Models;

namespace StudentGradebookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager _studentManager;

        public StudentController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return Ok(_studentManager.GetAll());
        }
    
        [HttpPut]
        public IActionResult UpdateStudent([FromBody] Student updatedStudent)
        {

        IStudent student = _studentManager.Get(updatedStudent.StudentId);

        if (student == null)
        {
            return NotFound("Student not found.");
        }

        // Updates the students information
        student.FirstName = updatedStudent.FirstName;
        student.LastName = updatedStudent.LastName;

        // Saves the updated student 
        _studentManager.Update(student);

        return NoContent();

        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteStudent(Guid id)
        {

        // Finds the student with their ID 
        IStudent student = _studentManager.Get(id);

        // Checks if they exist 
        if (student == null)
        {
            return NotFound("Student not found.");
        }

        // Deletes the student 
        _studentManager.Delete(id);

        return NoContent();
     }

        [HttpDelete("{studentId}")]
        public ActionResult Delete(Guid studentId)
        {
            _studentManager.Delete(studentId);
            return NoContent();
        }
    }
}