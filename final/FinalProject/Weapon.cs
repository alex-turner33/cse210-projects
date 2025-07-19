using System;
using System.Numerics;
using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;
public abstract class Weapon
{
    protected RayRectangle _rect;

    protected bool _isFacingRight = true;
    protected int _damage;
    public Weapon(float x, float y, int width, int height, int damage)
    {
        _rect = new RayRectangle(x, y, width, height);
        _damage = damage;
    }

    public RayRectangle GetRect()
    {
        return _rect;
    }

    public abstract void Update(float dt);

    public abstract void Move(float dt);
}