#nullable enable

using System;
using System.Collections.Generic;
using StudentGradebookLibrary.Models;

namespace StudentGradebookLibrary.Managers
{
    public interface ICourseInstanceManager
    {
        CourseInstance Create(Guid courseId, Semester semester, int year);
        List<CourseInstance> GetList();
        CourseInstance? Get(Guid courseInstanceId);
        void Update(Guid courseInstanceID, Semester semester, int year);
        bool Delete(Guid courseInstanceId);
    }
}