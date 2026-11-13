#nullable enable

using StudentGradebookLibrary.Models;
using StudentGradebookLibrary.Repos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGradebookLibrary.Managers
{
    public class StudentCourseInstanceManager : IStudentCourseInstanceManager
    {
        private readonly List<IStudentCourseInstance> _studentCourseInstances = new();
        
        // Enable serialization when ready - right now IRepo is internal, while the manager classes are public.
        // private readonly IRepo _repo;

        // public StudentCourseInstanceManager(IRepo repo)
        // {
        //    _repo = repo;
        // }
        

        public IStudentCourseInstance Enroll(Guid studentID, Guid courseInstanceID)
        {
            // Check for duplicate enrollment
            var existingEnrollment = FindEnrollment(studentID, courseInstanceID);
            if (existingEnrollment != null)
            {
                System.Console.WriteLine(
                    $"Student {studentID} is already enrolled in course instance {courseInstanceID}.");
                return existingEnrollment;
            }

            // Create a new student course instance
            var studentCourseInstance = new StudentCourseInstance(Guid.NewGuid(), studentID, courseInstanceID);

            // If the interface does not require an ID, use the constructor without one.
            //var studentCourseInstance = new StudentCourseInstance(studentID, courseInstanceID);

            _studentCourseInstances.Add(studentCourseInstance);

            // Serialize the data
            // Enable this when ready - right now IRepo does not serialize student course instances.
            //_repo.Save(studentCourseInstance);

            // Return the newly created student course instance
            return studentCourseInstance;
        }

        

        public void SetGrade(Guid studentID, Guid courseInstanceID, float grade)
        {
            // Find the student course instance
            var studentCourseInstance = FindEnrollment(studentID, courseInstanceID);
            if (studentCourseInstance != null)
            {
                // Set the grade for the student's course instance
                studentCourseInstance.Grade = grade;
            }

            // Serialize the data - right now IRepo does not serialize student course instances.
            // Enable this when ready
            //_repo.Save(studentCourseInstance);
        }

        public void UnEnroll(Guid studentID, Guid courseInstanceID)
        {
            // Should we be removing the student course instance or just clearing its grade?
            // Having a way to tell if a student has unenrolled from a course would be useful.

            // Find the student's course instance
            var studentCourseInstance = FindEnrollment(studentID, courseInstanceID);
            if (studentCourseInstance != null)
            {
                // Remove the student's course instance
                this._studentCourseInstances.Remove(studentCourseInstance);
            }

            // Serialize the data - right now IRepo does not serialize student course instances.
            // Enable this when ready
            //_repo.Save(studentCourseInstance);
        }

        // Helper method to find a student course instance
        private IStudentCourseInstance? FindEnrollment(Guid studentID, Guid courseInstanceID)
        {
            return _studentCourseInstances.FirstOrDefault(
                sci => sci.StudentID == studentID && sci.CourseInstanceID == courseInstanceID);
        }
        
    }
}