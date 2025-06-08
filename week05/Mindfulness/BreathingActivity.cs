using System;

namespace MindfulnessProgram
{
    // Breathing Activity class
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", 
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public override void Run()
        {
            DisplayStartingMessage();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("Breathe in...");
                ShowCountdown(4);
                Console.WriteLine();

                if (DateTime.Now >= endTime) break;

                Console.Write("Now breathe out...");
                ShowCountdown(6);
                Console.WriteLine();
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }
    }
}