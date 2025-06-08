using System;
using System.Threading;

namespace MindfulnessProgram
{
    // Main Program class
    class Program
    {
        /*
         * CREATIVITY AND EXCEEDING REQUIREMENTS:
         * 1. Enhanced animations with more fluid spinner characters
         * 2. Better user experience with clear screen functionality
         * 3. Improved time management to ensure activities run for exact duration
         * 4. More robust input handling
         * 5. Enhanced countdown display for breathing activity
         * 6. Better formatting and user feedback throughout
         * 7. Organized code into separate files for better maintainability
         * 8. Proper encapsulation and abstraction following OOP principles
         */

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                }
                catch (IOException)
                {
                    // Ignore if console cannot be cleared
                }
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflecting activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BreathingActivity breathingActivity = new BreathingActivity();
                        breathingActivity.Run();
                        break;
                    case "2":
                        ReflectingActivity reflectingActivity = new ReflectingActivity();
                        reflectingActivity.Run();
                        break;
                    case "3":
                        ListingActivity listingActivity = new ListingActivity();
                        listingActivity.Run();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using the Mindfulness Program!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(2000);
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}