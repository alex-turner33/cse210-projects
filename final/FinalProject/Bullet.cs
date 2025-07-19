using System;
using System.Numerics;
using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;
public class Bullet : Weapon
{
    private int _Speed;
    private float _timer;

    public Bullet(int x, int y, int width, int height, int damage, int speed, Gun gun) : base(x, y, width, height, damage)
    {
        _Speed = speed;

        if (!gun.IsFacingRight())
        {
            _rect.X = gun.GetRect().X + _rect.Width;
            _isFacingRight = false;
        }
        else if (gun.IsFacingRight())
        {
            _rect.X = gun.GetRect().X + gun.GetRect().Width - _rect.Width;
            _isFacingRight = true;
        }

        _rect.Y = gun.GetRect().Y + gun.GetRect().Height / 2f;
    }

    public override void Update(float dt)
    {
        _timer += dt;

        Move(dt);
    }

    public void Draw(Gun gun)
    {


        Raylib.DrawCircle((int)_rect.X, (int)_rect.Y, _rect.Width, Color.Black);
    }

    public override void Move(float dt)
    {
        if (_isFacingRight)
        {
            _rect.X += _Speed;
        }
        else
        {
            _rect.X -= _Speed;
        }
    }

    public float GetTimer()
    {
        return _timer;
    }
}