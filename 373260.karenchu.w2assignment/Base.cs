using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _373260.karenchu.w2assignment
{
    public abstract class Base: Stats
    {
        // Override Melee Damage and Unique Power in unique classes
        public virtual int getMeleDamage()
        {
            return 0;
        }
        public virtual int getUniquePower()
        {
            return 0;
        }
        public static void ChooseAction()
        {
            Console.WriteLine("1) Block");
            Console.WriteLine("2) Melee attack");

        }

        public abstract bool CalculateHealth(int computer_action, int user_action);

    }

}
