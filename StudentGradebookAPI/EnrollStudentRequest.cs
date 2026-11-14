using System.ComponentModel.DataAnnotations;

namespace StudentGradebookAPI
{
    // Request payload for enrolling a student in a course instance
    public class EnrollStudentRequest
    {
        [Required]
        public Guid StudentID { get; set; }

        [Required]
        public Guid CourseInstanceID { get; set; }
    }
}
