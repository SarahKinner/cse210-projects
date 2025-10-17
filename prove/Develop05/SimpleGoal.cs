using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string title, string description, int points)
        : base(title, description, points)
    {
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Goal '{_title}' completed! You earned {_points} points!");
    }

    public override int GetPoints()
    {
        return _isComplete ? _points : 0;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_title}|{_description}|{_points}|{_isComplete}";
    }
}