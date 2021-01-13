using _373260.karenchu.w2assignment;
using System;

namespace UCLA
{
    class Users: Stats
    {
        public static void GetPlayerInfo(Mage mage, Rogue rogue, Tank tank)
        {
            // Get player information
            // Set stats for Mage
            if (user_character == 1)
            {
                user_melee_damage = mage.getMeleDamage();
            }
            // Set user's stats for Rogue
            else if (user_character == 2)
            {
                user_melee_damage = rogue.getMeleDamage();
            }
            // Set user's stats for Tank
            else
            {
                user_melee_damage = tank.getMeleDamage(); 
            }
        }

    }
    class Computer
    {
        public static int computer_character { get; set; }

        public static void GetComputerInfo()
        {
            // Get computer and user info
            // Computer randomly chooses a character.
            Random rand = new Random();
            computer_character = rand.Next(1, 3);
            
            // Announce computer character
            if (computer_character == 1)
            {
                Console.WriteLine("Computer chose Mage!");
            }
            else if (computer_character == 2)
            {
                Console.WriteLine("Computer chose Rogue!");
            }
            else
            {
                Console.WriteLine("Computer chose Tank!");
            }

            Console.WriteLine("Fight!!");
        }
    }

    class FightingGame: Stats
    {
        static void Main(string[] args)
        {
            // Instantiate characters
            Mage mage = new Mage();
            Rogue rogue = new Rogue();
            Tank tank = new Tank();

            Random rand = new Random();

            // User selects character
            Console.WriteLine("Choose your character:");
            Console.WriteLine("1) Mage");
            Console.WriteLine("2) Rogue");
            Console.WriteLine("3) Tank");
            user_character = Convert.ToInt32(Console.ReadLine());

            Users.GetPlayerInfo(mage, rogue, tank);
            Computer.GetComputerInfo();

            // Main gameplay
            while (true)
            {
                // User chooses action. Depending on character, user has different actions
                Console.WriteLine("Choose your action: ");

                //Mage has special action menu
                if (user_character == 1)
                {
                    Base.ChooseAction();
                    if (user_special_attacks_left > 0)
                        Console.WriteLine(string.Format("3) Magic attack ({0} left)", user_special_attacks_left));
                }

                //Rogue and Tank have same action menu
                else
                {
                    Base.ChooseAction();
                }

                int user_action = Convert.ToInt32(Console.ReadLine());
                int computer_action = 0;

                // Computer chooses action depending on class
                // Health is calculated individual classes depending on character, to keep Main less cluttered
                // Computer mage action 
                if (Computer.computer_character == 1)
                {
                    if (!mage.CalculateHealth(computer_action, user_action)) break;
                }

                // Computer rogue action 
                else if (Computer.computer_character == 2)
                {
                    if (!rogue.CalculateHealth(computer_action, user_action)) break;

                }

                // Computer Tank action 
                else
                {
                    if (!tank.CalculateHealth(computer_action, user_action)) break;
                }

                //Console.WriteLine(String.Format("Computer is: {0} ", Computer.computer_character));
                Console.WriteLine(string.Format("User health: {0}", user_health));
                Console.WriteLine(string.Format("Computer health: {0}", computer_health));
            }

            // mage: 2 special attacks, weak melee
            // rogue: strong melee + random special attack
            // tank: if blocks special attack, reverses on them
            // block and attack

        }
    }
}
