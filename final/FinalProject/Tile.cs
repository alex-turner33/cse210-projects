using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;
public abstract class Tile
{
    protected int _x;
    protected int _y;
    protected int _width;
    protected int _height;
    protected Color _color;
    public Tile(int x, int y, int width, int height, Color color)
    {
        _x = x;
        _y = y;
        _width = width;
        _height = height;
        _color = color;
    }

    public abstract void Update(float dt);

    public abstract void Draw(float dt);
}