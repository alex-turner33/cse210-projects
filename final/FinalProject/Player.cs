using System;
using System.Numerics;               
using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;

public class Player : Entity
{
    private bool _canMoveX = false;
    private bool _canJump = true;
    private int _speedMultiplier = 0;
    private float _jumpSpeed;
    static int _jumpTime = 15;
    private int currentJumpTime = _jumpTime;


    public Player(int x, int y, int width, int height, Color color, float xVel, float jumpSpeed, int health, int screenWidth, int screenHeight) : base(x, y, width, height, color, xVel, health, screenWidth, screenHeight)
    {
        _jumpSpeed = jumpSpeed;
    }

    public override void Update(float dt)
    {
        Collision();

        Move(dt);
    }

    public override void Draw()
    {
        Raylib.DrawRectangleRec(_rect, _color);
    }

    public override void Move(float dt)
    {
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            _canMoveX = true;
            _speedMultiplier = -1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            _canMoveX = true;
            _speedMultiplier = 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            _canJump = false;
        }


        if (Raylib.IsKeyReleased(KeyboardKey.A))
        {
            _canMoveX = false;
        }
        if (Raylib.IsKeyReleased(KeyboardKey.D))
        {
            _canMoveX = false;
        }

        if (_canMoveX)
        {
            _rect.X += _xVel * dt * _speedMultiplier;
        }

        if (!_grounded)
        {
            _rect.Y += _gravity;
        }

        if (!_canJump)
        {
            if (_canJump)
            {
                currentJumpTime = _jumpTime;
            }

            if (_jumpTime >= 0)
            {
                currentJumpTime -= 1;
                _rect.Y -= _jumpSpeed;
            }
        }
    }

    public override void Collision()
    {
        if (_rect.X < 0)
        {
            _rect.X = 0;
            _speedMultiplier = 0;
        }
        if (_rect.X + _rect.Width >= _screenWidth)
        {
            _rect.X = _screenWidth - _rect.Width;
            _speedMultiplier = 0;
        }
        if (_rect.Y + _rect.Height >= _screenHeight)
        {
            _grounded = true;
            _canJump = true;
        }
    }
}