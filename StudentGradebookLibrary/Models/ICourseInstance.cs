using System;

namespace StudentGradebookLibrary.Models
{
    internal interface ICourseInstance
    {
        Guid CourseInstanceID { get; set; }
        Guid  CourseID { get; set;  }

        Semester CourseTerm { get; set; }

        int CourseYear { get; set;  }

    }
}
