#nullable enable

using StudentGradebookLibrary.Models;
using System;
using System.Collections.Generic;

namespace StudentGradebookLibrary.Managers
{
    internal class CourseInstanceManager
    {
        private readonly List<CourseInstance> _courseInstances = new();

        public CourseInstanceManager()
        {
            _courseInstances = GetList();
        }

        // Schedule an instance of an existing course.
        public CourseInstance Create(Guid courseId, Semester semester, int year)
        {
            var instance = new CourseInstance(
                Guid.NewGuid(), courseId, semester, year);

            _courseInstances.Add(instance);
            return instance;
        }

        // Return a copy so callers can't add or remove entries directly.
        public List<CourseInstance> GetList()
        {
            return new List<CourseInstance>(_courseInstances);
        }

        // Return null if there is no instance with this ID.
        public CourseInstance? Get(Guid courseInstanceId)
        {
            return _courseInstances.Find(instance =>
                instance.CourseInstanceID == courseInstanceId);
        }

        // Return true only if an instance was removed.
        public bool Delete(Guid courseInstanceId)
        {
            var instance = Get(courseInstanceId);
            return instance != null && _courseInstances.Remove(instance);
        }

        // Update the semester and year of an existing course instance.
        public void Update(Guid courseInstanceID, Semester semester, int year)
        {
            var instance = Get(courseInstanceID);

            if (instance == null)
            {
                return;
            }

            instance.CourseTerm = semester;
            instance.CourseYear = year;

        }
    }
}
