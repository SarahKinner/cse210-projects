using System;
using System.Collections.Generic;

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