﻿// See https://aka.ms/new-console-template for more information
using System;

namespace NumberGuesser
{
class Program
{
        // entry-point method
    static void Main(string[] args) {
            // setting variables
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Ian McNichols";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{appName}: Version {appVersion} by {appAuthor}.");
            Console.ResetColor();

            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();

            Console.WriteLine($"Hello {userName}. Let's play a game.");

            int correctNumber = 5;

            Console.WriteLine("Guess a number from 1 to 10");
            int guessNumber = Int32.Parse(Console.ReadLine());

            while (guessNumber != correctNumber)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect guess. Try again! ");
                Console.ResetColor();
                guessNumber = Int32.Parse(Console.ReadLine());

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct! You won.");
    }
}

}