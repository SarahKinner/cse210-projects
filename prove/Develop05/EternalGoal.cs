using System;

public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string title, string description, int points)
        : base(title, description, points)
    {
        _timesRecorded = 0;
    }

    public override void RecordEvent()
    {
        _timesRecorded++;
        Console.WriteLine($"You worked on '{_title}'! Earned {_points} points. (Total times: {_timesRecorded})");
    }

    public override int GetPoints()
    {
        return _timesRecorded * _points;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_title}|{_description}|{_points}|{_timesRecorded}";
    }

    public override string GetDetailsString()
    {
        return $"[∞] {_title} ({_description}) -- Progress recorded {_timesRecorded} times";
    }
}