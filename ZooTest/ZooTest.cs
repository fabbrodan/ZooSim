using NUnit.Framework;
using ZooSim;
using ZooSim.Factories;
using ZooSim.Animals;
using ZooSim.Interfaces;
using System.Collections.Generic;

namespace ZooTest
{
    public class ZooTests
    {
        static Zoo zoo = new Zoo();
        
        [Test]
        public void TestAddMultiple()
        {
            IAnimalFactory<Elephant> eFactory = new ElephantFactory();
            IAnimalFactory<Monkey> mFactory = new MonkeyFactory();

            zoo.Animals.Add(eFactory.GetAnimal("Test2", 18));
            zoo.Animals.Add(eFactory.GetAnimal("Test3", 10));
            zoo.Animals.Add(mFactory.GetAnimal("Test4", 5));

            Assert.AreEqual(3, zoo.Animals.Count);
        }

        [Test]
        public void TestAddSingle()
        {
            IAnimalFactory<Elephant> factory = new ElephantFactory();
            zoo.Animals.Add(factory.GetAnimal("Test", 15));

            Assert.AreEqual("Elephant Test2 is 18 years old. It is currently 0 hungry and 15 energetic.", zoo.Animals[0].GetState());
        }
    }
}