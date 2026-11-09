using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGradebookLibrary.Courses
{
    internal class CourseManager 
    {
        public string CourseName { get; set; }
        public Guid  CourseID { get; set; }
        public string CourseDescription { get; set; }

        public CourseManager(string CourseName, Guid CourseID, string CourseDescription)
        {
            this.CourseName = CourseName;
            this.CourseID = CourseID;
            this.CourseDescription = CourseDescription;
        }
        public Guid GetCourseID()
        {
            return CourseID;
        }
    }
}

          
