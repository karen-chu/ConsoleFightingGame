using System;
using DevExpress.Xpo;

namespace _373260.karenchu.w2assignment
{
   public class Stats {

        // Important stats for game
        // Make public static so that it can be accessible in FightingGame class
        public static int user_special_attacks_left = 2;
        public static int user_health = 100;
        public static int user_melee_damage = 0;

        public static int computer_special_attacks_left = 2;
        public static int computer_health = 100;
        public static int computer_melee_damage = 0;

        //Initialize computer info
        public static int computer_character = 0;
        public static Random rand = new Random();

        //Initialize user info
        public static int user_character { get; set; }

    }

}