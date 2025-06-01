using System;
using System.Net;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> _scriptRef1 = new List<string> { "Helaman 5:12", "And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation; that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall." };
        List<string> _scriptRef2 = new List<string> { "John 11:35", "Jesus wept." };
        List<string> _scriptRef3 = new List<string> { "1 Nephi 4:6", "And I was led by the Spirit, not knowing beforehand the things which I should do." };
        List<string> _scriptRef4 = new List<string> { "Mosiah 18:8-10", "8 And it came to pass that he said unto them: Behold, here are the waters of Mormon (for thus were they called) and now, as ye are desirous to come into the fold of God, and to be called his people, and are willing to bear one another’s burdens, that they may be light; 9 Yea, and are willing to mourn with those that mourn; yea, and comfort those that stand in need of comfort, and to stand as witnesses of God at all times and in all things, and in all places that ye may be in, even until death, that ye may be redeemed of God, and be numbered with those of the first resurrection, that ye may have eternal life— 10 Now I say unto you, if this be the desire of your hearts, what have you against being baptized in the name of the Lord, as a witness before him that ye have entered into a covenant with him, that ye will serve him and keep his commandments, that he may pour out his Spirit more abundantly upon you?" };


        Scripture _script1 = new Scripture(_scriptRef1[0], _scriptRef1[1], false);
        Scripture _script2 = new Scripture(_scriptRef2[0], _scriptRef2[1], false);
        Scripture _script3 = new Scripture(_scriptRef3[0], _scriptRef3[1], false);
        Scripture _script4 = new Scripture(_scriptRef4[0], _scriptRef4[1], true);
        Scripture _currentScripture = null;

        Console.WriteLine($"{_scriptRef1[0]}, {_scriptRef2[0]}, {_scriptRef3[0]}, {_scriptRef4[0]}");
        Console.WriteLine($"What scripture would you like to work on? ");
        string answer = Console.ReadLine();

        if (answer == _scriptRef1[0])
        {
            _currentScripture = _script1;
        } else if (answer == _scriptRef2[0])
        {
            _currentScripture = _script2;
        } else if (answer == _scriptRef3[0])
        {
            _currentScripture = _script3;
        } else if (answer == _scriptRef4[0])
        {
            _currentScripture = _script4;
        }

        bool run = true;
        while (run)
        {
            _currentScripture.Display();

            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            string response = Console.ReadLine();

            if (string.IsNullOrEmpty(response))
            {
                if (_currentScripture.AreAllHidden() == true)
                {
                    run = false;
                    break;
                }

                _currentScripture.HideWords();
            }
            else
            {
                run = false;
            }

        }
    }
}