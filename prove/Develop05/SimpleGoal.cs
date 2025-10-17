using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string title, string description, int points)
        : base(title, description, points)
    {
        _isComplete = false;
    }
}