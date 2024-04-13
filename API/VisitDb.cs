namespace API;

public class VisitDb : IVisitDb
{
    private static ICollection<Visit> _visitDataBse;
    public VisitDb()
    {
        _visitDataBse = new List<Visit>()
        {
            new Visit("2024-01-14", new Animal(1, "Max", "Dog", 12.42, "Black"), "broken leg", 1400),
            new Visit("2023-11-23", new Animal(2, "Daisy", "Cat", 6.43, "Brown"), "stomachache", 550),
            new Visit("2023-11-23", new Animal(3, "Pixel", "Rhino", 1932.23, "Grey"), "control", 550),
            new Visit("2023-09-04", new Animal(4, "Nipple", "Giraffe", 742.12, "Yellow"), "control", 150)
        };
    }
    
    public ICollection<Visit> PreviousVisits(int id)
    {
        return _visitDataBse.Where(v => v.AnimalOnVisit.Id == id).ToList();
    }

    public void AddVisit(Visit visit)
    {
        _visitDataBse.Add(visit); 
    }
}