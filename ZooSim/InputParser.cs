using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ZooSim.Animals;
using ZooSim.Interfaces;
using ZooSim.Factories;
using ConsoleSimulationEngine2000;

namespace ZooSim
{
    public class InputParser
    {
        public InputParser(ref List<IAnimal> animalList, MySimulation sim)
        {
            logDisplay = (RollingDisplay)sim.Displays.First(l => l.GetType() == typeof(RollingDisplay));
            _animalList = animalList;

        }
        private RollingDisplay logDisplay;
        private List<IAnimal> _animalList;

        private  AnimalFactory _animalFactory = null;

        public void ParseInput(string input)
        {
            input.Trim();
            string[] inputAsArray = input.Split(" ");
            string command = inputAsArray[0];

            if (command == "Add")
            {
                if (inputAsArray[1] == "help")
                {
                    logDisplay.Log("Command \"Add\"");
                    logDisplay.Log("");
                    logDisplay.Log("Usage: Add [Animal] [Name] [Age]");
                    logDisplay.Log("");
                    logDisplay.Log("Add Elephant Bobby 5");
                    return;
                }

                string Name = String.Empty;
                int Age = 0;
                string animalAsString = String.Empty;
                Animal animalToAdd = null;
                try
                {
                    Name = inputAsArray[2];
                    Age = Int32.Parse(inputAsArray[3]);
                    animalAsString = inputAsArray[1];
                }
                catch (IndexOutOfRangeException)
                {
                    logDisplay.Log("Invalid Command!");
                    logDisplay.Log("See \"Add help\" for more info.");
                    return;
                }

                if (animalAsString == "Elephant")
                {
                    _animalFactory = new ElephantFactory(Name, Age);
                    animalToAdd = (Elephant)_animalFactory.GetAnimal();
                    _animalFactory = null;
                }

                if (animalAsString == "Monkey")
                {
                    _animalFactory = new MonkeyFactory(Name, Age);
                    animalToAdd = (Monkey)_animalFactory.GetAnimal();
                    _animalFactory = null;
                }

                if (animalAsString == "Penguin")
                {
                    _animalFactory = new PenguinFactory(Name, Age);
                    animalToAdd = (Penguin)_animalFactory.GetAnimal();
                    _animalFactory = null;
                }

                _animalList.Add(animalToAdd);
                logDisplay.Log(animalToAdd.GetState());
            }
            else if (command == "Kill")
            {
                string Name = inputAsArray[1];
                logDisplay.Log(Name + " is dead");
                _animalList.Remove(_animalList.First(a => a.GetName() == Name));
            }
            else if (command == "Feed")
            {
                string Name = inputAsArray[1];

            }
            else if (command == "Status")
            {
                string Name = inputAsArray[1];

                if (Name == "all")
                {
                    foreach (IAnimal animal in _animalList)
                    {
                        logDisplay.Log(animal.GetState());
                    }
                }
                else
                {
                    try
                    {
                        var animal = _animalList.First(a => a.GetName() == Name);
                        logDisplay.Log(animal.GetState());
                    }
                    catch (InvalidOperationException)
                    {
                        logDisplay.Log("There is no animal with the name " + Name);
                    }
                }
            }
            else
            {
                logDisplay.Log("Not a command");
            }
        }
    }
}
