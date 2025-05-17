using System;
using System.Text.Json.Nodes;

public class Program
{
    static void Main(string[] args)
    {
        FileSystem _fileSystem = new FileSystem();

        Journal _activeJournal = new Journal();
        bool _canSave = false;

        string options = "\nPlease select one of the following options\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\nWhat would you like to do";

        bool run = true;

        Console.WriteLine("Welcome to the Jounal Program!");
        while (run)
        {
            Display(options);
            string input = GetResponse();
            int response;

            if (!int.TryParse(input, out response))
            {
                Console.WriteLine("Please enter a valid number");
                continue;
            }

            switch (response)
            {
                case 1:
                    _activeJournal.AddEntry();
                    Console.WriteLine("Entry added.");
                    break;
                case 2:
                    _activeJournal.DisplayEntries();
                    Console.WriteLine("Entries displayed.");
                    break;
                case 3:
                    Console.WriteLine("What is the name of the file you would like to load? ");
                    string user_input = Console.ReadLine() + ".json";
                    if (File.Exists(user_input))
                    {
                        _activeJournal = _fileSystem.LoadFile(user_input);
                        _canSave = true;
                    }
                    else
                    {
                        Console.WriteLine("That file doesn't exist. Would you like to create a new journal? (yes/no)");
                        string new_journal = Console.ReadLine();
                        if (new_journal == "yes")
                        {
                            _canSave = true;
                            Console.WriteLine("Enter a name for your journal: ");
                            string name = Console.ReadLine() + ".json";
                            _activeJournal._name = name;
                            _activeJournal._entryList.Clear();
                            Console.WriteLine(_activeJournal._name);
                        }
                        else if (new_journal == "no")
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid response.");
                        }
                    }
                    Console.WriteLine("File loaded.");
                    break;
                case 4:
                    if (_canSave)
                    {
                        _fileSystem.SaveFile(_activeJournal);
                    }
                    else
                    {
                        Console.WriteLine("Unable to save. No file loaded.");
                    }
                    Console.WriteLine("Journal saved.");
                    break;
                case 5:
                    run = false;
                    Console.WriteLine("Have a great day!");
                    break;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
            }
        }
    }
    static void Display(string message)
    {
        Console.WriteLine(message);
    }

    static string GetResponse()
    {
        return Console.ReadLine();
    }
}