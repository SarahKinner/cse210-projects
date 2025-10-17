using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _totalPoints = 0;

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\n--- Goal Tracker ---");
            Console.WriteLine($"Total Points: {_totalPoints}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Set Due Date");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Check Due Date Reminders");
            Console.WriteLine("8. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SetDueDate(); break;
                case "5": SaveGoals(); break;
                case "6": LoadGoals(); break;
                case "7": CheckReminders(); break;
                case "8": return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nGoal Types:\n1. Simple\n2. Eternal\n3. Checklist");
        Console.Write("Choose type: ");
        string type = Console.ReadLine();

        Console.Write("Enter title: ");
        string title = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        switch (type)
        {
            case "1": goal = new SimpleGoal(title, description, points); break;
            case "2": goal = new EternalGoal(title, description, points); break;
            case "3":
                Console.Write("Enter target amount: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(title, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid type."); return;
        }

        Console.Write("Would you like to set a due date? (y/n): ");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y")
        {
            Console.Write("Enter due date (YYYY-MM-DD): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            goal.SetDueDate(dueDate);
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created!");
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
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

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        ListGoals();
        Console.Write("Select goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        int earned = _goals[index].RecordEvent();
        _totalPoints += earned;
    }

    private void SetDueDate()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        ListGoals();
        Console.Write("Select goal number to set due date: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Console.Write("Enter due date (YYYY-MM-DD): ");
        DateTime dueDate = DateTime.Parse(Console.ReadLine());
        _goals[index].SetDueDate(dueDate);
        Console.WriteLine("Due date set successfully!");
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_totalPoints);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _totalPoints = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            Goal goal = null;
            if (parts[0] == "SimpleGoal") goal = SimpleGoal.CreateFromString(parts);
            else if (parts[0] == "EternalGoal") goal = EternalGoal.CreateFromString(parts);
            else if (parts[0] == "ChecklistGoal") goal = ChecklistGoal.CreateFromString(parts);

            if (goal != null) _goals.Add(goal);
        }

        Console.WriteLine("Goals loaded successfully!");
    }

    public void CheckReminders()
    {
        Console.WriteLine("\n🔔 Upcoming Due Dates (within 3 days):");
        bool found = false;

        foreach (Goal goal in _goals)
        {
            if (goal.HasDueDate())
            {
                TimeSpan remaining = goal._dueDate.Value - DateTime.Now;
                if (remaining.TotalDays <= 3)
                {
                    Console.WriteLine($"{goal.GetDetailsString()} - {goal.GetDueDateDisplay()}");
                    found = true;
                }
            }
        }

        if (!found) Console.WriteLine("No upcoming due dates.");
    }
}