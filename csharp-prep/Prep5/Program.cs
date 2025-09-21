using System;

class Program
{
    // 1. DisplayWelcome - no parameters, no return
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // 2. PromptUserName - return string
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // 3. PromptUserNumber - return int
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        return int.Parse(input);
    }

    // 4. PromptUserBirthYear - uses an out parameter
    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        string input = Console.ReadLine();
        birthYear = int.Parse(input);
    }

    // 5. SquareNumber - takes int, returns int
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // 6. DisplayResult - takes name, squared number, birth year
    static void DisplayResult(string userName, int squaredNumber, int birthYear)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");

        int currentYear = DateTime.Now.Year;
        int age = currentYear - birthYear;

        Console.WriteLine($"{userName}, you will turn {age} this year.");
    }

    // Main ties everything together
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        PromptUserBirthYear(out int birthYear);

        int squared = SquareNumber(favoriteNumber);

        DisplayResult(name, squared, birthYear);
    }
}
