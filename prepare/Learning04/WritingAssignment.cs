using System;

public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method to return writing info
    public string GetWritingInformation()
    {
        // Access base class data using GetStudentName()
        return $"{_title} by {GetStudentName()}";
    }
}
