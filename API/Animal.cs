namespace API;

public class Animal(int id, string name, string category, double weight, string colour)
{
    public int Id { set; get; } = id;
    public string Name { set; get; } = name;
    public string Category { set; get; } = category;
    public double Weight { set; get; } = weight;
    public string Colour { set; get; } = colour;

}