using StudentGradebookLibrary.Models;
using System;

namespace StudentGradebookLibrary.Managers
{
    // Interface for StudentCourseInstanceManager class
    public interface IStudentCourseInstanceManager
    {
        // Enroll a student in a course instance and return the new enrollment
        IStudentCourseInstance Enroll(Guid studentID, Guid courseInstanceID);

        // Remove a student from a course instance (throws ArgumentException if not enrolled)
        void UnEnroll(Guid studentID, Guid courseInstanceID);

        // Set the student's grade for a course instance
        void SetGrade(Guid studentID, Guid courseInstanceID, float grade);
    }
}
