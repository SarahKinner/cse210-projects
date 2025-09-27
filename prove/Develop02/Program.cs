using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    // Displays the entries into a neat little format
    public void Display()
    {
        Console.WriteLine($"{_date} - Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }

    // Converts entries made into one line of code for saving
    public string GetEntryAsFileLine()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    // Loads an entry from a file line
    public static Entry LoadFromFileLine(string line)
    {
        string[] parts = line.Split('|');
        return new Entry
        {
            _date = parts[0],
            _prompt = parts[1],
            _response = parts[2]
        };
    }
}

class Journal
{
    // List to store all the journal entries
    public List<Entry> _entries = new List<Entry>();

    // Adds an entry to the journal
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Displays all the entries in the journal
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Save the journal to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetEntryAsFileLine()); // fixed typo "GerEntryAsFileLine"
            }
        }
    }

    // Load the journal from a file
    public void LoadFromFile(string filename)
    {
        _entries.Clear(); // removes the old entries
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Entry entry = Entry.LoadFromFileLine(line);
            _entries.Add(entry);
        }
    }
}

class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();   // fixed typo: Jornal → Journal
        PromptGenerator generator = new PromptGenerator(); // fixed "Prompt Generator"

        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine(); // fixed Readline → ReadLine
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number from 1 - 5.\n");
                continue;
            }

            if (choice == 1)
            {
                string prompt = generator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("Your response: ");
                string response = Console.ReadLine();

                Entry entry = new Entry
                {
                    _date = DateTime.Now.ToShortDateString(),
                    _prompt = prompt,
                    _response = response
                };

                journal.AddEntry(entry); // fixed ":" → ";"
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
                Console.WriteLine("Journal saved.\n"); // fixed missing semicolon
            }
            else if (choice == 4)
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded.\n");
            }
            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Please choose a valid option (1–5).\n");
            }
        }
    }
}
