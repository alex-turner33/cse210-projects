using System;
using System.Numerics;               
using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;

public class Enemy : Entity
{
    private float _timer = 0f;

    public Enemy(int x, int y, int width, int height, Color color, string type, float xVel, float jumpSpeed, int health, int screenWidth, int screenHeight) : base(x, y, width, height, color, type, xVel, health, screenWidth, screenHeight)
    {

    }

    public override void Update(float dt)
    {

    }

    public override void Draw()
    {
        Raylib.DrawRectangleRec(_rect, _color);
    }
    public override void Move(float dt, List<Tile> tiles)
    {
        _timer += dt;
        if (_timer <= 1f)
        {
            _speedMultiplier = 1;
        }
        else if (_timer > 1f && _timer < 2f)
        {
            _speedMultiplier = -1;
        }
        else
        {
            _timer = 0f;
        }

        _rect.X += _xVel * dt * _speedMultiplier;
        HorizontalCollisions(tiles, dt);

        _yVel += _gravity * dt;
        _rect.Y += _yVel * dt;
        VerticalCollisions(tiles);
    }

    public override void BulletCollisions(List<Bullet> bullets)
    {
        for (int i = 0; i <= bullets.Count() - 1; i++)
        {
            if (Raylib.CheckCollisionCircleRec(new Vector2(bullets[i].GetRect().X + bullets[i].GetRect().Width / 2f, bullets[i].GetRect().Y + bullets[i].GetRect().Height / 2f), bullets[i].GetRect().Width / 2f, _rect))
            {
                DecreaseHealth(1);
                bullets.RemoveAt(i);
            }
        }
    }
}