using System;

class Word
{
    private string _word;
    private bool _shown = true;

    public Word(string word)
    {
        _word = word;
    }

    public string getWord()
    {
        if (!_shown)
        {
            return new string('_', _word.Length);
        }
        else
        {
            return _word;
        }
    }

    public bool getVisibility()
    {
        return _shown;
    }

    public void setVisibility(bool value)
    {
        _shown = value;
    }
}