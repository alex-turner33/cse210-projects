using System;
using System.Collections.Generic;
using System.IO;
public class FileSystem
{
    public FileSystem()
    {

    }

    public List<List<int>> GetFile(string filename)
    {
        List<List<int>> list = new List<List<int>>();

        foreach (string line in File.ReadLines(filename))
        {
            List<int> row = new List<int>();

            foreach (string section in line.Split(","))
            {
                row.Add(int.Parse(section));
            }
            list.Add(row);
        }

        return list;
    }

    public void saveFile(string filename)
    {

    }
}