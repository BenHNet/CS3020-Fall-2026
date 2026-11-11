using System;

namespace StudentGradebookLibrary.Models
{
    public class Student : IStudent
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
