namespace Tamagotchi
{
    class Model
    {
        private string _name;
        private int _animal;
        private int _lives;
        private int _health;
        private int _hunger;
        private int _fatigue;
        private int _happy;

        public string[] AnimalString = new string[3] { "Dog", "Cat", "Hamster"};
        
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != "")
                    _name = value;
                else _name = "MyPet";
            }
        }

        public int Animal
        {
            get { return _animal; }
            set
            {
                if (value == 0 || value == 1 || value == 2)
                    _animal = value;
                else _animal = 0;
            }
        }

        public int Lives
        {
            get { return _lives; }
            set
            {
                if ((_animal != 1 && (value == 0 || value == 1)) || (value >= 0 || value <= 9))
                    _lives = value;
                else _lives = 1;
            }
        }

        public int Health
        {
            get { return _health; }
            set
            {
                if (value >= 0 && value <= 10)
                    _health = value;
                else
                {
                    if (value <= 0)
                        _health = 0;
                    else _health = 10;
                }
            }
        }

        public int Hunger
        {
            get { return _hunger; }
            set
            {
                if (value >= 0 && value <= 10)
                    _hunger = value;
                else
                {
                    if (value <= 0)
                        _hunger = 0;
                    else _hunger = 10;
                }
            }
        }

        public int Fatigue
        {
            get { return _fatigue; }
            set
            {
                if (value >= 0 && value <= 10)
                    _fatigue = value;
                else
                {
                    if (value <= 0)
                        _fatigue = 0;
                    else _fatigue = 10;
                }
            }
        }

        public int Happy
        {
            get { return _happy; }
            set
            {
                if (value >= 0 && value <= 10)
                    _happy = value;
                else
                {
                    if (value <= 0)
                        _happy = 0;
                    else _happy = 10;
                }
            }
        }

        public Model Feed(Model pet)
        {
            if (pet.Hunger-1 >= 0)
            {
                pet.Hunger = pet.Animal == 2? pet.Hunger-2: pet.Hunger-1;
                return pet;
            }
            else
            {
                pet.Hunger = 0;
                pet.Health--;
                pet.Happy++;
                return pet;
            }
        }

        public Model Play(Model pet)
        {
            if (pet.Fatigue+1 <= 10)
            {
                pet.Happy = pet.Animal == 0? (pet.Happy+3) : pet.Happy+1;
                pet.Fatigue = pet.Animal == 0? (pet.Fatigue+4) : pet.Fatigue+1;
                return pet;
            }
            else
            {
                pet.Fatigue = 10;
                pet.Health--;
                pet.Hunger++;
                pet.Happy++;
                return pet;
            }
        }

        public Model Sleep(Model pet)
        {
            pet.Fatigue = 0;
            pet.Health++;
            pet.Hunger++;

            return pet;
        }

        public Model Heal(Model pet)
        {
            if (pet.Happy > 5)
            {
                pet.Health = 10;
                pet.Hunger = pet.Hunger - 5;
                pet.Happy--;

                return pet;
            }
            else
            {
                pet.Happy--;
                return pet;
            }
            
        }

        public Model CreatePet(Model pet)
        {
            pet.Health = 10;
            pet.Hunger = 0;
            pet.Fatigue = 0;
            pet.Happy = 0;

            if (pet.Animal == 1)
                pet.Lives = 9;
            else pet.Lives = 1;

            return pet;
        }

        public Model Dead(Model pet)
        {
            if (pet.Hunger == 10)
                pet.Health--;

            if (pet.Health == 0)
            {
                pet.Lives--;

                if (pet.Lives > 0)
                    pet = pet.CreatePet(pet);
            } 
            return pet;
        }
    }


}
