using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    // Constructor
    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    // Display the entry in a formatted way
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine(); // Add blank line for better readability
    }

    // Convert entry to a string format suitable for saving to a file
    // Using a separator that's unlikely to appear in the text
    public string GetAsString()
    {
        return $"{_date}~|~{_promptText}~|~{_entryText}";
    }

    // Create an Entry object from a string that was saved in a file
    public static Entry CreateFromString(string line)
    {
        string[] parts = line.Split("~|~");
        
        if (parts.Length == 3)
        {
            return new Entry(parts[0], parts[1], parts[2]);
        }
        else
        {
            // In case the file format is invalid, return a placeholder entry
            return new Entry("Error loading entry", "File format error", "Unable to load this entry correctly");
        }
    }
}