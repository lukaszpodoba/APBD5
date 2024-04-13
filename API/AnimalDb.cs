namespace API;

public class AnimalDb : IAnimalDb
{
    private static ICollection<Animal> _animalsDataBase;

    public AnimalDb()
    {
        _animalsDataBase = new List<Animal>
        {
            new (1, "Rex", "Dog", 7.0, "Brown"),
            new (2, "Bella", "Cat", 3.5, "White"),
            new (3, "Bob", "Rhino", 1849.75, "Grey"),
            new (4, "Marlena", "Giraffe", 840.40, "Yellow")
        };
    }
    
    public void AddAnimal(Animal animal)
    {
        _animalsDataBase.Add(animal);
    }

    public void DeleteAnimal(Animal animal)
    {
        _animalsDataBase.Remove(animal);
    }

    public ICollection<Animal> PrintAllAnimals()
    {
        return _animalsDataBase;
    }

    public Animal? AnimalById(int id)
    {
        return _animalsDataBase.FirstOrDefault(a => a.Id == id);
    }

    public void UpdateAnimal(int id, Animal animal)
    {
        Animal exists = _animalsDataBase.FirstOrDefault(a => a.Id == id);
        if (exists != null)
        {
            exists.Id = animal.Id;
            exists.Name = animal.Name;
            exists.Category = animal.Category;
            exists.Weight = animal.Weight;
            exists.Colour = animal.Colour;
        }
        else
        {
            Console.WriteLine("Wrong value");
        }
    }
}