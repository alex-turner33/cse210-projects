using System;
using System.Numerics;
using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;

static class Platformer
{


    public static void Main()
    {
        Level level1 = new Level("level1.txt");
        level1.Main();
    }
}