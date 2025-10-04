using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = new List<Scripture>();

        scriptureLibrary.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
            "In all thy ways acknowledge him, and he shall direct thy paths."
        ));

        scriptureLibrary.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
        ));

        scriptureLibrary.Add(new Scripture(
            new Reference("Mosiah", 2, 17),
            "When ye are in the service of your fellow beings ye are only in the service of your God."
        ));

        scriptureLibrary.Add(new Scripture(
            new Reference("Alma", 37, 6),
            "By small and simple things are great things brought to pass; and small means in many instances doth confound the wise."
        ));

        Random random = new Random();
        int index = random.Next(scriptureLibrary.Count);
        Scripture scripture = scriptureLibrary[index];

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;
            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine("All words are hidden. Program has ended.");
    }
}