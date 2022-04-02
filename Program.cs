/*
Program - week10Assignment
Programer - Toby Cantello
Date Created - 4/1/2022
Last Date Updated - 4/2/2022
*/

using System;

namespace week10Assignment
{
    class Fighter
    {
        string name;
        public int maxHealth = 20;
        public int currentHealth;
        public bool dead = true;

        public Fighter(string n)
        {
            name = n;
        }
        public string Name
        { 
            get { return name; } 
            set { name = value; }
        }
        public void PrintWelcome()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**********************************************");
            Console.WriteLine();
            Console.WriteLine("Welcome to the arena " + Name + "!" + "   GOOD LUCK!!!!!");
            Console.WriteLine();
            Console.WriteLine("**********************************************");
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void Health()
        { 
         
        }
        public int CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }
    }

    class Enemy
    {

    }

    class Player : Fighter
    {
        public Player(string n) : base(n)
        {
            Name = n;
        }
        public static void TakeAction(int choice)
        {
            
        }
    }

    class Program
    {
        
        public void Rules()
        {
            Console.WriteLine("The Rules:");
            Console.WriteLine();
            Console.WriteLine("This is you against the enemy. First one to run out of health will be declared dead and the other player will be declared the winner."+
                "Both players will start out with 20 units of health. You as the player will have 3 chances to replish your health with the use of potions. The use of " +
                "a potion will result in the loss of an attack. The potion will restore anywhere from 5 to 20 units of health each time it is used. However the use of " +
                "a potion will not result in your health going above 20 units. An attack will result in anywhere from 0 to 5 units of damage. The enemy will always " +
                "attack each turn.");
            Console.WriteLine();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int roundCounter = 1;

            Console.WriteLine("WELCOME TO THE COMBAT ARENA!!");
            Console.WriteLine();
            Console.WriteLine("Please enter your name: ");
            Fighter p1 = new Fighter(Console.ReadLine());
            Fighter p2 = new Fighter("Enemy");
            p1.PrintWelcome();

            Program instructions = new Program();
            instructions.Rules();

            p1.CurrentHealth = 20;
            p2.CurrentHealth = 20;
            while (p1.CurrentHealth > 0)
            {
                Console.WriteLine();
                Console.WriteLine("**********************************************");
                Console.WriteLine("Round: " + roundCounter);
                Console.WriteLine("**********************************************");
                Console.WriteLine();
                Console.WriteLine(p1.Name + ": " + p1.CurrentHealth + " health units.");
                Console.WriteLine(p2.Name + ": " + p2.CurrentHealth + " health units.");
                Console.WriteLine();
                Console.WriteLine(p1.Name + " , what would you like to do");
                Console.WriteLine("1 - Attack?");
                Console.WriteLine("2 - Heal by drinking a potion?");
                int userIput = Convert.ToInt32(Console.ReadLine());
                Player.TakeAction(userIput);
                roundCounter++; 
            }
        }
    }
}
