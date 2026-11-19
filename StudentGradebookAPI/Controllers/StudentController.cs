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

        [HttpGet("{id:guid}")]
        public ActionResult<IStudent> GetById(Guid id)
        {
            IStudent student = _studentManager.Get(id);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            return Ok(student);
        }

        // Creates a new student from the request body
        [HttpPost]
        public ActionResult<IStudent> Post([FromBody] Student newStudent)
        {
            // Checks that the required info was sent
            if (string.IsNullOrWhiteSpace(newStudent.FirstName) ||
                string.IsNullOrWhiteSpace(newStudent.LastName))
            {
                return BadRequest("FirstName and LastName are required.");
            }

            // Gives the student an ID if one wasn't sent
            if (newStudent.StudentId == Guid.Empty)
            {
                newStudent.StudentId = Guid.NewGuid();
            }

            // Saves the student
            _studentManager.Create(newStudent);

            // Returns 201 Created with a link to GET the new student
            return CreatedAtAction(nameof(GetById), new { id = newStudent.StudentId }, newStudent);
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
     }
}