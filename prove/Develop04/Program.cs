using System;
using System.Collections.Generic;
// For the creativity part of the project added a way so it'll store how many times each activity was picked and done

class Program
{
    private static Dictionary<string, int> _activityLog = new()
    {
        { "Breathing", 0 },
        { "Reflection", 0 },
        { "Listing", 0 }
    };

    public static void IncrementActivityLog(string activityName)
    {
        if (_activityLog.ContainsKey(activityName))
        {
            _activityLog[activityName]++;
        }
    }

    public static void ShowActivityLog()
    {
        Console.WriteLine("\nActivity Log:");
        foreach (var kvp in _activityLog)
        {
            Console.WriteLine($"{kvp.Key} Activity: {kvp.Value} time(s)");
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Show Activity Log");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an activity: ");

            string choice = Console.ReadLine();
            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                "5" => null,
                _ => null
            };

            if (activity == null)
            {
                if (choice == "5") break;
                if (choice == "4")
                {
                    ShowActivityLog();
                    Console.WriteLine("\nPress Enter to return to menu.");
                    Console.ReadLine();
                    continue;
                }
                Console.WriteLine("Invalid choice. Press Enter to try again.");
                Console.ReadLine();
                continue;
            }

            activity.Start();
            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadLine();
        }
    }
}