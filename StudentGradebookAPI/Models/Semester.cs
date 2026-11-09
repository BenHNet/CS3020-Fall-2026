using System.Text.Json.Serialization;

namespace StudentGradebookAPI.Models;

[JsonConverter(typeof(JsonStringEnumConverter<Semester>))]
public enum Semester
{
    Spring,
    Summer,
    Fall
}