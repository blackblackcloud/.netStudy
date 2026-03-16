

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class CustomAttribute : Attribute
{
    public string TargetMethod { get; set; }

    public CustomAttribute(string targetMethod)
    {
        TargetMethod = targetMethod;
    }
}

[Custom("AdvanceWay")]
public class AdvanceService
{
    public void AdvanceWay()
    {
        Console.WriteLine("On the move!");
    }
}   

[Custom("RetreatWay")]
public class RetreatService
{
    public void RetreatWay()
    {
        Console.WriteLine("Be retreating!");
    }
}