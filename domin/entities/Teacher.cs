namespace DemoApi.domin.entities;

public class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<Student> Students { get; set; } = new List<Student>();
}