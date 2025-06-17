using System;

class Activity
{
    private string _Intro;
    private string _Title;
    private int _duration;

    public Activity(string title, string intro)
    {
        _Intro = intro;
        _Title = title;
    }

    public void Intro()
    {
        Console.WriteLine($"Welcome to the {_Title}.");
        Console.WriteLine();
        Console.WriteLine($"{_Intro}");
    }

    public void Outro()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_Title} Activity.");

        Spin(5);
    }

    public void Spin(int length)
    {
        List<string> animation = new List<string> { "-", "\\", "|", "/" };
        DateTime endTime = DateTime.Now.AddSeconds(length);
        int i = 0;

        Console.Write("");
        while (DateTime.Now < endTime)
        {
            Console.Write("\b \b");
            Console.Write(animation[i]);
            Thread.Sleep(500);
            if (i < animation.Count() - 1)
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
        Console.Write("\b \b");
    }

    public int PromptForDuration()
    {
        Console.WriteLine();
        Console.Write("How Long, in seconds, would you like for your session? ");

        int duration = int.Parse(Console.ReadLine());

        _duration = duration;

        return duration;
    }

    public void CountDown(int seconds)
    {
        Console.Write("");
        for (int i = seconds; i >= 0; i--)
        {
            Console.Write("\b \b");
            if (i != 0)
            {
                Console.Write(i);
            }
            else
            {
                Console.Write("");
            }

            Thread.Sleep(1000);
        }
    }

    public string GetIntro()
    {
        return _Intro;
    }

    public string GetTitle()
    {
        return _Title;
    }

    public int getDuration()
    {
        return _duration;
    }

}