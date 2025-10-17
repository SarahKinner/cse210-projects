using System;

public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string title, string description, int points)
        : base(title, description, points)
    {
        _timesRecorded = 0;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        Console.WriteLine($"You worked on '{_title}'! Earned {_points} points. (Total times: {_timesRecorded})");
        return _points;
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

    public static EternalGoal CreateFromString(string[] parts)
    {
        string title = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        int timesRecorded = int.Parse(parts[4]);

        EternalGoal goal = new EternalGoal(title, description, points);
        for (int i = 0; i < timesRecorded; i++) goal.RecordEvent();
        return goal;
    }
}