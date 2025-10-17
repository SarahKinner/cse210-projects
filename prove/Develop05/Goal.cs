using System;

public abstract class Goal
{
    protected string _title;
    protected string _description;
    protected int _points;
    protected bool _isComplete;
    protected DateTime? _dueDate;

    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
        _isComplete = false;
        _dueDate = null;
    }

    public void SetDueDate(DateTime dueDate)
    {
        _dueDate = dueDate;
    }

    public bool HasDueDate()
    {
        return _dueDate.HasValue;
    }

    public string GetDueDateDisplay()
    {
        if (!_dueDate.HasValue)
            return "";
        int daysRemaining = (int)(_dueDate.Value - DateTime.Now).TotalDays;
        string status = daysRemaining >= 0 ? $"{daysRemaining} days remaining" : "⚠️ Past due!";
        return $"Due: {_dueDate.Value.ToShortDateString()} ({status})";
    }

    public int? GetDaysUntilDue()
    {
        if (!_dueDate.HasValue) return null;
        return (int)(_dueDate.Value - DateTime.Now).TotalDays;
    }

    public abstract int RecordEvent();
    public abstract int GetPoints();
    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_title} ({_description})";
    }

    public bool IsComplete()
    {
        return _isComplete;
    }
}