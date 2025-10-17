using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private string _filename = "goals.txt";

    public void Start()
    {
        string choice = "";

        while (choice != "7")
        {
            Console.WriteLine();
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Show Score");
            Console.WriteLine(" 7. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine($"Current score: {_score}");
                    break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("Enter the title: ");
        string title = Console.ReadLine();

        Console.Write("Enter the description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for this goal: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(title, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(title, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for completing it? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(title, description, points, target, bonus));
        }

        Console.WriteLine("Goal created successfully!");
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        Console.WriteLine("Your goals:");
        int i = 1;
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{i}. {g.Display()}");
            i++;
        }
    }

    private void RecordEvent()
    {
        ListGoals();

        Console.Write("Which goal did you accomplish? (enter number): ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"You earned {pointsEarned} points! Total score: {_score}");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(_filename))
        {
            writer.WriteLine(_score);
            foreach (Goal g in _goals)
            {
                writer.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved!");
    }

    private void LoadGoals()
    {
        if (!File.Exists(_filename))
        {
            Console.WriteLine("No save file found.");
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(_filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            if (type == "Simple")
            {
                string title = parts[1];
                string desc = parts[2];
                int pts = int.Parse(parts[3]);
                bool done = parts[4] == "1";
                _goals.Add(new SimpleGoal(title, desc, pts, done));
            }
            else if (type == "Eternal")
            {
                string title = parts[1];
                string desc = parts[2];
                int pts = int.Parse(parts[3]);
                _goals.Add(new EternalGoal(title, desc, pts));
            }
            else if (type == "Checklist")
            {
                string title = parts[1];
                string desc = parts[2];
                int pts = int.Parse(parts[3]);
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int current = int.Parse(parts[6]);
                _goals.Add(new ChecklistGoal(title, desc, pts, target, bonus, current));
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}