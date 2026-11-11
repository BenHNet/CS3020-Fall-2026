using System.Collections.Generic;

namespace StudentGradebookLibrary
{
    internal interface IRepo
    {
        void SaveStudents(List<Student> students);
        List<Student> GetStudents();

        //void SaveCourses(List<Course> courses);
        //List<Course> GetCourses();

        //void SaveCourseInstances(List<CourseInstance> courseInstances);
        //List<CourseInstance> GetCourseInstances();

        //void SaveStudentCourseInstances(List<StudentCourseInstance> studentCourseInstances);
        //List<StudentCourseInstance> GetStudentCourseInstances();
    }
}