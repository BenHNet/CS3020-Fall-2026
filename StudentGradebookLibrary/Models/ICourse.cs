using System;

namespace StudentGradebookLibrary.Models
{
    internal interface ICourse
    {
        string CourseName { get; set; }
        Guid  CourseID { get; set; }

        string Description { get; set; }
        
    }
}
