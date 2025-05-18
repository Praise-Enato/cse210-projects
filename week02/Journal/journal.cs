using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;

    // Constructor
    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Display all entries in the journal
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty. Try adding an entry first!");
            return;
        }

        Console.WriteLine("\n=== Journal Entries ===");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Save all entries to a file
    public void SaveToFile(string file)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.GetAsString());
                }
            }
            Console.WriteLine($"Journal successfully saved to {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }

    // Load entries from a file
    public void LoadFromFile(string file)
    {
        try
        {
            if (!File.Exists(file))
            {
                Console.WriteLine($"File not found: {file}");
                return;
            }

            string[] lines = File.ReadAllLines(file);
            
            // Clear existing entries before loading new ones
            _entries.Clear();
            
            foreach (string line in lines)
            {
                Entry entry = Entry.CreateFromString(line);
                _entries.Add(entry);
            }
            
            Console.WriteLine($"Journal successfully loaded from {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
        }
    }
}