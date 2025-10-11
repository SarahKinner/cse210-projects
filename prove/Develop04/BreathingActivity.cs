using  System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity helps you relax by guiding your breathing.") { }

    protected override void RunActivity()
    {
        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.Write("Breathe in...");
            PauseCountdown(4);
            Console.Write("Breathe out...");
            PauseCountdown(4);
            Console.WriteLine();
        }
    }
}