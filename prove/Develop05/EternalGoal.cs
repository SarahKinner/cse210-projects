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
}