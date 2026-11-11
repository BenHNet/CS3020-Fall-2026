using StudentGradebookLibrary.Models;
using System;
using System.Collections.Generic;

namespace StudentGradebookLibrary.Managers
{
    // Interface for StudentManager class
    public interface IStudentManager
    {
        void Create(IStudent student);

        IStudent Get(Guid studentId);

        List<IStudent> GetAll();

        void Delete(Guid studentId);

        void Update(IStudent student);
    }
}