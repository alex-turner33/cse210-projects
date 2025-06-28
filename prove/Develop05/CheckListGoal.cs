using System;

class CheckListGoal : Goal
{
    int _Bonus = 0;
    int _Ammount = 0;
    int _Progress = 0;

    public CheckListGoal(string name, string description, int points, int bonus, int ammount) : base(name, description, points)
    {
        _Bonus = bonus;
        _Ammount = ammount;
    }

    public override string ShowGoal()
    {
        return $"{_Name} ({_Description}) -- Currently completed: {_Progress}/{_Ammount}";
    }

    public override int AccomplishGoal()
    {
        _Progress += 1;

        int goal_points = _Points;
        if (_Progress == _Ammount)
        {
            _Done = true;
            goal_points += _Bonus;
        }

        Console.WriteLine($"Congradulations! You have earned {goal_points} points!");

        return goal_points;
    }

    public override string SaveString()
    {
        return $"CheckListGoal:{_Name},{_Description},{_Points},{_Bonus},{_Ammount},{_Progress},{_Done}";
    }

    public void SetProgress(int progress)
    {
        _Progress = progress;
    }
}