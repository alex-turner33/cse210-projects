using System;

class Reflecting : Activity
{
    private List<string> _experiences = new List<string>{"Think of a time when you forgave someone who really hurt you.", "Think of a time when you sacrificed your own comfort for another person’s benefit.", "Think of a time when you took a risk to help someone else.", "Think of a time when you went out of your way to make someone’s day better.", "Think of a time when you stood up for a principle, even when it was unpopular.", "Think of a time when you coached or mentored someone through a challenge."};
    private List<string> _questions = new List<string>{"Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "What made this time different than other times when you were not as successful?", "What did you learn about yourself through this experience?", "What could you learn from this experience that applies to other situations?"};

    private List<string> _usedExperiences = new List<string>();
    private List<string> _usedQuestions = new List<string>();

    public Reflecting(string title, string intro) : base(title, intro)
    {

    }

    public string PromptExperience()
    {
        while (true)
        {
            if (_usedExperiences.Count() >= _questions.Count())
            {
                _usedExperiences.Clear();
            }

            Random rand = new Random();
            string experience = _experiences[rand.Next(0, _experiences.Count())];

            if (!_usedExperiences.Contains(experience))
            {
                _usedExperiences.Add(experience);
                return experience;
            }

        }
    }

    public string PromptQuestion()
    {
        while (true)
        {
            if (_usedQuestions.Count() >= _questions.Count())
            {
                _usedQuestions.Clear();
            }

            Random rand = new Random();
            string question = _questions[rand.Next(0, _questions.Count())];

            if (!_usedQuestions.Contains(question))
            {
                _usedQuestions.Add(question);
                return question;
            }

        }
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

        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine($" -- {PromptExperience()} -- ");
        Console.Write("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in:  ");
        CountDown(4);

        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(getDuration());

        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
            Console.Write($"{PromptQuestion()}  ");
            Spin(10);
            Console.WriteLine();

            currentTime = DateTime.Now;
        }

        Outro();
        
    }
}