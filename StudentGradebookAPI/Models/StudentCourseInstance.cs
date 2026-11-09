namespace StudentGradebookAPI.Models;

public class StudentCourseInstance
{
    public Guid StudentCourseInstanceId { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseInstanceId { get; set; }
    public float Grade { get; set; }
}