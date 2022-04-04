/*
Program - week10Assignment
Programer - Toby Cantello
Date Created - 4/1/2022
Last Date Updated - 4/4/2022
*/

using System;

namespace week10Assignment
{

    // Main player class
    class Fighter
    {
        public static Random random = new Random();

        string name;

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
    // Take Action and Healing Random number generator section
    interface IPlayerTurn
    {
        int TakeAction();
    }
    interface IEnemyTurn
    {
        int ETakeAction();
    }
    interface IHealth
    {
        int Health();
    }
    public class Attack : IHealth, IPlayerTurn, IEnemyTurn
    {
        public int TakeAction()
        {
            int playerDamageGiven = Fighter.random.Next(0, 5);
            Console.WriteLine("You gave the enemy " + playerDamageGiven + " points of damage.");
            return playerDamageGiven;
        }
        public int ETakeAction()
        {
            int enemyDamageGiven = Fighter.random.Next(0, 5);
            Console.WriteLine("The enemy gave you " + enemyDamageGiven + " points of damage.");
            return enemyDamageGiven;
        }
        public int Health()
        {
            int playerHealth = Fighter.random.Next(5, 20);
            Console.WriteLine("You healed " + playerHealth + " points of damage.");
            return playerHealth;
        }
    }
    // Names of the players
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
        // Game Rules
        public static void Rules()
        {
            Console.WriteLine("The Rules:");
            Console.WriteLine();
            Console.WriteLine("This is you against the enemy. Each round will consist of the Player either attacking or healing and the enemy attacking. First one to run " +
                "out of health will be declared dead and the other player will be declared the winner. Both players will start out with 20 units of health. You as the " +
                "player will have 3 chances to replish your health with the use of potions. The use of a potion will result in the loss of an attack. The potion will " +
                "restore anywhere from 5 to 20 units of health each time it is used. However the use of a potion will not result in your health going above 20 units. An " +
                "attack will result in anywhere from 0 to 5 units of damage. The enemy will always attack.");
            Console.WriteLine();
            Console.WriteLine();
        }
        // Main Program Below
        static void Main(string[] args)
        { 
            int userInput;
            int playAgain;
                
            Console.WriteLine("WELCOME TO THE COMBAT ARENA!!");
            Console.WriteLine();
            Console.WriteLine("Please enter your name: ");
            Fighter p1 = new Fighter(Console.ReadLine());
            Fighter p2 = new Fighter("Enemy");
            Attack ap1 = new Attack();
            Attack ap2 = new Attack();
            p1.PrintWelcome();
            Rules();
            do
            {
                int roundCounter = 1;
                int playerCurrentHealth = 20;
                int enemyCurrentHealth = 20;
                int playerPotion = 3;
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("Round: " + roundCounter);
                    Console.WriteLine("**********************************************");
                    Console.WriteLine();
                    Console.WriteLine(p1.Name + ": " + playerCurrentHealth + " health units.");
                    Console.WriteLine(p2.Name + ": " + enemyCurrentHealth + " health units.");
                    Console.WriteLine();
                    Console.WriteLine(p1.Name + " , what would you like to do");
                    Console.WriteLine("1 - Attack?");
                    if (playerPotion > 0)
                    {
                        Console.WriteLine("2 - Heal by drinking a potion?  You have " + playerPotion + " potions left");
                    }
                    else
                    {
                        Console.WriteLine("You have no potions left and can only attack.");
                    }
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput == 1)
                    {
                        playerCurrentHealth -= ap2.ETakeAction();
                        enemyCurrentHealth -= ap1.TakeAction();
                    }
                    else if (userInput == 2)
                    {
                        if ((playerCurrentHealth + ap1.Health() - ap2.ETakeAction() >= 20))
                        {
                            playerCurrentHealth = 20;
                            playerPotion--;
                        }
                        else
                        {
                            playerCurrentHealth += ap1.Health() - ap2.ETakeAction();
                            playerPotion--;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You did not enter 1 or 2");
                    }
                    roundCounter++;
                } while (playerCurrentHealth > 0 && enemyCurrentHealth > 0);

                if (playerCurrentHealth <= 0 && enemyCurrentHealth > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("RIP " + p1.Name + " your dead! Better Luck next time");
                }
                else if (enemyCurrentHealth <= 0 && playerCurrentHealth > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Congrats " + p1.Name + " your the winner! You defeated your enemy in " + (roundCounter - 1) + " rounds.");
                }
                else
                {
                    Console.WriteLine("DRAW!!! " + p1.Name + " you and the enemy are both died!");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Would like to play again?");
                Console.WriteLine();
                Console.WriteLine("Press 1 to play the game again.");
                Console.WriteLine("Press any other key to quit playing.");
                playAgain = Convert.ToInt32(Console.ReadLine());
            } while (playAgain == 1);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Thanks for Playing! See you again soon!");
        }
    }
}