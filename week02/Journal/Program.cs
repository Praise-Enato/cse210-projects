using System;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of the main classes
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        // Main program loop
        while (running)
        {
            // Display menu options
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Write a new entry
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    
                    // Get current date as string
                    string date = DateTime.Now.ToShortDateString();
                    
                    // Create a new entry and add it to the journal
                    Entry newEntry = new Entry(date, prompt, response);
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry added successfully!");
                    break;

                case "2":
                    // Display the journal
                    journal.DisplayAll();
                    break;

                case "3":
                    // Save the journal to a file
                    Console.Write("\nEnter a filename to save to: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "4":
                    // Load the journal from a file
                    Console.Write("\nEnter the filename to load from: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "5":
                    // Exit the program
                    running = false;
                    Console.WriteLine("\nThank you for using the Journal Program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
        }
    }
}

