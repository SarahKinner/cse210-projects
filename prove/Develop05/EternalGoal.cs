using System;

public class EternalGoal : Goal
{
    private int _amountCompleted;
    private int _targetAmount;
    private int _bonus;

    public EternalGoal(string title, string description, int points, int targetAmount, int bonus)
        : base(title, description, points)
    {
        _amountCompleted = 0;
        _targetAmount = targetAmount;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        Console.WriteLine($"You completed '{_title}' {_amountCompleted}/{_targetAmount} times and earned {_points} points!");
        if (_amountCompleted == _targetAmount)
        {
            Console.WriteLine($"🎉 Bonus achieved! You earned an extra {_bonus} points!");
        }
    }
}