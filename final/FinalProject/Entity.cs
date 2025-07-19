using System;
using System.Numerics;
using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;

public abstract class Entity
{
    public RayRectangle _rect;
    protected Color _color;

    protected string _type;

    protected bool _canJump = true;
    protected float _xVel;
    protected float _yVel;

    protected int _speedMultiplier = 0;
    protected float _gravity = 980f;
    protected int _health;
    protected int _originalHealth;
    protected int _screenWidth;
    protected int _screenHeight;
    protected bool _grounded = false;

    public Entity(int x, int y, int width, int height, Color color, string type, float xVel, int health, int screenWidth, int screenHeight)
    {
        _rect = new RayRectangle(x, y, width, height);
        _color = color;
        _type = type;
        _xVel = xVel;
        _health = health;
        _originalHealth = health;
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;
    }

    public void VerticalCollisions(List<Tile> tiles)
    {
        foreach (Tile tile in tiles)
        {
            if (tile.GetType() != "winBlock")
            {
                if (Raylib.CheckCollisionRecs(_rect, tile.GetRect()))
                {
                    if (_yVel > 0)
                    {
                        _rect.Y = tile.GetRect().Y - _rect.Height;
                        _yVel = 0;
                        _grounded = true;
                    }
                    else if (_yVel < 0)
                    {
                        _rect.Y = tile.GetRect().Y + tile.GetRect().Height;
                    }
                }
            }
        }
    }

    public void HorizontalCollisions(List<Tile> tiles, float dt)
    {
        foreach (Tile tile in tiles)
        {
            if (tile.GetType() != "winBlock")
            {
                if (Raylib.CheckCollisionRecs(_rect, tile.GetRect()))
                {
                    if (_speedMultiplier < 0)
                    {
                        _rect.X = tile.GetRect().X + tile.GetRect().Width;
                    }
                    if (_speedMultiplier > 0)
                    {
                        _rect.X = tile.GetRect().X - _rect.Width;
                    }
                }
            }
        }
    }

    public RayRectangle GetRect()
    {
        return _rect;
    }

    public abstract void Move(float dt, List<Tile> tiles);
    public abstract void Update(float dt);

    public abstract void Draw();

    public abstract void BulletCollisions(List<Bullet> bullets);

    public string GetType()
    {
        return _type;
    }

    public void DecreaseHealth(int sub)
    {
        _health -= sub;
    }

    public bool IsDead()
    {
        if (_health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}