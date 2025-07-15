using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;
public abstract class Tile
{
    public RayRectangle _rect;
    protected Color _color;
    public Tile(int x, int y, int width, int height, Color color)
    {
        _rect = new RayRectangle(x, y, width, height);
        _color = color;
    }

    public abstract void Update(float dt);

    public abstract void Draw();

    public RayRectangle GetRect()
    {
        return _rect;
    }
}