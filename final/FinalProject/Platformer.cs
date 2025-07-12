using System;
using System.Numerics;
using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;

static class Platformer
{
    private const int _screenWidth = 800; 
    private const int _screenHeight = 500; 
    private const int _FPS = 60; 

    public static void Main()
    {
        Raylib.InitWindow(_screenWidth, _screenHeight, "Survivor");
        Raylib.SetTargetFPS(_FPS);

        Player player = new Player(250, 250, 50, 100, Color.Red, 300f, 10f, 10, _screenWidth, _screenHeight);

        while (!Raylib.WindowShouldClose())
        {
            float dt = Raylib.GetFrameTime();

            player.Update(dt);

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            player.Draw();

            Raylib.EndDrawing();
        }
    }
}