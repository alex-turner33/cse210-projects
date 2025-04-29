using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        bool running = true;
        while (running){
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            if (number != 0){
                numbers.Add(number);
            } else {
                running = false;
            }
        }

        int sum = 0;
        int smallest_positive_number = numbers[0];
        int largest_number = numbers[0];
        foreach(int number in numbers){
            sum += number;

            if(number < smallest_positive_number && number >= 0){
                smallest_positive_number = number;
            }
            if(number > largest_number){
                largest_number = number;
            }
        }
        Console.WriteLine($"The sum is: {sum}");

        float avg = sum/numbers.Count;
        Console.WriteLine($"The average is: {avg}");

        Console.WriteLine($"The largest number is: {largest_number}");

        Console.WriteLine($"The smallest positive number is: {smallest_positive_number}");
        
        List<int> sorted_number_list = new List<int> (numbers);
        sorted_number_list.Sort();

        foreach(int number in sorted_number_list){
            Console.WriteLine(number);
        }

    }
}