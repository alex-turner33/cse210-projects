using System;

class Menu
{
    private Breathing _breathing = new Breathing("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
    private Reflecting _reflecting = new Reflecting("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
    private Listing _listing = new Listing("listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

    private bool _run = true;
    public void Display()
    {
        Console.Clear();

        Console.WriteLine("Menu Options: \n   1. Start breathing activity \n   2. Start reflecting activity\n   3. Start Listing activity\n   4. Quit");
        Console.Write("Select a choice from the menu: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                _breathing.RunActivity();
                break;
            case 2:
                _reflecting.RunActivity();
                break;
            case 3:
                _listing.RunActivity();
                break;
            case 4:
                _run = false;
                break;
            default:
                _run = false;
                break;
        }
    }

    public bool GetRun() {
        return _run;
    }
}