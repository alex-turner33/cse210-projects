using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");

        float grade = float.Parse(Console.ReadLine());

        string addition = "";
        string letter = "";

        if (grade >= 90){
            letter = "A";
        } else if (grade >= 80){
            letter = "B";
        } else if (grade >= 70){
            letter = "C";
        } else if (grade >= 60){
            letter = "D";
        } else if (grade < 60){
            letter = "F";
        }

        if (letter != "F"){
            if (grade % 10 >= 7){
                if (letter != "A"){
                    addition = "+";
                }
            } else if (grade % 10 < 3){
                addition = "-";
            }
        }

        Console.WriteLine($"Your grade is: {letter}{addition}");
        if (grade >= 70){
            Console.WriteLine("Congradulations you passed the class!");
        }
    }
}