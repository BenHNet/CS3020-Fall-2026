using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;



namespace StudentGradebookLibrary
{
    // Interface for StudentManager class
    public interface IStudentManager
    {
        void Create(Student student);

        public Student Get(Guid StudentId);

        public List<Student> GetAll();

        void Delete(Guid StudentId);

        void Update(Guid StudentId);

     
    }
}