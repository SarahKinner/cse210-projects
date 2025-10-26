using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Prvo", "UT", "USA");
        Address address2 = new Address("45 Ocean Blvd", "Miami", "FL", "USA");
        Address address3 = new Address("99 Pine Way", "Seattle", "WA", "USA");

        Lecture lecture = new Lecture(
            "Tech Innovations 2025",
            "A lecture on new technology trends",
            "March 15, 2025",
            "10:00 AM",
            address1,
            "Dr. Jane Smith",
            150
        );

        Reception reception = new Reception(
            "Networking Gala",
            "An evening to connect with professionals",
            "April 10, 2025",
            "6:30 PM",
            address2,
            "rsvp@galaevents.com"
        );

        OutdoorGathering outdoor = new OutdoorGathering(
            "Community Picnic",
            "Family-friendly outdoor picnic event",
            "May 5, 2025",
            "12:00 PM",
            address3,
            "Sunny with a light breeze"
        );

        Event[] events = { lecture, reception, outdoor };

        foreach (Event e in events)
        {
            Console.WriteLine("=== Standard Details ===");
            Console.WriteLine(e.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("=== Full Details ===");
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("=== Short Description ===");
            Console.WriteLine(e.GetShortDescription());
            Console.WriteLine("\n--------------------------\n");
        }
    }
}