using System;

class Program
{
    static List<Goal> _Goals = new List<Goal>();
    static int _Points = 0;
    static int _PointsPerLevel = 150;
    static int _Level = 0;

    private static bool _Run = true;

    static void Main(string[] args)
    {
        while (_Run)
        {
            Display();
        }
    }

    public static void Display()
    {

        Console.WriteLine("Menu Options: \n   1. Create New Goal \n   2. List Goals\n   3. Save Goals\n   4. Load Goals\n   5. Record Events\n   6. Quit\n");
        Console.Write("Select a choice from the menu: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("The types of Goals are: ");
                Console.WriteLine("   1. Simple Goal\n   2. Eternal Goal\n   3. Checklist Goal");
                Console.Write("Which type of goal would you like to create? ");
                int choice_two = int.Parse(Console.ReadLine());

                Console.Write("What is the name of your goal? ");
                string name = Console.ReadLine();

                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();

                Console.Write("What is the amount of points associated with this goal? ");
                int points = int.Parse(Console.ReadLine());

                if (choice_two == 1)
                {
                    SimpleGoal goal = new SimpleGoal(name, description, points);
                    _Goals.Add(goal);
                }
                else if (choice_two == 2)
                {
                    EternalGoal goal = new EternalGoal(name, description, points);
                    _Goals.Add(goal);
                }
                else if (choice_two == 3)
                {
                    Console.Write("How many times deos this goal need to be accomplished for a bonus? ");
                    int amount = int.Parse(Console.ReadLine());

                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());

                    CheckListGoal goal = new CheckListGoal(name, description, points, bonus, amount);
                    _Goals.Add(goal);
                }
                else
                {
                    Console.WriteLine("Unexpected input");
                }

                break;

            case 2:
                int goal_count = 1;

                foreach (Goal goal in _Goals)
                {
                    string symbol = " ";
                    if (goal.IsDone())
                    {
                        symbol = "X";
                    }

                    Console.WriteLine($"{goal_count}. [{symbol}] " + goal.ShowGoal());
                    goal_count += 1;
                }
                break;
            case 3:
                Save();
                break;
            case 4:
                Load();
                break;
            case 5:
                int goal_count2 = 1;

                Console.WriteLine("The goals are: ");
                foreach (Goal goal in _Goals)
                {
                    if (!goal.IsDone())
                    {
                        Console.WriteLine($"{goal_count2}. {goal.getName()}");
                        goal_count2 += 1;
                    }
                }
                Console.Write("Which goal did you accomplish? ");
                int accomplishedGoal = int.Parse(Console.ReadLine());
                try
                {
                    _Points += _Goals[accomplishedGoal - 1].AccomplishGoal();
                    UpdateLevel();
                }
                catch
                {
                    Console.WriteLine("Unexpected input");
                }
                            
                Console.WriteLine($"You now have {_Points} and are at level {_Level}.");
                break;
            case 6:
                _Run = false;
                break;
            default:
                Console.WriteLine("Unexpected input00");
                break;
        }

        DisplayStats();    
    }

    public static void DisplayStats()
    {
        Console.WriteLine($"\nYou have {_Points} points and are level {_Level}\n");

    }

    public static void UpdateLevel()
    {
        while (_Points >= _PointsPerLevel)
        {
            _Points -= 100;
            _Level++;
        }
    }

    public static void Load()
    {
        Console.Write("What is the filename for your goal file? ");
        string load_filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(load_filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(":");

            if (parts[0] == "Points")
            {
                _Points = int.Parse(parts[1]);
            }
            if (parts[0] == "PointsPerLevel")
            {
                _PointsPerLevel = int.Parse(parts[1]);
            }
            if (parts[0] == "Level")
            {
                _Level = int.Parse(parts[1]);
            }

            string[] stats = parts[1].Split(",");
            if (parts[0] == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(stats[0], stats[1], int.Parse(stats[2]));
                goal.SetDone(bool.Parse(stats[3]));
                _Goals.Add(goal);
            }
            else if (parts[0] == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(stats[0], stats[1], int.Parse(stats[2]));
                goal.SetDone(bool.Parse(stats[3]));
                _Goals.Add(goal);
            }
            else if (parts[0] == "CheckListGoal")
            {
                CheckListGoal goal = new CheckListGoal(stats[0], stats[1], int.Parse(stats[2]), int.Parse(stats[3]), int.Parse(stats[4]));
                _Goals.Add(goal);
                goal.SetProgress(int.Parse(stats[5]));
                goal.SetDone(bool.Parse(stats[6]));
            }
        }
    }

    public static void Save()
    {
        Console.Write("What is the filename for your goal file? ");
        string save_filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(save_filename))
        {
            outputFile.WriteLine($"Points:{_Points}");
            outputFile.WriteLine($"PointsPerLevel:{_PointsPerLevel}");
            outputFile.WriteLine($"Level:{_Level}");
            foreach (Goal goal in _Goals)
            {
                outputFile.WriteLine(goal.SaveString());
            }
        }
    }
}