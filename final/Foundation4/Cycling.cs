using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * GetMinutes()) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed;
    public override double GetCalories() => GetDistance() * 50;

    public override string GetSummary()
    {
        return $"{GetDate()} 🚴‍♀️ Cycling ({GetMinutes()} min) - " +
               $"Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min/mile, " +
               $"Calories: {GetCalories():F0} kcal";
    }
}