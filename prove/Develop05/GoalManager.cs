using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine($"\nYou have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice: ");
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
            }
        }
    }
    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal title: ");
        string title = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(title, description, points));
        }
        else if (choice == "2")
        {
            Console.Write("Enter target amount: ");
            int targetAmount = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new EternalGoal(title, description, points, targetAmount, bonus));
        }
        else if (choice == "3")
        {
            Console.Write("Enter target amount: ");
            int targetAmount = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(title, description, points, targetAmount, bonus));
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("\nWhich goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
            _score += _goals[index].GetPoints();
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }
}