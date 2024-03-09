using System;
using System.Text.RegularExpressions;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            View view = new View();
            Model pet = new Model();
            
            Console.Write("Enter your pet's name: ");
            string petName = "";
            while (!(Regex.IsMatch(petName, @"^[a-zA-Z]+$")))
            {
                petName = Console.ReadLine();
            }
            pet.Name = petName;

            Console.WriteLine("Choose your pet's type:");
            Console.WriteLine("1. Dog");
            Console.WriteLine("2. Cat");
            Console.WriteLine("3. Hamster");
            int petAnimal = -1;
            while (petAnimal == -1)
            {
                try { petAnimal = Convert.ToInt32(Console.ReadLine()); }
                catch { }
                switch (petAnimal)
                {
                    case 1:
                        pet.Animal = 0;
                        break;
                    case 2:
                        pet.Animal = 1;
                        break;
                    case 3:
                        pet.Animal = 2;
                        break;
                    default:
                        Console.WriteLine("Wrong command!");
                        petAnimal = -1;
                        continue;
                }
            }

            pet = pet.CreatePet(pet);

            Control control = new Control(view, pet);
            while (pet.Lives != 0)
            {
                control.StartGame();
            }

            control.GameOver(pet.Name);
            Console.ReadKey();
        }
    }
}
