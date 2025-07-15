using System;
using System.Numerics;               
using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;

public class Player : Entity
{ 
    private float _jumpSpeed;

    private int _xOffset = 0;
    private int _yOffset = 0;

    public Player(int x, int y, int width, int height, Color color, float xVel, float jumpSpeed, int health, int screenWidth, int screenHeight) : base(x, y, width, height, color, xVel, health, screenWidth, screenHeight)
    {
        _jumpSpeed = jumpSpeed;
    }

    public override void Draw()
    {
        Raylib.DrawRectangleRec(_rect, _color);
    }

    public override void Move(float dt, List<Tile> tiles)
    {

        _speedMultiplier = 0;
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            _speedMultiplier = -1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            _speedMultiplier = 1;
        }
        if (_grounded && Raylib.IsKeyDown(KeyboardKey.W))
        {
            _yVel = _jumpSpeed;
        }

    
        _rect.X += _xVel * dt * _speedMultiplier;
        HorizontalCollisions(tiles, dt);

        _yVel += _gravity * dt;
        _rect.Y += _yVel * dt;
        VerticalCollisions(tiles);
    }
}