using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace DemoApi.domin.entities;

public class Student
{
    public int Id { get; init; }
    public string Name { get; private set; } = null!; 
    public int? TeacherId { get; private set; }
    private string? _passWordHash; // 成员变量没有对应属性，但是要求EF Core映射到数据库中
    private string? _remark; //只读，从数据库里取值，不能修改

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
   
    //get
    public string GetRemark()
    {
        return _remark ?? string.Empty;
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
    public void ChangePassword(string newValue)
    {
        if (newValue.Length < 6)
        {
            throw new ArgumentException("密码太短");
        }
        var hasher = new PasswordHasher<string>();
        _passWordHash =hasher.HashPassword(null,newValue);
    }
}