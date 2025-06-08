using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    // Listing Activity class
    public class ListingActivity : Activity
    {
        private int _count;
        private List<string> _prompts;

        public ListingActivity() : base("Listing Activity", 
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
        }

        public override void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine("List as many responses you can to the following prompt:");
            GetRandomPrompt();
            Console.Write("You may begin in: ");
            ShowCountdown(5);
            Console.WriteLine();

            GetListFromUser();

            Console.WriteLine($"You listed {_count} items!");

            DisplayEndingMessage();
        }

        public void GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            Console.WriteLine($"--- {_prompts[index]} ---");
        }

        public List<string> GetListFromUser()
        {
            List<string> items = new List<string>();
            _count = 0;
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    items.Add(input);
                    _count++;
                }
            }

            return items;
        }
    }
}