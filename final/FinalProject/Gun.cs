using System;
using System.Numerics;
using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;
public class Gun : Weapon
{

    public Gun(float x, float y, int width, int height, int damage) : base(x, y, width, height, damage)
    {

    }

    public override void Update(float dt)
    {

    }

    public void Draw(Player player)
    {
        if (player.GetSpeedMultiplier() < 0)
        {
            _rect.X = player._rect.X - _rect.Width + 16;
            _isFacingRight = false;
        }
        else if (player.GetSpeedMultiplier() > 0)
        {
            _rect.X = player._rect.X + player._rect.Width - 16;
            _isFacingRight = true;
        }

        _rect.Y = player._rect.Y + 20;

        Raylib.DrawRectangleRec(_rect, Color.Black);
    }

    public bool IsFacingRight()
    {
        return _isFacingRight;
    }

    public override void Move(float dt)
    {

    }
}