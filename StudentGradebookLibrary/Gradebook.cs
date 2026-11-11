using StudentGradebookLibrary.Models;
using StudentGradebookLibrary.Repos;
using System;
using System.Collections.Generic;

namespace StudentGradebookLibrary
{
    public class GradebookManager
    {
        private List<Student> Students = new List<Student>();
        private readonly IRepo _repo = new JsonRepo();
        private const string FilePath = "gradebook.json";

        public void AddStudent()
        {
            Console.Write("\nStudent name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty!");
                return;
            }

            this.Students.Add(new Student() { LastName = name, StudentId = Guid.NewGuid() });
            Console.WriteLine("Student added successfully.");
        }

        public void AddGrade()
        {
            if (this.Students.Count == 0)
            {
                Console.WriteLine("No students available!");
                return;
            }
                        
            for (int i = 0; i < this.Students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {this.Students[i].LastName}");
            }

            Console.Write("Select a student:");
            string input = Console.ReadLine();

            bool isValid = int.TryParse(input, out int index);
            if (!isValid || index < 1 || index > this.Students.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var student = this.Students[index - 1];

            Console.Write("\nEnter subject: ");
            string subject = Console.ReadLine();

            Console.Write("Enter grade (0-100): ");
            string markStr = Console.ReadLine();

            bool isValidMark = double.TryParse(markStr, out double grade);
            if (!isValidMark || grade < 0 || grade > 100)
            {
                Console.WriteLine("Invalid grade.");
                return;
            }

            Console.WriteLine("Gradind is not available at this time");
        }

        public void DisplayAll()
        {
            if (this.Students.Count == 0)
            {
                Console.WriteLine("No students available!");
                return;
            }

            foreach (var student in this.Students)
            {
                Console.WriteLine("\n" + student);
            }
        }

        public void SaveData()
        {
            _repo.SaveStudents(this.Students);
        }

        public void LoadData()
        {
            this.Students = _repo.GetStudents();
        }
    }
}
