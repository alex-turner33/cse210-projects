using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        string play_again = "";
        do{
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1,101);

            int guess = -1;
            int guess_count = 0;

            while (guess != magicNumber){
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guess_count += 1;

                if (guess > magicNumber){
                    Console.WriteLine("Lower");
                } else if (guess < magicNumber){
                    Console.WriteLine("Higher");
                } else {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guess_count} attempts to guess the magic number {magicNumber}");
                }
            }

            Console.Write("Do you want to play again? (yes/no) ");
            play_again = Console.ReadLine();

        }while(play_again == "yes");
    }
}