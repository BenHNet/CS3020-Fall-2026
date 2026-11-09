using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;



namespace StudentGradebookLibrary
{

    // StudentManager class implements the iStudentManager interface
    public class StudentManager : IStudentManager
    {
        private List<Student> Students;

        public StudentManager()
        {

           this.Students = GetAll();
        }

        // Implement Methods from iStudentManager interface below
        public void Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty!");
                return;
            }

            Student student = new Student(name);

            Students.Add(student);

            string json = JsonSerializer.Serialize(
                Students,
                new JsonSerializerOptions { WriteIndented = true }
            );

            File.WriteAllText("gradebook.json", json);

            Console.WriteLine("Student created successfully.");
        }

        public void Get()
        {
            if (File.Exists("gradebook.json"))
            {
                string json = File.ReadAllText("gradebook.json");

                Students = JsonSerializer.Deserialize<List<Student>>(json)
                           ?? new List<Student>();
            }
            else
            {
                Students = new List<Student>();
            }
        }

        public List<Student> GetAll()
        {
            return Students;
        }

        public void Delete(Student student)
        {
            // Find a student with a matching name
            int replacementIndex = Students.FindIndex(s => s.Name == student.Name);

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

        public void Update(Student student)
        {
            // Find a student with a matching name
            int replacementIndex = Students.FindIndex(s => s.Name == student.Name);

            // If the index has been found, replace that element with new student
            if (replacementIndex != -1)
            {
                Students[replacementIndex] = student;

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


    }
}
