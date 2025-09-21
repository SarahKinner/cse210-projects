using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine("Please enter a valid integer.");
                continue;
            }

            if (value == 0) // sentinel stops input; do not add 0 to the list
                break;

            numbers.Add(value);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        // Compute sum, average, and max manually
        int sum = 0;
        int max = numbers[0];
        foreach (int n in numbers)
        {
            sum += n;
            if (n > max) max = n;
        }

        double average = (double)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}
