using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _targetAmount;
    private int _bonus;

    public ChecklistGoal(string title, string description, int points, int targetAmount, int bonus, int amountCompleted = 0)
        : base(title, description, points)
    {
        _targetAmount = targetAmount;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _targetAmount)
        {
            _amountCompleted++;
            int total = Points;

            if (_amountCompleted == _targetAmount)
            {
                total += _bonus;
                Console.WriteLine($"Congratulations! You completed the checklist goal and earned a bonus of {_bonus} points!");
            }

            return total;
        }
        else
        {
            Console.WriteLine("This checklist goal is already complete!");
            return 0;
        }
    }

    public override bool IsComplete() => _amountCompleted >= _targetAmount;

    public override string GetStringRepresentation()
    {
        return $"Checklist|{Title}|{Description}|{Points}|{_targetAmount}|{_bonus}|{_amountCompleted}";
    }

    public override string Display()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {Title} ({Description}) -- Completed {_amountCompleted}/{_targetAmount}";
    }
}