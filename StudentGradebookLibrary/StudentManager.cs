
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace StudentGradebookLibrary
{
    // StudentManager class implements the IStudentManager interface
    public class StudentManager : IStudentManager
    {
        private List<Student> Students;

        public StudentManager()
        {
            Students = new List<Student>();

            if (File.Exists("gradebook.json"))
            {
                string json = File.ReadAllText("gradebook.json");

                Students = JsonSerializer.Deserialize<List<Student>>(json)
                           ?? new List<Student>();
            }
        }

        // Implement Methods from IStudentManager interface below
        public void Create(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("Student cannot be null!");
                return;
            }

            Students.Add(student);

            string json = JsonSerializer.Serialize(
                Students,
                new JsonSerializerOptions { WriteIndented = true }
            );

            File.WriteAllText("gradebook.json", json);

            Console.WriteLine("Student created successfully.");
        }

        public Student Get(Guid studentId)
        {
            return Students.FirstOrDefault(s => s.StudentId == studentId);
        }

        public List<Student> GetAll()
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

                string json = JsonSerializer.Serialize(
                    Students,
                    new JsonSerializerOptions { WriteIndented = true }
                );

                File.WriteAllText("gradebook.json", json);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void Update(Guid studentId)
        {
            // Update implementation requires replacement student information.
        }
    }
}
