using StudentGradebookLibrary.Models;
using System.Collections.Generic;

namespace StudentGradebookLibrary.Managers
{
    public interface ICourseManager
    {
        List<Course> GetList();
    }
}