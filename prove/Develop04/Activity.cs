using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);
        Console.Write("\nEnter the duration of the activity in seconds: ");
        _duration = int.Parse(Console.ReadLine() ?? "30");

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        RunActivity();

        End();
    }

    protected abstract void RunActivity();

    protected void End()
    {
        Console.WriteLine($"\nGood job! You completed the {_name} Activity for {_duration} seconds!");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        char[] spinner = { '|', '/', '-', '\\' };

        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i++;
        }
        Console.WriteLine();
    }
}
