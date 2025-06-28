using System;

abstract class Goal
{
    protected string _Name = "";
    protected string _Description = "";
    protected int _Points = 0;
    protected bool _Done = false;

    public Goal(string name, string description, int points)
    {
        _Name = name;
        _Description = description;
        _Points = points;
    }

    public virtual string ShowGoal() {
        return $"{_Name} ({_Description})";
    } 

    public abstract int AccomplishGoal();

    public bool IsDone() {
        return _Done;
    }

    public string getName()
    {
        return _Name;
    }

    public void SetDone(bool done)
    {
        _Done = done;
    }

    public abstract string SaveString();
}