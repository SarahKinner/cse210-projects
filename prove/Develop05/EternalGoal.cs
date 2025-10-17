using System;

public class EternalGoal : Goal
{
    public EternalGoal(string title, string description, int points)
        : base(title, description, points)
    {
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override bool IsComplete() => false;

    public override string GetStringRepresentation()
    {
        return $"Eternal|{Title}|{Description}|{Points}";
    }

    public override string Display()
    {
        return $"[∞] {Title} ({Description}) - {Points} pts each time";
    }
}