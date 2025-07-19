using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;

public class WinBlock : Tile
{
    public WinBlock(int x, int y, int width, int height, Color color, string type) : base(x, y, width, height, color, type)
    {

    }

    public override void Update(float dt)
    {

    }

    public override void Draw()
    {
        Raylib.DrawRectangleRec(_rect, _color);
    }
}