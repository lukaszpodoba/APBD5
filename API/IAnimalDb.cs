namespace API;

public interface IAnimalDb
{
    public void AddAnimal(Animal animal);
    public void DeleteAnimal(Animal animal);
    public ICollection<Animal> PrintAllAnimals();
    public Animal? AnimalById(int id);
    public void UpdateAnimal(int id, Animal animal);
}