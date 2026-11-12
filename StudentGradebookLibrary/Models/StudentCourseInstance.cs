using System;

namespace StudentGradebookLibrary.Models
{
    // StudentCourseInstance class implements the IStudentCourseInstance interface
    public class StudentCourseInstance : IStudentCourseInstance
    {
        public Guid StudentCourseInstanceID { get; set; }
        public Guid StudentID { get; set; }
        public Guid CourseInstanceID { get; set; }
        public float Grade { get; set; }

        // Parameterless constructor so the JSON repo can load saved enrollments
        public StudentCourseInstance()
        {
        }

        public StudentCourseInstance(Guid studentCourseInstanceID, Guid studentID, Guid courseInstanceID, float grade = 0)
        {
            this.StudentCourseInstanceID = studentCourseInstanceID;
            this.StudentID = studentID;
            this.CourseInstanceID = courseInstanceID;
            this.Grade = grade;
        }
    }
}
