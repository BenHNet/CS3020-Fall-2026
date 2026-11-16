using StudentGradebookLibrary.Models;
using StudentGradebookLibrary.Repos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGradebookLibrary.Managers
{
    // StudentManager class implements the IStudentManager interface
    public class StudentManager : IStudentManager
    {
        private List<IStudent> Students;

        // Repo used to save and load student data
        private IRepo _repo;

        public StudentManager()
        {
            // Use a JsonRepo by default
            _repo = new JsonRepo();

            // Load any students that were already saved
            Students = new List<IStudent>(_repo.GetStudents());
        }

        // Implement Methods from IStudentManager interface below
        public void Create(IStudent student)
        {
            if (student == null)
            {
                Console.WriteLine("Student cannot be null!");
                return;
            }

            Students.Add(student);
            Save();

            Console.WriteLine("Student created successfully.");
        }

        public IStudent Get(Guid studentId)
        {
            return Students.FirstOrDefault(s => s.StudentId == studentId);
        }

        public List<IStudent> GetAll()
        {
            return Students;
        }

        public void Delete(Guid studentId)
        {
            int replacementIndex = Students.FindIndex(
                s => s.StudentId == studentId
            );

            if (replacementIndex != -1)
            {
                Students.RemoveAt(replacementIndex);
                Save();
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void Update(IStudent student)
        {
            // Validate input for safety
            if (student == null)
            {
                return;
            }

            // Match student ID to find index
            int replacementIndex = Students.FindIndex(
                s => s.StudentId == student.StudentId
            );

            // If the student ID is found, update that entry
            if (replacementIndex != -1)
            {
                Students[replacementIndex] = student;
                Save();
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        // Saves the current list of students using the repo
        private void Save()
        {
            _repo.SaveStudents(Students.Cast<Student>().ToList());
        }
    }
}