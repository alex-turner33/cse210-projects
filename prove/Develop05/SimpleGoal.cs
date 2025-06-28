using System;

class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points) { }

    public override int AccomplishGoal()
    {
        _Done = true;

        Console.WriteLine($"Congradulations! You have earned {_Points} points!");
        return _Points;
    }

    public override string SaveString()
    {
        return $"SimpleGoal:{_Name},{_Description},{_Points},{_Done}";
    }
}