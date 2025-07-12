public class Bullet : Weapon
{
    private int _Speed;

    public Bullet(int x, int y, int width, int height, int damage, int hp, int speed) : base(x, y, width, height, damage, hp)
    {
        _Speed = speed;
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

    public override void Destroy()
    {

    }
}