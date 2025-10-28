using System;

public class Running : Activity
{
    private double _distance;

    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / GetMinutes()) * 60;
    public override double GetPace() => GetMinutes() / _distance;

    public override double GetCalories() => _distance * 100;

    public override string GetSummary()
    {
        return $"{GetDate()} Running ({GetMinutes()} min) - " +
               $"Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min/mile, " +
               $"Calories: {GetCalories():F0} kcal";
    }
}