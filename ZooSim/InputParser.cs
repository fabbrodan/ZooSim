using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ZooSim.Animals;
using ZooSim.Interfaces;
using ZooSim.Factories;

namespace ZooSim
{
    public static class InputParser
    {
        private static AnimalFactory _animalFactory = null;
        private static string CommandString = String.Empty;
        private static string[] _commands = new string[]
        {
            "Feed",
            "Kill",
            "Add"
        };

        private static string[] _animals = new string[]
        {
            "Elephant",
            "Monkey"
        };

        public static IAnimal ParseActionInput(string input)
        {
            string name = "";
            int age = 0;

            if (_commands.Contains(input.Split(" ")[0]))
            {
                CommandString += input.Split(" ")[0];
            }

            if (_animals.Contains(input.Split(" ")[1]))
            {
                CommandString += input.Split(" ")[1];
            }

            if (!String.IsNullOrEmpty(input.Split(" ")[2]))
            {
                name = input.Split(" ")[2];
            }

            if (!String.IsNullOrEmpty(input.Split(" ")[3]))
            {
                age = Int32.Parse(input.Split(" ")[3]);
            }

            if (CommandString == "AddElephant")
            {
                _animalFactory = new ElephantFactory(name, age);
                Elephant elephant = (Elephant)_animalFactory.GetAnimal();
                _animalFactory = null;
            }


            return null;
        }
    }
}
