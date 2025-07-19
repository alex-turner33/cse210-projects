using System;
using System.Numerics;               
using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;

public class Player : Entity
{
    private float _jumpSpeed;
    private float _damageTimer = 0f;
    private float _blinkTimer = 0f;

    private bool _canGainDamage = true;

    public Player(int x, int y, int width, int height, Color color, string type, float xVel, float jumpSpeed, int health, int screenWidth, int screenHeight) : base(x, y, width, height, color, type, xVel, health, screenWidth, screenHeight)
    {
        _jumpSpeed = jumpSpeed;
    }

    public override void Update(float dt)
    {
        _damageTimer += dt;
        _blinkTimer += dt;

        if (_damageTimer >= 2f && !_canGainDamage)
        {
            _canGainDamage = true;
            _damageTimer = 0;
        }
    }

    public override void Draw()
    {
        if (_canGainDamage)
        {
            Raylib.DrawRectangleRec(_rect, _color);
        }
        else
        {
            if (_blinkTimer <= 0.1f)
            {
                Raylib.DrawRectangleRec(_rect, _color);
            }
            else if (_blinkTimer > 0.1f && _blinkTimer <= 0.2f)
            {
                Raylib.DrawRectangleRec(_rect, Color.White);
            }
            else
            {
                _blinkTimer = 0;
            }
        }
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
            _grounded = false;
            _yVel = _jumpSpeed;
        }

        _rect.X += _xVel * dt * _speedMultiplier;
        HorizontalCollisions(tiles, dt);

        _yVel += _gravity * dt;
        _rect.Y += _yVel * dt;
        VerticalCollisions(tiles);
    }

    public void DamageByEnemy(List<Entity> entities)
    {
        foreach (Entity entity in entities)
        {
            if (Raylib.CheckCollisionRecs(_rect, entity._rect))
            {
                if (entity.GetType() == "enemy")
                {
                    if (_canGainDamage)
                    {
                        _canGainDamage = false;
                        _health -= 1;
                    }
                }
            }
        }
    }

    public void HasWon(List<Tile> tiles)
    {
        foreach (Tile tile in tiles)
        {
            if (tile.GetType() == "winBlock")
            {
                if (Raylib.CheckCollisionRecs(_rect, tile.GetRect()))
                {
                    tile.SetTrigger(true);
                }
            }
        }
    }

    public int GetHealth()
    {
        return _health;
    }

    public int GetSpeedMultiplier()
    {
        return _speedMultiplier;
    }

    public void ResetHealth()
    {
        _health = _originalHealth;
    }

    public override void BulletCollisions(List<Bullet> bullets)
    {

    }
}