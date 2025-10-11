using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private string[] _prompts = {
        "List people who make you feel happy.",
        "List things you're grateful for today.",
        "List moments that made you smile recently."
    };

    public ListingActivity()
        : base("Listing", "This activity helps you list positive things to lift your mood") { }
}