using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    // Base Activity class containing shared attributes and behaviors
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void DisplayStartingMessage()
        {
            Console.WriteLine($"Welcome to the {_name}.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("How long, in seconds, would you like for your session? ");
            _duration = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
            Console.WriteLine();
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!!");
            ShowSpinner(3);
            Console.WriteLine();
            Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
            ShowSpinner(3);
        }

        public void ShowSpinner(int seconds)
        {
            List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);

            int i = 0;
            while (DateTime.Now < endTime)
            {
                string s = animationStrings[i];
                Console.Write(s);
                Thread.Sleep(100);
                Console.Write("\b \b");
                i++;

                if (i >= animationStrings.Count)
                {
                    i = 0;
                }
            }
        }

        public void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        public abstract void Run();
    }
}