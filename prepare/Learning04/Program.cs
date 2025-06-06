using System;

class Program
{
    static void Main(string[] args) //Used Chatgpt to solve error with .not for some reason Learning04.csproj had the net as 7.0 
    { //when it was supposed to be 8.0 like all the others otherwise no AI was used in the creation of this project

        Assignment assignment1 = new Assignment("Jacob Everton", "Math");
        Console.WriteLine(assignment1.GetSummary());

        Console.WriteLine();

        MathAssignment assignment2 = new MathAssignment("Jared Jackson", "Trig", "4.3", "18-22, 24");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());

        Console.WriteLine();

        WritingAssignment assignment3 = new WritingAssignment("Katlynn Mackson", "Writing", "My infamous story");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());

    }
}