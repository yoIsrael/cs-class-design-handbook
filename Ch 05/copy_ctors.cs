using System;
using System.Reflection;
public class Teacher
{
   private int grade;
   private int salary;
   private string dept = String.Empty;

   public Teacher() {}

   public Teacher(int grade, int salary, string dept) 
   {
   	this.grade = grade;
   	this.salary = salary;
   	this.dept = dept;
   }

  public Teacher(Teacher teach)
 {
   PropertyInfo[] pInfoArray = teach.GetType().GetProperties();
   foreach(PropertyInfo pInfo in pInfoArray)
   {
      Type ty = pInfo.PropertyType;
      object myvalue = 
      teach.GetType().InvokeMember(pInfo.Name, 
                                   BindingFlags.GetProperty, null, 
                                   teach, null);
      teach.GetType().InvokeMember(pInfo.Name,
                                   BindingFlags.SetProperty, null, 
                                   this, new object[]{myvalue});
   }
  }

   	public int Grade { get { return grade; } set { grade = value; }}
	public int Salary { get { return salary; } set { salary = value; }}
	public string Dept { get { return dept; } set { dept = value; }}

	public object Clone()
	{
    	return new Teacher(grade, salary, dept);
	}
   	
}

public class mainTeacher
{
	static void Main()
	{
		Teacher teach1 = new Teacher(3, 23000, "IT");
		Teacher teach2 = new Teacher(teach1);
		Teacher teach3 = (Teacher)teach2.Clone();
		Console.WriteLine("Details of the First teacher are \nDept:{0} \nGrade:{1} \nSalary:{2}\n", teach1.Dept,teach1.Grade,teach1.Salary);
		Console.WriteLine("Details of the Second Teacher are \nDept:{0} \nGrade:{1} \nSalary:{2}\n", teach2.Dept, teach2.Grade, teach2.Salary);
		Console.WriteLine("Details of Third teacher are  \nDept:{0} \nGrade:{1} \nSalary:{2}", teach3.Dept,teach3.Grade,teach3.Salary);
	}
}
