namespace API;

public class Visit(string dateOfTheVisit, Animal animalOnVisit, string description, double price)
{
    public string DateOfTheVisit { get; set; } = dateOfTheVisit;
    public Animal AnimalOnVisit { get; set; } = animalOnVisit;
    public string Description { get; set; } = description;
    public double Price { get; set; } = price;
}