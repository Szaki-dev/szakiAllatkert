using System.ComponentModel.DataAnnotations;

namespace szakiAllatkert.Models;



public class Animal {

    [MinLength(3)]
    public string Name {get;set;}
    [MinLength(3)]
    public string Species {get;set;}
    [Required]
    [Range(1, 100)]
    public int Age {get;set;}

    public List<Animal> Animals = new List<Animal>();

    public List<Animal> LoadFile(string path)
    {
        if (!File.Exists(path))
        {
            return new List<Animal>();
        }

        string[] lines = File.ReadAllLines(path);
        lines = lines.Skip(1).ToArray();
        foreach (string line in lines)
        {
            if(line == "") continue;
            string[] split = line.Split(';');
            Animal animal = new()
            {
                Name = split[0],
                Species = split[1],
                Age = int.Parse(split[2])
            };
            Animals.Add(animal);
        }
        return Animals;
    }
}