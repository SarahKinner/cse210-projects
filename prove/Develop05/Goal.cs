using System;

public abstract class GoalManager
{
    protected string _title;
    protected string _description;
    protected int _points;

    public Goal(string title, string _description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();

    public int GetPoints()
    {
        return _points;
    }
}