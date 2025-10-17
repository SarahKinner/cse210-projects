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

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine($"Checklist goal '{_title}' is already complete.");
            return 0;
        }

        _amountCompleted++;
        int earnedPoints = _points;
        if (_amountCompleted >= _targetAmount)
        {
            _isComplete = true;
            earnedPoints += _bonus;
            Console.WriteLine($"Checklist goal '{_title}' complete! You earned {earnedPoints} points!");
        }
        else
        {
            Console.WriteLine($"Progress recorded for '{_title}' ({_amountCompleted}/{_targetAmount}). You earned {_points} points.");
        }
        return earnedPoints;
    }

    public override int GetPoints()
    {
        if (_isComplete) return _points * _targetAmount + _bonus;
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

    public static ChecklistGoal CreateFromString(string[] parts)
    {
        string title = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isComplete = bool.Parse(parts[4]);
        int amountCompleted = int.Parse(parts[5]);
        int targetAmount = int.Parse(parts[6]);
        int bonus = int.Parse(parts[7]);

        ChecklistGoal goal = new ChecklistGoal(title, description, points, targetAmount, bonus);
        for (int i = 0; i < amountCompleted; i++) goal.RecordEvent();
        return goal;
    }
}