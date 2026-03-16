namespace DemoApi.Infrastructure.Entities;

public class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public int? TeacherId { get; set; }

    public Teacher? Teacher { get; set; }
}