using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _targetAmount;
    private int _bonus;

    public ChecklistGoal(string title, string description, int points, int targetAmount, int bonus)
        : base(title, description, points)
    {
        _amountCompleted = 0;
        _targetAmount = targetAmount;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted >= _targetAmount)
        {
            _isComplete = true;
            Console.WriteLine($"Checklist goal '{_title}' complete! You earned {_points + _bonus} points!");
        }
        else
        {
            Console.WriteLine($"Progress recorded for '{_title}' ({_amountCompleted}/{_targetAmount}). You earned {_points} points.");
        }
    }

    public override int GetPoints()
    {
        if (_isComplete)
            return _points + _bonus;
        return _points * _amountCompleted;
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_title} ({_description}) -- Completed {_amountCompleted}/{_targetAmount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_title}|{_description}|{_points}|{_isComplete}|{_amountCompleted}|{_targetAmount}|{_bonus}";
    }
}