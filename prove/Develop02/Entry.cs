using System;

public class Entry
{
    public string _date = "";
    public string _response = "";

    public string _prompt = "";

    public void Update()
    {
        DateTime theCurrentTime = DateTime.Now;
        _date = theCurrentTime.ToShortDateString();

        GetResponse();
    }

    private void GetResponse(   )
    { 
        bool valid = ValidResponse("Would you like a prompt? (yes/no) ");

        if (valid)
        {
            Prompt prompt = new Prompt();
            _prompt = prompt.GetPrompt();
            Console.WriteLine(_prompt);
            _response = Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Please begin writing");
            _response = Console.ReadLine();
        }
    }

    public bool ValidResponse(string str)
    {
        while (true)
        {
            Console.WriteLine(str);
            string user_response = Console.ReadLine();

            if (user_response == "yes")
            {
                return true;
            }
            else if (user_response == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please enter a valid response (yes/no).");
            }
        }
    }
    
}