using System;

class Listing : Activity
{
    List<string> _questions = new List<string> {"Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"};
    List<string> _answers = new List<string>();

    public Listing(string title, string intro) : base(title, intro)
    {

    }

    public string PromptQuestion()
    {
        Random rand = new Random();

        return _questions[rand.Next(0, _questions.Count())];
    }

    public void ShowAnswers()
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

        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt: ");
        Console.WriteLine($" -- {PromptQuestion()} -- ");
        Console.Write("You may begin in:  ");
        CountDown(4);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(getDuration());

        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
            Console.Write("> ");
            _answers.Add(Console.ReadLine());

            currentTime = DateTime.Now;
        }

        Console.WriteLine($"You listed {_answers.Count()} items!");

        Outro();
    }
}