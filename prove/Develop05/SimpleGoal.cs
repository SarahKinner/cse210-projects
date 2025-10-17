using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string title, string description, int points)
        : base(title, description, points)
    {
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Goal '{_title}' completed! You earned {_points} points!");
            return _points;
        }
        else
        {
            Console.WriteLine($"Goal '{_title}' is already completed.");
            return 0;
        }
    }

    public override int GetPoints()
    {
        return _isComplete ? _points : 0;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_title}|{_description}|{_points}|{_isComplete}";
    }

    public static SimpleGoal CreateFromString(string[] parts)
    {
        string title = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isComplete = bool.Parse(parts[4]);

        SimpleGoal goal = new SimpleGoal(title, description, points);
        if (isComplete) goal.RecordEvent();
        return goal;
    }
}