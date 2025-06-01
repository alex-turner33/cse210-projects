using System;

public class Scripture
{
    private List<Word> _words;
    private Reference _ref;
    private int _depth;

    public Scripture(string scripture_ref, string text, bool multiple_verses)
    {
        _words = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(w => new Word(w)).ToList();

        if (!multiple_verses)
        {
            string[] script_ref = scripture_ref.Split(new[] { " ", ":" }, StringSplitOptions.RemoveEmptyEntries); //Helman 5:12-13
            _ref = new Reference(script_ref[0], script_ref[1], script_ref[2]);
        }
        else
        {
            string[] script_ref = scripture_ref.Split(new[] { " ", ":", "-" }, StringSplitOptions.RemoveEmptyEntries); //Helman 5:12-13
            _ref = new Reference(script_ref[0], script_ref[1], script_ref[2], script_ref[3]);
        }


    }

    public void Display()
    {
        Console.Write(_ref.getReference());

        for (int i = 0; i < _words.Count(); i++)
        {
            Console.Write(" " + _words[i].getWord());
        }
    }

    public void HideWords()
    {
        Random _rand = new Random();

        int numberToHide = 3;
        int hiddenNumber = 0;

        while (hiddenNumber != numberToHide)
        {
            int randomNumber = _rand.Next(_words.Count());
            if (_words[randomNumber].getVisibility() == true)
            {
                _words[randomNumber].setVisibility(false);
                hiddenNumber += 1;
            }
        }
    }

    public bool AreAllHidden()
    {
        int hiddenCounter = 0;
        for (int i = 0; i < _words.Count(); i++)
        {
            if (_words[i].getVisibility() == false)
            {
                hiddenCounter += 1;
            }
        }

        if (hiddenCounter == _words.Count())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}