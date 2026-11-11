using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentGradebookLibrary
{
    public class CourseManager
    {
        public List<Course> Courses = new List<Course>();

        public void Create()
        {
            Console.Write("\nCourse name: ");
            string courseName = Console.ReadLine();

            if (string.IsNullOrEmpty(courseName))
            {
                Console.WriteLine("Course cannot be empty!\n");
                return;
            }

            foreach (var course in this.Courses)
            {
                if (course.Title == courseName)
                {
                    Console.WriteLine("Course already exists.\n");
                    return;
                }
            }

            Console.Write("\nCourse description: ");
            string desc = Console.ReadLine();

            if (string.IsNullOrEmpty(desc))
            {
                Console.WriteLine("Description cannot be empty!\n");
                return;
            }

            this.Courses.Add(new Course(Guid.NewGuid(), courseName, desc));
            Console.WriteLine("Course added successfully.\n");
        }

        public List<Course> GetList()
        {
            return this.Courses;
        }

        public Course Get(Guid courseID)
        {
            return this.Courses.Find(course => course.CourseID == courseID);
        }

        public void Update(Guid courseID, string title, string description)
        {
            var course = Get(courseID);

            if (course == null)
            {
                return;
            }

            course.Title = title;
            course.Description = description;
        }

        public void Delete(int index)
        {
            if (index < 1 || index > this.Courses.Count)
            {
                Console.WriteLine("Invalid selection.\n");
                return;
            }
            this.Courses.RemoveAt(index - 1);
        }
    }
}
