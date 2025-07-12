public abstract class Weapon
{
    protected int _x;
    protected int _y;
    protected int _width;
    protected int _height;
    protected int _damage;
    protected int _hp;
    public Weapon(int x, int y, int width, int height, int damage, int hp)
    {
        _x = x;
        _y = y;
        _width = width;
        _height = height;
        _damage = damage;
        _hp = hp;
    }

    public abstract void Update(float dt);

    public abstract void Draw();

    public abstract void Move(float dt);

    public abstract void Destroy();
}