using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int numberSquared = SquareNumber(number);
        DisplayResult(name, numberSquared);
    }

   static void DisplayWelcome(){
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName(){
        Console.Write("Please enter your name: ");
        
        return Console.ReadLine();
    }

    static int PromptUserNumber(){
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number_to_square){
        return number_to_square * number_to_square;
    }

    static void DisplayResult(string name, int number){
        Console.WriteLine($"{name}, the square of your number is {number}");
    }
}