using System;

public class Student
{
    public string Name { get; set; }
    private int average;

    public Student(string studentName, int studentAverage)
    {
        Name = studentName;
        Average = studentAverage;
    }

    public int Average
    {
        get
        {
            return average;
        }
    }

}