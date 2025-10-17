using System;

public abstract class Goal
{
    private string _title;
    private string _description;
    private int _points;

    protected Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }

    public string Title => _title;
    public string Description => _description;
    public int Points => _points;

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();
    public abstract string Display();
}
