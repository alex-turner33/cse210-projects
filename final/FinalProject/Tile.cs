using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;
public abstract class Tile
{
    protected RayRectangle _rect;
    protected Color _color;
    protected string _type;

    protected bool _isTriggered = false;
    public Tile(int x, int y, int width, int height, Color color, string type)
    {
        _rect = new RayRectangle(x, y, width, height);
        _color = color;
        _type = type;
    }

    public abstract void Update(float dt);

    public abstract void Draw();

    public RayRectangle GetRect()
    {
        return _rect;
    }

    public string GetType()
    {
        return _type;
    }

    public void SetTrigger(bool hasIt)
    {
        _isTriggered = hasIt;
    }

    public bool GetTrigger()
    {
        return _isTriggered;
    }
}