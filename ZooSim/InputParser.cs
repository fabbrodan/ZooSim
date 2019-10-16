using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ZooSim.Animals;
using ZooSim.Interfaces;
using ZooSim.Factories;

namespace ZooSim
{
    public class InputParser
    {
        public InputParser(ref List<IAnimal> animalList)
        {
            _animalList = animalList;

        }

        private List<IAnimal> _animalList;

        private  AnimalFactory _animalFactory = null;

        public void ParseInput(string input)
        {
            string[] inputAsArray = input.Split(" ");
            string command = inputAsArray[0];

            if (command == "Add")
            {
                string Name = inputAsArray[2];
                int Age = Int32.Parse(inputAsArray[3]);
                string animalAsString = inputAsArray[1];
                if (animalAsString == "Elephant")
                {
                    _animalFactory = new ElephantFactory(Name, Age);
                    Elephant elephant = (Elephant)_animalFactory.GetAnimal();
                    _animalList.Add(elephant);
                    _animalFactory = null;
                }

                if (animalAsString == "Monkey")
                {
                    _animalFactory = new MonkeyFactory(Name, Age);
                    Monkey monkey = (Monkey)_animalFactory.GetAnimal();
                    _animalList.Add(monkey);
                    _animalFactory = null;
                }
            }
            else if (command == "Kill")
            {
                string Name = inputAsArray[1];
                _animalList.Remove(_animalList.First(a => a.GetName() == Name));
            }
        }
    }
}
