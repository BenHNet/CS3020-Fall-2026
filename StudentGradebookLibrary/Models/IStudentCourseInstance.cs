using System;

namespace StudentGradebookLibrary.Models
{
    // Interface for a student's enrollment in a specific course instance, along with their grade
    public interface IStudentCourseInstance
    {
        Guid StudentCourseInstanceID { get; set; }
        Guid StudentID { get; set; }
        Guid CourseInstanceID { get; set; }
        float Grade { get; set; }
    }
}
