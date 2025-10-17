using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine($"\nYour current score: {_score}");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Check Due Date Reminders");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    CheckReminders();
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }
    
    public void CreateGoal()
    {
        Console.WriteLine("\nWhat type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter the goal title: ");
        string title = Console.ReadLine();

        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the point value: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        if (choice == 1)
        {
            newGoal = new SimpleGoal(title, description, points);
        }
        else if (choice == 2)
        {
            newGoal = new EternalGoal(title, description, points);
        }
        else if (choice == 3)
        {
            Console.Write("How many times must this goal be completed? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter the bonus for completing all: ");
            int bonus = int.Parse(Console.ReadLine());
            newGoal = new ChecklistGoal(title, description, points, target, bonus);
        }

        Console.Write("Would you like to set a due date? (y/n): ");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y")
        {
            Console.Write("Enter the due date (MM/DD/YYYY): ");
            DateTime dueDate;
            while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                Console.Write("Invalid date. Please enter again (MM/DD/YYYY): ");
            }
            newGoal.SetDueDate(dueDate);
        }

        _goals.Add(newGoal);
        Console.WriteLine("✅ Goal created successfully!");
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals created yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetDetailsString()}");

            if (goal.HasDueDate())
                Console.WriteLine($"   {goal.GetDueDateDisplay()}");

            index++;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals to record progress on.");
            return;
        }

        Console.WriteLine("\nWhich goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Enter the number of the goal: ");
        int choice = int.Parse(Console.ReadLine());
        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Goal selectedGoal = _goals[choice - 1];
        int pointsEarned = selectedGoal.RecordEvent();
        _score += pointsEarned;

        Console.WriteLine($"🎉 You earned {pointsEarned} points!");
        Console.WriteLine($"Your new total score is: {_score}");
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save goals (e.g., goals.txt): ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("💾 Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load goals from: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];
            Goal goal = null;

            if (type == "SimpleGoal")
                goal = SimpleGoal.CreateFromString(parts);
            else if (type == "EternalGoal")
                goal = EternalGoal.CreateFromString(parts);
            else if (type == "ChecklistGoal")
                goal = ChecklistGoal.CreateFromString(parts);

            _goals.Add(goal);
        }

        Console.WriteLine("📂 Goals loaded successfully!");
    }

    public void CheckReminders()
    {
        Console.WriteLine("\n🔔 Upcoming Due Dates:");
        bool found = false;

        foreach (Goal goal in _goals)
        {
            if (goal.HasDueDate())
            {
                TimeSpan remaining = goal.GetDueDate() - DateTime.Now;
                if (remaining.TotalDays <= 3)
                {
                    Console.WriteLine($"⚠️  {goal.GetDetailsString()} — {goal.GetDueDateDisplay()}");
                    found = true;
                }
            }
        }

        if (!found)
            Console.WriteLine("No upcoming due dates!");
    }
}