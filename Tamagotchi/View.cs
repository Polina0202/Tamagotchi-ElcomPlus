using System;

namespace Tamagotchi
{
    class View
    {
        public void InfoGame()
        {
            Console.WriteLine(" Some rules:");
            Console.WriteLine(" - Over-feeding lowers Health;");
            Console.WriteLine(" - Over-playing lowers Health and increases Hunger;");
            Console.WriteLine(" - Over-hunger lowers Health;");
            Console.WriteLine(" - Heal is only available if Happy > 5;");
            Console.WriteLine(" - If Health = 0, your pet dies.");
            Console.WriteLine("");
        }

        public void PetIndecators(Model pet)
        {
            Console.WriteLine(" Name: " + pet.Name);
            Console.WriteLine(" Animal: " + pet.AnimalString[pet.Animal]);

            if (pet.Animal == 1)
                Console.WriteLine(" Quantity of life: " + pet.Lives);
            Console.WriteLine("");
            Console.WriteLine(" Health: " + Status(pet.Health) + pet.Health + "/10");
            Console.WriteLine(" Hunger: " + Status(pet.Hunger) + pet.Hunger + "/10");
            Console.WriteLine(" Fatigue: " + Status(pet.Fatigue) + pet.Fatigue + "/10");
            Console.WriteLine(" Happy: " + Status(pet.Happy) + pet.Happy + "/10");
            Console.WriteLine("");
        }

        public string Status(int count)
        {
            string str1 = new string('■', count);
            string str2 = new string('_', 10 - count);
            string status = " |" + str1 + str2 + "| ";
            return status;

        }

        public void Menu()
        {
            Console.WriteLine(" Select action: ");
            Console.WriteLine(" 1. Feed");
            Console.WriteLine(" 2. Play");
            Console.WriteLine(" 3. Sleep");
            Console.WriteLine(" 4. Heal");
        }

        public void GameOver(string petName)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("     ██");
            Console.WriteLine("  ████████");
            Console.WriteLine("     ██");
            Console.WriteLine("     ██");
            Console.WriteLine(" ██████████");
            Console.WriteLine(" " + petName + " is dead!");
            Console.WriteLine(" ██████████");
        }
    }
}
