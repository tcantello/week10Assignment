/*
Program - week10Assignment
Programer - Toby Cantello
Date Created - 4/1/2022
Last Date Updated - 4/1/2022
*/

using System;
using System.Text.RegularExpressions;
using System.IO;

namespace week10Assignment
{
    class Fighter
    {
        public static Random random;

        string name;
        int maxHealth = 20;
        int currentHealth;
        bool dead = true;

        public Fighter(string n)
        {
            name = n;
        }
        public void PrintWelcome()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**********************************************");
            Console.WriteLine();
            Console.WriteLine("Welcome to the arena " + name + "!" + "   GOOD LUCK!!!!!");
            Console.WriteLine();
            Console.WriteLine("**********************************************");
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    class Enemy
    {

    }

    class Player
    {

    }

    class Program
    {
        public void Rules()
        {
            Console.WriteLine("The Rules:");
            Console.WriteLine("These are the rules");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO THE COMBAT ARENA!!");
            Console.WriteLine();
            Console.WriteLine("Please enter your name: ");
            Fighter p1 = new Fighter(Console.ReadLine());
            p1.PrintWelcome();
            Program instructions = new Program();
            instructions.Rules();

        }
    }
}
