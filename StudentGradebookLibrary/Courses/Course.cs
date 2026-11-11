using System;
using StudentGradebookLibrary.Courses;

namespace StudentGradebookLibrary
{
    public class Course : ICourse
    {
        public Guid CourseID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string CourseName
        {
            get { return this.Title; }
            set { this.Title = value; }
        }

        public Course(Guid courseID, string title, string description)
        {
            this.CourseID = courseID;
            this.Title = title;
            this.Description = description;
        }
    }
}
