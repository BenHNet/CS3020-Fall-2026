using System;

namespace StudentGradebookLibrary.Models
{
    internal class CourseInstance : ICourseInstance
    {
        public Guid CourseInstanceID { get; set; }
        public Guid CourseID { get; set; }
        public Semester CourseTerm { get; set; }
        public int CourseYear { get; set; }

        public CourseInstance(Guid courseInstanceID, Guid courseID, Semester semester, int year)
        {
            this.CourseInstanceID = courseInstanceID;
            this.CourseID = courseID;
            this.CourseTerm = semester;
            this.CourseYear = year;
        }
    }
}
