using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string _description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine() ?? "30");

        Console.Clear();
        Console.WriteLine("Get ready...");
        PauseCountDown(3);

        RunActivity();
        End();
    }

    protected void End()
    {
        Console.WriteLine($"\nGood job! You completed the {_name} Activity for {_duration} seconds!");
        PauseCountDown(3);
    }

    protected void PauseCountDown(int seconds)
    {
        for (int i = seconds)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}