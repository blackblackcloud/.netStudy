namespace DemoApi.domin.entities;

public class Student
{
    public int Id { get; init; }

    public string Name { get; private set; } = null!; 
    public int? TeacherId { get; private set; }
    public Teacher? Teacher { get;  private set; }
    public Student()
    {

    }
    public Student(string stuName)
    {
        SetName(stuName);
    }
    public void UpdateName(string name)
    {
        SetName(name);
    }
   

    public void AssignTeacher(int teacherId)
    {
        if (teacherId <= 0)
        {
            throw new ArgumentException("老师Id必须大于0", nameof(teacherId));
        }

        TeacherId = teacherId;
    }
    public void RemoveTeacher()
    {
        TeacherId = null;
        Teacher = null;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("学生姓名不能为空", nameof(name));
        }

        Name = name.Trim();
    }

}