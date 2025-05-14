using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        bool playAgain = true;
        
        while (playAgain)
        {
            
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;
            int guess = 0;
            
            Console.WriteLine("Welcome to Guess My Number Game!");
            Console.WriteLine("I've picked a number between 1 and 100.");
            
            
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;
                
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} tries!");
                }
            }
            
            
            Console.Write("Would you like to play again? (yes/no) ");
            string response = Console.ReadLine().ToLower();
            
            if (response != "yes")
            {
                playAgain = false;
                Console.WriteLine("Thanks for playing!");
            }
        }
    }
}