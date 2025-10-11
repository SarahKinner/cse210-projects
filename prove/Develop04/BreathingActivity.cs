using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", 
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    protected override void RunActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in...");
            PauseCountdown(3);

            Console.Write("Now breathe out...");
            PauseCountdown(3);
        }
    }
}