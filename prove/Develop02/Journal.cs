using System;

public class Journal
{
    public string _name = "";
    public List<Entry> _entryList = new List<Entry>();

    public void AddEntry()
    {
        Entry entry = new Entry();
        entry.Update();

        _entryList.Add(entry);
    }

    public Entry GetEntry(string date)
    {
        for (int i = 0; i < _entryList.Count(); i++)
        {
            if (_entryList[i]._date == date)
            {
                return _entryList[i];
            }
        }
        return null;
    }

    public void DisplayEntries(){
        for (int i = 0; i < _entryList.Count(); i++)
        {
            string date = _entryList[i]._date;
            string prompt = _entryList[i]._prompt;
            string response = _entryList[i]._response;

            Console.WriteLine($"\nDate: {date} - Prompt: {prompt}\n{response}\n");
        }
    }
}