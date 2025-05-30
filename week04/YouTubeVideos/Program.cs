// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create Video 1
        Video video1 = new Video("How to Cook Perfect Pasta", "ChefMaster2023", 480);
        video1.AddComment(new Comment("FoodLover88", "Great recipe! I tried this and it turned out amazing."));
        video1.AddComment(new Comment("PastaFan", "Finally, someone who explains the salt ratio correctly!"));
        video1.AddComment(new Comment("HomeCook", "This changed my pasta game forever. Thank you!"));
        video1.AddComment(new Comment("ItalianNonna", "My grandmother would approve of this technique."));

        // Create Video 2
        Video video2 = new Video("10 Minute Morning Workout", "FitnessGuru", 600);
        video2.AddComment(new Comment("HealthyLife", "Perfect for busy mornings. Already seeing results!"));
        video2.AddComment(new Comment("MorningPerson", "Love how energized I feel after this routine."));
        video2.AddComment(new Comment("BusyMom", "Finally a workout that fits my schedule. Thank you!"));

        // Create Video 3
        Video video3 = new Video("JavaScript Basics Explained", "CodeAcademy", 1245);
        video3.AddComment(new Comment("NewCoder", "This is the clearest explanation I've found so far."));
        video3.AddComment(new Comment("StudentDev", "The examples really helped me understand the concepts."));
        video3.AddComment(new Comment("WebDeveloper", "Great refresher! Shared this with my team."));
        video3.AddComment(new Comment("TechEnthusiast", "Wish I had this video when I was starting out."));

        // Create Video 4
        Video video4 = new Video("DIY Home Organization Hacks", "OrganizeWithMe", 720);
        video4.AddComment(new Comment("CleanFreak", "These tips are life-changing! My closet has never looked better."));
        video4.AddComment(new Comment("HomeOwner", "The drawer divider hack is genius!"));
        video4.AddComment(new Comment("MinimalistLife", "Simple solutions that actually work. Love it!"));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Display information for each video
        Console.WriteLine("=== YouTube Video Collection ===\n");
        
        foreach (Video video in videos)
        {
            // Display video information
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            
            // Display all comments for this video
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }
            
            Console.WriteLine(); // Add blank line between videos
        }
    }
}