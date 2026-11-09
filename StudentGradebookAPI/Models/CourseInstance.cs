namespace StudentGradebookAPI.Models;

public class CourseInstance
{
    public Guid CourseInstanceId { get; set; }
    public Guid CourseId { get; set; }
    public Semester Semester { get; set; }
    public int Year { get; set; }
}
