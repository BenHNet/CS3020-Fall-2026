using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGradebookLibrary.Courses
{
    internal interface ICourseInstance
    {
        Guid CourseInstanceID { get; set; }
        Guid  CourseID { get; set;  }

        Semester CourseTerm { get; set; }

        int CourseYear { get; set;  }

    }
}
