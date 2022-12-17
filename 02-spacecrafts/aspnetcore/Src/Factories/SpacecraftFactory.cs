using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

public record Category ( string Name, 
    int MinCargo, int MaxCargo, 
    int MinGuns, int MaxGuns,
    int MinMissiles, int MaxMissiles,
    int MinThrusters, int MaxThrusters,
    int MinAgility, int MaxAgility ); 

public record NumericRange ( int Min, int Max );

public class Input 
{
    public string[] ManufacturerNames { get; set; }
    public NumericRange ManufactureYears { get; set; }
    public Category[] Categories { get; set; }

    public Input() { }
}

public class SpacecraftFactory: Factory<Spacecraft>
{
    static Input input = JsonSerializer.Deserialize<Input> (
        File.ReadAllText("../science/input.json"),
        new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
    ); 
    static int id = 0;

    public SpacecraftFactory() 
    {
        // Console.WriteLine(File.ReadAllText("../science/input.json"));
        // Console.WriteLine(input.ManufactureYears.Min);
    }

    protected override Spacecraft GenerateImpl() 
    {
        var r = Random.Shared;
        var category = r.Choice(input.Categories);
        return new Spacecraft {
            Id = ++id, 
            Manufacturer = r.Choice(input.ManufacturerNames),
            ManufactureYear = r.RandInt(input.ManufactureYears.Min, input.ManufactureYears.Max),
            Category = category.Name,
            Cargo = r.RandInt(category.MinCargo, category.MaxCargo),
            Guns = r.RandInt(category.MinGuns, category.MaxGuns),
            Missiles = r.RandInt(category.MinMissiles, category.MaxMissiles),
            Thrusters = r.RandInt(category.MinThrusters, category.MaxThrusters),
            Agility = r.RandInt(category.MinAgility, category.MaxAgility)
        };
    }
}
