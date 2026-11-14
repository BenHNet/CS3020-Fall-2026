using System.ComponentModel.DataAnnotations;

namespace StudentGradebookAPI
{
    // Request payload for setting a student's grade in a course instance
    public class SetGradeRequest
    {
        [Required]
        public Guid StudentID { get; set; }

        [Required]
        public Guid CourseInstanceID { get; set; }

        [Required]
        public float? Grade { get; set; }
    }
}
