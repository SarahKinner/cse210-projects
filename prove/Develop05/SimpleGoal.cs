using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string title, string description, int points)
        : base(title, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Congratulations! You earned {_points} points!");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }
}