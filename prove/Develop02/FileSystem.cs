using System;
using System.Text.Json;
using System.IO;
using System.IO.Enumeration;

public class FileSystem
{

    public Journal LoadFile(string file_name)
    {
        string json_string = File.ReadAllText(file_name);
        Journal journal = JsonSerializer.Deserialize<Journal>(json_string, new JsonSerializerOptions { IncludeFields = true });
        Console.WriteLine(journal._name);
        return journal;
    }


    public void SaveFile(Journal journal)
    {
        string json_string = JsonSerializer.Serialize(journal, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
        File.WriteAllText(journal._name, json_string);
    }
}