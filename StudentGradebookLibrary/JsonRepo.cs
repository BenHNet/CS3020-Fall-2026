using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace StudentGradebookLibrary
{
    internal class JsonRepo : IRepo
    {
        private readonly string _folder;
        private static readonly JsonSerializerOptions _options =
            new JsonSerializerOptions { WriteIndented = true };

        public JsonRepo(string folder = "GradebookData")
        {
            _folder = folder;

            // Create the folder if it doesn't already exist
            Directory.CreateDirectory(_folder);   
        }


        private void SaveList<T>(List<T> items, string fileName)
        {
            // convert the list to JSON text
            string json = JsonSerializer.Serialize(items, _options);

            // write the text to file, replacing old contents
            File.WriteAllText(Path.Combine(_folder, fileName), json);
        }


        private List<T> LoadList<T>(string fileName)
        {
            // build full path for student data
            string path = Path.Combine(_folder, fileName);
            if (!File.Exists(path))
            {
                // nothing saved yet resulting in an empty list
                return new List<T>();             
            }

            string json = File.ReadAllText(path);
            try
            {
                // convert the JSON back into a list; if the result is null, use an empty list
                return JsonSerializer.Deserialize<List<T>>(json, _options) ?? new List<T>();
            }
            // file isn't valid JSON 
            // return an empty list instead of crashing
            catch (JsonException)
            {
                return new List<T>();       
            }
        }



        public void SaveStudents(List<Student> students) => SaveList(students, "students.json");
        public List<Student> GetStudents() => LoadList<Student>("students.json");

        // public void SaveCourses(List<Course> courses) => SaveList(courses, "courses.json");
        // public List<Course> GetCourses() => LoadList<Course>("courses.json");

        // public void SaveCourseInstances(List<CourseInstance> courseInstances) => SaveList(courseInstances, "courseInstances.json");
        // public List<CourseInstance> GetCourseInstances() => LoadList<CourseInstance>("courseInstances.json");
        
        // public void SaveStudentCourseInstances(List<StudentCourseInstance> studentCourseInstances) => SaveList(studentCourseInstances, "studentCourseInstances.json");
        // public List<StudentCourseInstance> GetStudentCourseInstances() => LoadList<StudentCourseInstance>("studentCourseInstances.json");
    }
}