using System;
using System.Collections.Generic;

namespace StudentGradebookLibrary
{
    // Interface for StudentManager class
    public interface IStudentManager
    {
        void Create(IStudent student);

        Student Get(Guid studentId);

        List<Student> GetAll();

        void Delete(Guid studentId);

        void Update(Student student);
    }
}