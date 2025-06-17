using System;

class Breathing : Activity
{

    public Breathing(string title, string intro) : base(title, intro)
    {

    }

    public void RunActivity()
    {
        Console.Clear();

        Intro();
        PromptForDuration();

        Console.Clear();

        Console.WriteLine("Get ready...");
        Spin(3);

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(getDuration());

        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
            Console.WriteLine();

            Console.Write("Breath in....");
            CountDown(4);
            Console.WriteLine();
            Console.Write("Now breath out....");
            CountDown(5);
            Console.WriteLine();

            currentTime = DateTime.Now;
        }

        Outro();
    }
}