using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    public string GetCommenterName() => CommenterName;
    public string GetCommentText() => CommentText;
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds, string category)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Category = category;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Category: {Category}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");

        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
        }

        Console.WriteLine(new string('-', 40));
    }
}

class Program
{
    static void Main()
    {
        Video video1 = new Video("How to Cook Pasta", "Chef Alex", 420, "Cooking");
        Video video2 = new Video("Learn C# in 10 Minutes", "CodeWithMe", 600, "Education");
        Video video3 = new Video("Funny Cat Compilation", "KittenWorld", 300, "Comedy");

        video1.AddComment(new Comment("Sarah", "This helped me so much, thanks!"));
        video1.AddComment(new Comment("Mike", "Now I’m hungry again 😋"));
        video1.AddComment(new Comment("Lena", "Perfect tutorial!"));

        video2.AddComment(new Comment("Tom", "Super easy to follow!"));
        video2.AddComment(new Comment("Emma", "Please make an advanced version!"));
        video2.AddComment(new Comment("Jake", "I finally understand loops now."));

        video3.AddComment(new Comment("Olivia", "The black cat made me laugh!"));
        video3.AddComment(new Comment("Noah", "So adorable 🐱"));
        video3.AddComment(new Comment("Sophia", "I love this channel!"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}