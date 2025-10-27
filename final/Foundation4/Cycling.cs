using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(string fate, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }
}