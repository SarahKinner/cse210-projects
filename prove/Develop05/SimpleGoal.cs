using System;

public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string title, string description, int points, bool completed = false)
        : base(title, description, points)
    {
        _completed = completed;
    }

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return Points;
        }
        else
        {
            Console.WriteLine("This goal has already been completed.");
            return 0;
        }
    }

    public override bool IsComplete() => _completed;

    public override string GetStringRepresentation()
    {
        return $"Simple|{Title}|{Description}|{Points}|{(_completed ? 1 : 0)}";
    }

    public override string Display()
    {
        string status = _completed ? "[X]" : "[ ]";
        return $"{status} {Title} ({Description})";
    }
}