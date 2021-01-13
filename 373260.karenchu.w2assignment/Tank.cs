using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCLA;

namespace _373260.karenchu.w2assignment
{
    public class Tank : Base
    {
        public override int getMeleDamage()
        {
            return 10;
        }

        public override int getUniquePower()
        {
            return 5;
        }

        public override bool CalculateHealth(int computer_action, int user_action)
        {
            Console.WriteLine(Base.computer_character);
            Console.Read();

            Mage mage = new Mage();
            Rogue rogue = new Rogue();

            computer_melee_damage = getMeleDamage();

          

            // Computer randomly choose action.
            computer_action = rand.Next(1, 3);
            //Console.WriteLine(string.Format("Comp action {0}", computer_action));


            // Calculate outcome of computer and user collision

            // Damage only occurs if both user and computer attacked at the same time
            if (computer_action > 1 && user_action > 1)
            {
                // User did melee attack
                if (user_action == 2)
                {
                    int total_damage = user_melee_damage;

                    // Is User a rogue? If so, calculate if rogue landed 20% chance of critical hit
                    int critical_hit = rand.Next(1, 6);
                    if (Computer.computer_character == 2 && critical_hit == 1)
                    {
                        total_damage += rogue.getUniquePower();

                        // Tank's special power is to reflect special attacks. So damage reflects to enemy
                        user_health -= total_damage;
                    }
                    // if not a special attack against Tank...
                    else
                    {
                        computer_health -= total_damage;

                        // Tank armor absorbs 5 damage every normal attack
                        computer_health += getUniquePower();
                    }


                    if (computer_health <= 0)
                    {
                        Console.WriteLine("Computer died. You win!");
                        return false;
                    }
                }
                // User did magic attack
                else
                {
                    // Tank's special power is to reflect special attacks. So damage reflects to enemy
                    user_health -= mage.getUniquePower();

                    // User has one special attack less
                    user_special_attacks_left -= 1;

                    if (computer_health <= 0)
                    {
                        Console.WriteLine("Computer died. You win!");
                    }
                }

                // Computer did melee attack
                if (computer_action == 2)
                {
                    user_health -= computer_melee_damage;

                    // if user is Tank, armor absorbs 5 damage
                    if (Base.user_character == 3)
                    {
                        user_health += getUniquePower();

                    }


                    if (user_health <= 0)
                    {
                        Console.WriteLine("You died. You lose!");
                    }
                }
            }
            else
            {
                // Handling scenario when user is a Tank
                if (Base.user_character == 3)
                {
                    // Did computer mage fire off a special attack? If so, then attack rebounds back to computer
                    if (computer_action == 3)
                    {
                        computer_health -= mage.getUniquePower();
                        Console.WriteLine(string.Format("Tank special armor rebounds attack. {0} damage against computer.", mage.getUniquePower()));
                    }

                    // Is User a rogue? If so, calculate if rogue landed 20% chance of critical hit. 
                    // If it hits, then attack rebounds back to computer
                    int critical_hit = rand.Next(1, 6);
                    if (Base.computer_character == 2 && critical_hit == 1)
                    {
                        computer_health -= computer_melee_damage + rogue.getUniquePower();
                        Console.WriteLine(string.Format("Tank special armor rebounds attack. {0} damage against computer.", computer_melee_damage + rogue.getUniquePower()));
                    }
                }
                else
                {
                    Console.WriteLine("Attack blocked. No damage!!");

                }

            }
            return true;
        }

    }

}
