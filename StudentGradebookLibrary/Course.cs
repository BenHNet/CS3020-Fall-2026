using System;

namespace StudentGradebookLibrary
{
    public class Course
    {
        public Guid CourseID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Course(Guid courseID, string title, string description)
        {
            this.CourseID = courseID;
            this.Title = title;
            this.Description = description;
        }
    }
}
