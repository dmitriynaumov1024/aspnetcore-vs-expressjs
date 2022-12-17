using System;
using System.Collections.Generic;
using System.Linq;

public class StudentFactory: Factory<Student>
{
    public StudentFactory() { }

    static string[] Names = new[] { 
        "John", "Yana", "Steve", "Francis", "Liam",
        "Hanna", "Liss", "Kate", "Joseph", "Eva",
        "Rina", "Michael", "Antonio", "Leonard", "Benedict",
        "Thomas", "Mark", "Alexander", "Alexandra", "Susan" 
    };

    static string[] Surnames = new[] {
        "Johnson", "Juhansson", "Marks", "Peters", "Smith", 
        "Doe", "Willis", "Evans", "Reeves", "Stevenson",
        "Parks", "Kings", "Rishi", "Morinho", "Castillo"
    };

    static (int, string)[] CoursesAndGroups = new[] {
        (1, "6621-a"),
        (1, "6621-b"),
        (2, "6622-a"),
        (2, "6622-a"),
        (2, "6622-c"),
        (3, "6623-a"),
        (3, "6623-b")
    };

    static int[] MinPoints = new[] {
        35, 43, 53, 59, 61, 63, 65, 67, 70, 71,
        72, 72, 73, 73, 74, 74, 75, 75, 76, 76,
        77, 77, 79, 81, 83, 84, 86, 88, 90, 92
    };

    protected override Student GenerateImpl() 
    {
        (int course, string group) cg = Random.Shared.Choice(CoursesAndGroups);
        int minPoint = Random.Shared.Choice(MinPoints);
        return new Student (
            Random.Shared.Choice(Surnames),
            Random.Shared.Choice(Names),
            cg.course, cg.group,
            Enumerable.Range(0, Random.Shared.RandInt(6, 11))
                .Select(_ => Random.Shared.RandInt(minPoint, 101)).ToList()
        );
    }
}
