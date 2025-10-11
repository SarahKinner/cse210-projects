using System;
using System.Threading;

public class ReflectionActivity : Activity
{
    private string[] _prompts = {
        "Think of a time when you helped someone in need.",
        "Recall a time when you overcame a difficult challenge.",
        "Remember a moment when you felt deep peace."
    };

    public ReflectionActivity()
        : base("Reflection", "This activity helps you reflect on moments of strength and gratitude.")
}