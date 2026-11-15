using StudentGradebookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGradebookLibrary.Managers
{
    internal interface ICourseManager
    {
        void AddCourse(Course course);
        Course GetCourse(Guid courseId);

    }
}
