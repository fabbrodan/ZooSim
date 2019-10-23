namespace ZooSim.Interfaces
{
    public interface IAnimalFactory<T> where T : IAnimal
    {
        T GetAnimal(string name, int age);
    }
}
