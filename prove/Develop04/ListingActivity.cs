using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private string[] _prompts = {
        "List people who make you feel happy.",
        "List things you’re grateful for today.",
        "List moments that made you smile recently."
    };

    public ListingActivity()
        : base("Listing", "This activity helps you list positive things to lift your mood.") { }

    protected override void RunActivity()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Length)];
        Console.WriteLine($"\n{prompt}");
        Console.WriteLine("Start listing items. You have a few seconds!");
        PauseCountdown(3);

        DateTime end = DateTime.Now.AddSeconds(_duration);
        List<string> responses = new();
        while (DateTime.Now < end)
        {
            Console.Write("> ");
            responses.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {responses.Count} items!");
    }
}