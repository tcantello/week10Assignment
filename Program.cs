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
        public static Random random = new Random();

        string name;
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
    }
    interface ITurn
    {
        void TakeAction(int choice);
    }
    interface IHealth
    {
        void Health();
    }
    public class Attack : IHealth, ITurn
    {
        public void TakeAction(int choice)
        {
            Console.WriteLine("test");
        }
        public void Health()
        {
        Console.WriteLine("test");
        }
    }
    class Enemy : Fighter
    {
        public Enemy(string n) : base(n)
            {
                Name = n;
            }
    }
    class Player : Fighter
    {
        public Player(string n) : base(n)
        {
            Name = n;
        }
    }
    class Program
    {
        public void Rules()
        {
            Console.WriteLine("The Rules:");
            Console.WriteLine();
            Console.WriteLine("This is you against the enemy. First one to run out of health will be declared dead and the other player will be declared the winner." +
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
            int userInput = 0;
                
            Console.WriteLine("WELCOME TO THE COMBAT ARENA!!");
            Console.WriteLine();
            Console.WriteLine("Please enter your name: ");
            Fighter p1 = new Fighter(Console.ReadLine());
            Fighter p2 = new Fighter("Enemy");
            Attack ap1 = new Attack();
            Attack ap2 = new Attack();
            p1.PrintWelcome();
            Program instructions = new Program();
            instructions.Rules();
            


            do          
            {
                Console.WriteLine();
                Console.WriteLine("**********************************************");
                Console.WriteLine("Round: " + roundCounter);
                Console.WriteLine("**********************************************");
                Console.WriteLine();
                Console.WriteLine(p1.Name + ": " + " health units.");
                Console.WriteLine(p2.Name + ": " + " health units.");
                Console.WriteLine();
                Console.WriteLine(p1.Name + " , what would you like to do");
                Console.WriteLine("1 - Attack?");
                Console.WriteLine("2 - Heal by drinking a potion?");
                userInput = Convert.ToInt32(Console.ReadLine());
                ap1.TakeAction(userInput);
                ap2.TakeAction(1);
                ap1.Health();
                ap2.Health();
                roundCounter++;
            }while (true);
        }
    }
}
 