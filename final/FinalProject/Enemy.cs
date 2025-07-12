using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;

public abstract class Enemy : Entity
{
    public Enemy(int x, int y, int width, int height, Color color, float xVel, float jumpSpeed, int health, int screenWidth, int screenHeight) : base(x, y, width, height, color, xVel, health, screenWidth, screenHeight)
    {

    }

    public override void Update(float dt)
    {

    }

    public override void Draw()
    {

    }

    public override void Move(float dt)
    {

    }

    public override void Collision()
    {

    }
}