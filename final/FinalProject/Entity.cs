using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;

public abstract class Entity
{
    protected RayRectangle _rect;
    protected Color _color;
    protected float _xVel;
    protected float _gravity = 9.8f;
    protected int _health;
    protected int _screenWidth;
    protected int _screenHeight;
    protected bool _grounded = false;

    public Entity(int x, int y, int width, int height, Color color, float xVel, int health, int screenWidth, int screenHeight)
    {
        _rect = new RayRectangle(x, y, width, height);
        _color = color;
        _xVel = xVel;
        _health = health;
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;
    }

    public abstract void Update(float dt);

    public abstract void Draw();

    public abstract void Move(float dt);

    public abstract void Collision();
}