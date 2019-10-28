using NUnit.Framework;
using System;
using ZooSim;
using ZooSim.Animals;
using ZooSim.Interfaces;
using System.Collections.Generic;

namespace ZooTest
{
    public class ZooTests
    {
        static Zoo zoo = new Zoo();
        
        [Test]
        public void _1_TestAddMultiple()
        {
            List<IAnimal> animals = new List<IAnimal>()
            {
                new Elephant("Test1", 2),
                new Monkey("Test2", 5),
                new Penguin("Test3", 6),
                new Elephant("Test4", 9)
            };
            
            foreach (IAnimal animal in animals)
            {
                zoo.Animals.Add(animal);
            }

            Assert.AreEqual(4, zoo.Animals.GetAnimals().Count);
        }

        [Test]
        public void _2_TestAddSingle()
        {
            zoo.Animals.Add(new Elephant("Test", 15));
            Assert.AreEqual("Elephant Test1 is 2 years old. It is currently 0 hungry and 15 energetic.", zoo.Animals.GetAnimals()[0].GetState());
        }

        [Test]
        public void _3_TestKill()
        {
            IAnimal animal = zoo.GetAnimals()[0];
            zoo.Animals.Remove(animal);
            Assert.AreEqual("Test2", zoo.Animals.GetAnimals()[0].GetName());
        }

        [Test]
        public void _4_TestUpdate()
        {
            zoo.Animals.GetAnimals()[0].Update(DateTime.Now.AddMinutes(5));
            Assert.AreEqual("Monkey Test2 is 5 years old. It is currently 1 hungry and 24 energetic.", zoo.Animals.GetAnimals()[0].GetState());
        }

        [Test]
        public void _5_TestEat()
        {
            zoo.Animals.GetAnimals()[0].Eat();
            Assert.AreEqual("Monkey Test2 is 5 years old. It is currently 0 hungry and 24 energetic.", zoo.Animals.GetAnimals()[0].GetState());
        }

        [Test]
        public void _6_TestSleep()
        {
            zoo.Animals.GetAnimals()[0].Sleep();
            Assert.AreEqual("Monkey Test2 is 5 years old. It is currently 0 hungry and 25 energetic.", zoo.Animals.GetAnimals()[0].GetState());
        }
    }

    public class AnimalTest
    {
        IAnimal monkey = new Monkey("MonkeyTest", 5);
        IAnimal elephant = new Elephant("ElephantTest", 5);
        IAnimal penguin = new Penguin("PenguinTest", 5);
        DateTime passedTime = DateTime.Now;
        [Test]
        public void _1_TestMonkeyUpdate()
        {
            DateTime newPassedTime = passedTime;
            for (int i = 0; i < 9; i++)
            {
                monkey.Update(newPassedTime);
                newPassedTime = newPassedTime.AddMinutes(5);
            }
            Assert.AreEqual("Monkey MonkeyTest is 5 years old. It is currently 8 hungry and 17 energetic.", monkey.GetState());
        }

        [Test]
        public void _1_TestElephantUpdate()
        {
            elephant.Update(passedTime.AddMinutes(2));
            Assert.AreEqual("Elephant ElephantTest is 5 years old. It is currently 1 hungry and 14 energetic.", elephant.GetState());
        }

        [Test]
        public void _1_TestPenguinUpdate()
        {
            penguin.Update(passedTime.AddMinutes(5));
            Assert.AreEqual("Penguin PenguinTest is 5 years old. It is currently 1 hungry and 14 energetic.", penguin.GetState());
        }

        [Test]
        public void _2_TestMonkeySleep()
        {
            monkey.Sleep();
            Assert.AreEqual("Monkey MonkeyTest is 5 years old. It is currently 8 hungry and 25 energetic.", monkey.GetState());
        }

        [Test]
        public void _2_TestElephantSleep()
        {
            elephant.Sleep();
            Assert.AreEqual("Elephant ElephantTest is 5 years old. It is currently 1 hungry and 15 energetic.", elephant.GetState());
        }
        [Test]
        public void _2_TestPenguinSleep()
        {
            penguin.Sleep();
            Assert.AreEqual("Penguin PenguinTest is 5 years old. It is currently 1 hungry and 15 energetic.", penguin.GetState());
        }
        [Test]
        public void _3_TestMonkeyEat()
        {
            monkey.Eat();
            Assert.AreEqual("Monkey MonkeyTest is 5 years old. It is currently 0 hungry and 25 energetic.", monkey.GetState());
        }
        [Test]
        public void _3_TestElephantEat()
        {
            elephant.Eat();
            Assert.AreEqual("Elephant ElephantTest is 5 years old. It is currently 0 hungry and 15 energetic.", elephant.GetState());
        }
        [Test]
        public void _3_TestPenguinEat()
        {
            penguin.Eat();
            Assert.AreEqual("Penguin PenguinTest is 5 years old. It is currently 0 hungry and 15 energetic.", penguin.GetState());
        }

        [Test]
        public void _4_TestAge()
        {
            monkey.Update(passedTime.AddDays(1));
            Assert.AreEqual("Monkey MonkeyTest is 6 years old. It is currently 1 hungry and 24 energetic.", monkey.GetState());
        }
    }

    public class FinancialTest
    {
        static Zoo zoo = new Zoo();

        [Test]
        public void _1_TestLoan()
        {
            zoo.Account.AddLoan(100);
            Assert.AreEqual(1100m, zoo.Account.GetBalance());
            Assert.AreEqual(100m, zoo.Account.GetLoan());
        }

        [Test]
        public void _2_TestInterest()
        {
            zoo.Account.WithdrawInterest(DateTime.Now.AddMinutes(8));
            Assert.AreEqual(1085m, zoo.Account.GetBalance());
        }

        [Test]
        public void _3_TestPayLoan()
        {
            zoo.Account.PayLoan(50m);
            Assert.AreEqual(1035m, zoo.Account.GetBalance());
            Assert.AreEqual(50m, zoo.Account.GetLoan());
        }
    }
}