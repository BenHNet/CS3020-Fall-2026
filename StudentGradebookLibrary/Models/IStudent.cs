using System;

namespace StudentGradebookLibrary.Models
{
    public interface IStudent
    {
        Guid StudentId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
