using System;

class Program
{
    static void Main()
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // 1..100 inclusive

        Console.WriteLine("I have picked a number between 1 and 100. Try to guess it!");

        int guess;
        Console.Write("What is your guess? ");
        while (!int.TryParse(Console.ReadLine(), out guess))
        {
            Console.WriteLine("Please enter a valid integer.");
            Console.Write("What is your guess? ");
        }

        while (guess != magicNumber)
        {
            if (guess < magicNumber)
                Console.WriteLine("Higher");
            else
                Console.WriteLine("Lower");

            Console.Write("What is your guess? ");
            while (!int.TryParse(Console.ReadLine(), out guess))
            {
                Console.WriteLine("Please enter a valid integer.");
                Console.Write("What is your guess? ");
            }
        }

        Console.WriteLine("You guessed it!");
    }
}
