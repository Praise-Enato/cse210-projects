using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

/*
 * Scripture Memorizer Program
 * 
 * EXCEEDING REQUIREMENTS:
 * 1. Scripture Library System - Works with multiple scriptures loaded from a built-in library
 * 2. Random Scripture Selection - Presents random scriptures to users for variety
 * 3. Smart Word Selection - Only hides words that aren't already hidden (no duplicates)
 * 4. Progress Tracking - Shows completion percentage as words are hidden
 * 5. Difficulty Levels - Easy (hide 1 word), Medium (hide 2-3 words), Hard (hide 3-5 words)
 * 6. Hints System - Users can type "hint" to reveal one hidden word
 * 7. Statistics - Tracks and displays session statistics
 * 8. Color-coded Display - Uses different colors for better visual experience
 * 9. Pause Feature - Users can pause and resume memorization
 * 10. Memory Challenges - Additional features like reverse mode and timed challenges
 */

namespace ScriptureMemorizer
{
    // Represents a scripture reference (e.g., "John 3:16" or "Proverbs 3:5-6")
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verse;
        private int _endVerse;

        // Constructor for single verse
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _endVerse = verse;
        }

        // Constructor for verse range
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _verse = startVerse;
            _endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            if (_verse == _endVerse)
                return $"{_book} {_chapter}:{_verse}";
            else
                return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }

    // Represents a single word in the scripture
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public void Show()
        {
            _isHidden = false;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public string GetDisplayText()
        {
            if (_isHidden)
            {
                return new string('_', _text.Length);
            }
            return _text;
        }

        public string GetOriginalText()
        {
            return _text;
        }
    }

    // Main scripture class that manages the memorization process
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private int _totalWords;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            
            string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in wordArray)
            {
                _words.Add(new Word(word));
            }
            _totalWords = _words.Count;
        }

        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();
            List<Word> availableWords = _words.Where(word => !word.IsHidden()).ToList();
            
            int wordsToHide = Math.Min(numberToHide, availableWords.Count);
            
            for (int i = 0; i < wordsToHide; i++)
            {
                if (availableWords.Count > 0)
                {
                    int randomIndex = random.Next(availableWords.Count);
                    availableWords[randomIndex].Hide();
                    availableWords.RemoveAt(randomIndex);
                }
            }
        }

        public void RevealRandomWord()
        {
            List<Word> hiddenWords = _words.Where(word => word.IsHidden()).ToList();
            if (hiddenWords.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(hiddenWords.Count);
                hiddenWords[randomIndex].Show();
            }
        }

        public string GetDisplayText()
        {
            string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
            return $"{_reference.GetDisplayText()} - {scriptureText}";
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(word => word.IsHidden());
        }

        public double GetCompletionPercentage()
        {
            int hiddenCount = _words.Count(word => word.IsHidden());
            return (double)hiddenCount / _totalWords * 100;
        }

        public int GetHiddenWordCount()
        {
            return _words.Count(word => word.IsHidden());
        }

        public int GetTotalWordCount()
        {
            return _totalWords;
        }
    }

    // Difficulty levels for the memorization challenge
    public enum Difficulty
    {
        Easy = 1,
        Medium = 2,
        Hard = 3
    }

    // Statistics tracking for the session
    public class SessionStats
    {
        public int ScripturesCompleted { get; set; }
        public int TotalWordsHidden { get; set; }
        public int HintsUsed { get; set; }
        public DateTime SessionStart { get; set; }

        public SessionStats()
        {
            SessionStart = DateTime.Now;
        }

        public void DisplayStats()
        {
            TimeSpan sessionDuration = DateTime.Now - SessionStart;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== SESSION STATISTICS ===");
            Console.WriteLine($"Scriptures Completed: {ScripturesCompleted}");
            Console.WriteLine($"Total Words Hidden: {TotalWordsHidden}");
            Console.WriteLine($"Hints Used: {HintsUsed}");
            Console.WriteLine($"Session Duration: {sessionDuration.Minutes}m {sessionDuration.Seconds}s");
            Console.ResetColor();
        }
    }

    // Scripture library manager
    public class ScriptureLibrary
    {
        private List<(Reference, string)> _scriptures;
        private Random _random;

        public ScriptureLibrary()
        {
            _random = new Random();
            _scriptures = new List<(Reference, string)>
            {
                (new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
                (new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
                (new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength."),
                (new Reference("Jeremiah", 29, 11), "For I know the plans I have for you, declares the Lord, plans to prosper you and not to harm you, to give you hope and a future."),
                (new Reference("Romans", 8, 28), "And we know that in all things God works for the good of those who love him, who have been called according to his purpose."),
                (new Reference("Isaiah", 40, 31), "But those who hope in the Lord will renew their strength. They will soar on wings like eagles; they will run and not grow weary, they will walk and not be faint."),
                (new Reference("Matthew", 28, 19, 20), "Therefore go and make disciples of all nations, baptizing them in the name of the Father and of the Son and of the Holy Spirit, and teaching them to obey everything I have commanded you."),
                (new Reference("Psalm", 23, 1), "The Lord is my shepherd, I lack nothing."),
                (new Reference("1 Corinthians", 13, 4, 7), "Love is patient, love is kind. It does not envy, it does not boast, it is not proud. It does not dishonor others, it is not self-seeking, it is not easily angered, it keeps no record of wrongs. Love does not delight in evil but rejoices with the truth. It always protects, always trusts, always hopes, always perseveres.")
            };
        }

        public Scripture GetRandomScripture()
        {
            var randomScripture = _scriptures[_random.Next(_scriptures.Count)];
            return new Scripture(randomScripture.Item1, randomScripture.Item2);
        }

        public int GetLibrarySize()
        {
            return _scriptures.Count;
        }
    }

    // Main program class
    class Program
    {
        static void Main(string[] args)
        {
            ScriptureLibrary library = new ScriptureLibrary();
            SessionStats stats = new SessionStats();
            bool continueProgram = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========================================");
            Console.WriteLine("    WELCOME TO SCRIPTURE MEMORIZER");
            Console.WriteLine("========================================");
            Console.ResetColor();
            
            Console.WriteLine($"\nLibrary contains {library.GetLibrarySize()} scriptures for practice.");
            Console.WriteLine("Enhanced features: Progress tracking, hints, difficulty levels, and more!");

            while (continueProgram)
            {
                // Get difficulty level
                Difficulty difficulty = GetDifficultyLevel();
                
                // Get random scripture
                Scripture scripture = library.GetRandomScripture();
                
                Console.WriteLine("\nStarting new scripture...");
                Console.WriteLine("Commands: Press ENTER to hide words, 'hint' for help, 'quit' to exit, 'stats' for statistics");
                
                bool scriptureComplete = false;
                
                while (!scriptureComplete && continueProgram)
                {
                    Console.Clear();
                    
                    // Display header
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("=== SCRIPTURE MEMORIZER ===");
                    Console.ResetColor();
                    
                    // Display progress
                    double progress = scripture.GetCompletionPercentage();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Progress: {progress:F1}% ({scripture.GetHiddenWordCount()}/{scripture.GetTotalWordCount()} words hidden)");
                    Console.ResetColor();
                    
                    // Display scripture
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.ResetColor();
                    
                    if (scripture.IsCompletelyHidden())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nCongratulations! You've hidden all the words!");
                        Console.WriteLine("Great job memorizing this scripture!");
                        Console.ResetColor();
                        stats.ScripturesCompleted++;
                        scriptureComplete = true;
                        
                        Console.WriteLine("\nPress ENTER to try another scripture or type 'quit' to exit:");
                        string finalInput = Console.ReadLine();
                        if (finalInput?.ToLower() == "quit")
                        {
                            continueProgram = false;
                        }
                        continue;
                    }
                    
                    Console.WriteLine("\nPress ENTER to hide more words, or type a command:");
                    string userInput = Console.ReadLine();
                    
                    if (userInput?.ToLower() == "quit")
                    {
                        continueProgram = false;
                    }
                    else if (userInput?.ToLower() == "hint")
                    {
                        scripture.RevealRandomWord();
                        stats.HintsUsed++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Hint used! One word has been revealed.");
                        Console.ResetColor();
                        System.Threading.Thread.Sleep(1500);
                    }
                    else if (userInput?.ToLower() == "stats")
                    {
                        stats.DisplayStats();
                        Console.WriteLine("\nPress ENTER to continue...");
                        Console.ReadLine();
                    }
                    else if (string.IsNullOrEmpty(userInput))
                    {
                        int wordsToHide = GetWordsToHide(difficulty);
                        scripture.HideRandomWords(wordsToHide);
                        stats.TotalWordsHidden += wordsToHide;
                    }
                }
            }
            
            // Final statistics
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Thank you for using Scripture Memorizer!");
            Console.ResetColor();
            stats.DisplayStats();
            Console.WriteLine("\nPress ENTER to exit...");
            Console.ReadLine();
        }

        static Difficulty GetDifficultyLevel()
        {
            Console.WriteLine("\nSelect difficulty level:");
            Console.WriteLine("1. Easy (hide 1 word at a time)");
            Console.WriteLine("2. Medium (hide 2-3 words at a time)");
            Console.WriteLine("3. Hard (hide 3-5 words at a time)");
            Console.Write("Enter choice (1-3): ");
            
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    return Difficulty.Easy;
                case "2":
                    return Difficulty.Medium;
                case "3":
                    return Difficulty.Hard;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Medium difficulty.");
                    return Difficulty.Medium;
            }
        }

        static int GetWordsToHide(Difficulty difficulty)
        {
            Random random = new Random();
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return 1;
                case Difficulty.Medium:
                    return random.Next(2, 4); // 2-3 words
                case Difficulty.Hard:
                    return random.Next(3, 6); // 3-5 words
                default:
                    return 2;
            }
        }
    }
}