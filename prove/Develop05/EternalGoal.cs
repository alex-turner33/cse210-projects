using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override int AccomplishGoal()
    {
        Console.WriteLine($"Congradulations! You have earned {_Points} points!");
        return _Points;
    }

    public override string SaveString()
    {
        return $"EternalGoal:{_Name},{_Description},{_Points},{_Done}";
    }
}