using System;
using System.Numerics;
using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;

static class Platformer
{
    static int _screenWidth = 1250;
    static int _screenHeight = 800;

    static string _state = "start";
    static int _levelNumber = 0;

    public static void Main()
    {
        Menu startMenu = new Menu("Start", "Exit", "Final Project - Platformer", _screenWidth, _screenHeight);
        Menu deadMenu = new Menu("Continue", "Exit", "You lost, would you like to play again?", _screenWidth, _screenHeight);
        Menu wonMenu = new Menu("Again", "Exit", "You won, Gradulations!", _screenWidth, _screenHeight);

        Level level1 = new Level("level1.txt", _screenWidth, _screenHeight);
        Level level2 = new Level("level2.txt", _screenWidth, _screenHeight);
        Level level3 = new Level("level3.txt", _screenWidth, _screenHeight);

        Raylib.InitWindow(_screenWidth, _screenHeight, "Platformer");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);


            if (_state == "start")
            {
                startMenu.Draw();
                if (startMenu.Button1Pressed())
                {
                    _state = "";
                    _levelNumber = 1;
                    startMenu.ClearPressed();
                }
                else if (startMenu.Button2Pressed())
                {
                    break;
                }
            }
            else if (_state == "dead")
            {
                deadMenu.Draw();
                if (deadMenu.Button1Pressed())
                {
                    _state = "";
                    _levelNumber = 1;
                    deadMenu.ClearPressed();
                }
                else if (deadMenu.Button2Pressed())
                {
                    break;
                }
            }
            else if (_state == "won")
            {
                wonMenu.Draw();
                if (wonMenu.Button1Pressed())
                {
                    _state = "";
                    _levelNumber = 1;
                    wonMenu.ClearPressed();
                }
                else if (wonMenu.Button2Pressed())
                {
                    break;
                }
            }

            if (_state == "")
            {
                
                if (_levelNumber == 1)
                {
                    level1.Main();
                    if (level1.GameWon())
                    {
                        _levelNumber = 2;
                        level1.Reset();
                    }
                    else if (level1.PlayerDead())
                    {
                        _state = "dead";
                        level1.Reset();
                    }
                }
                else if (_levelNumber == 2)
                {
                    level2.Main();
                    if (level2.GameWon())
                    {
                        _levelNumber = 3;
                        level2.Reset();
                    }
                    else if (level2.PlayerDead())
                    {
                        _state = "dead";
                        level2.Reset();
                    }
                }
                else if (_levelNumber == 3)
                {
                    level3.Main();
                    if (level3.GameWon())
                    {
                        _state = "won";
                        level3.Reset();
                    }
                    else if (level3.PlayerDead())
                    {
                        _state = "dead";
                        level3.Reset();
                    }
                }
            }

            Raylib.EndDrawing();
        }
    }
}