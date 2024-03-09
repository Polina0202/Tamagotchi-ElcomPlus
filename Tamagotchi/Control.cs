using System;

namespace Tamagotchi
{
    class Control
    {
        View view;
        Model pet;

        public Control(View view, Model pet)
        {
            this.view = view;
            this.pet = pet;
        }

        public void StartGame()
        {
            Console.Clear();
            view.InfoGame();
            view.PetIndecators(pet);
            view.Menu();
            int action = 0;
            try
            {
                action = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
            }
            
            SelectedAction(action, pet);
            if (pet.Animal == 2)
                pet.Hunger++;
        }

        public void GameOver(string petName)
        {
            view.GameOver(petName);
        }

        private void SelectedAction(int action, Model pet)
        {
            switch (action)
            {
                case 1:
                    pet = pet.Feed(pet);
                    break;
                case 2:
                    pet = pet.Play(pet);
                    break;
                case 3:
                    pet = pet.Sleep(pet);
                    break;
                case 4:
                    pet = pet.Heal(pet);
                    break;
            }

            pet = pet.Dead(pet);
        }
    }
}
