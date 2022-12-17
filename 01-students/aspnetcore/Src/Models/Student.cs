using System;
using System.Collections.Generic;

public class Student
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public int Course { get; set; }
    public string Group { get; set; }
    public List<int> Points { get; set; }

    public Student (string surname, string name, int course, string group, IList<int> points) 
    {
        this.Surname = surname;
        this.Name = name;
        this.Course = course;
        this.Group = group;
        this.Points = new List<int>(); 
        this.Points.AddRange(points);
    }
}
