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
        Console.WriteLine($"You recorded progress for '{_title}' {_amountCompleted}/{_targetAmount} times and earned {_points} points!");
        if (_amountCompleted == _targetAmount)
        {
            Console.WriteLine($"✅ You finished this goal and earned a {_bonus} point bonus!");
        }
    }
}