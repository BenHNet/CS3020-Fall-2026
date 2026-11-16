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
    }
}