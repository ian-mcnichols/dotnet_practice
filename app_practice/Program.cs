// See https://aka.ms/new-console-template for more information
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

            Random rnd = new Random();
            int correctNumber = rnd.Next(1, 10);

            Console.WriteLine("Guess a number from 1 to 10");
            int guessNumber = GetUserGuess();

            while (guessNumber != correctNumber)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect guess. Try again! ");
                Console.ResetColor();
                guessNumber = GetUserGuess();

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct! You won.");
    }
    static bool CheckInt(string input)
    {
        int guess;
        if (int.TryParse(input, out guess) == true)
        {
            return true;
        }
        return false;         
    }
    static int GetUserGuess()
        {
            string userInput = Console.ReadLine();
            bool isInt = CheckInt(userInput);
            while (!isInt)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Must be integer guess.");
                Console.ResetColor();
                userInput = Console.ReadLine();
                isInt = CheckInt(userInput);
            }
            int userGuess = Int32.Parse(userInput);
            return userGuess;
        }
}

}