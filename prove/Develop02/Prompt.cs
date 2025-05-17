using System;


public class Prompt
{
    List<string> _prompts = new List<string>{
        "What’s one goal I want to work on?",
        "What advice would I give myself right now?",
        "What am I grateful for today?",
        "What small thing makes me happy?",
        "Who impacted me recently and how?",
        "What’s been hard lately?",
        "What’s one moment I’d relive from this week?",
        "What happened today that made me feel really good or really bad?",
         };

    public string GetPrompt()
    {
        Random random = new Random();
        int random_number = random.Next(0,8);

        return _prompts[random_number];
    }
}