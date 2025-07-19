using System;
using System.Numerics;
using Raylib_cs;
public class Menu
{
    private string _button1Text;
    private string _button2Text;
    private string _headerText;

    private int _screenWidth;
    private int _screenHeight;

    private bool _button1Pressed = false;
    private bool _button2Pressed = false;

    public Menu(string button1Text, string button2Text, string headerText, int screenWidth, int screenHeight)
    {
        _button1Text = button1Text;
        _button2Text = button2Text;
        _headerText = headerText;
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;
    }

    public void Draw()
    {
        int buttonWidth = 200;
        int buttonHeight = 50;

        int buttonX = Raylib.GetScreenWidth() / 2 - buttonWidth / 2;
        int button1Y = Raylib.GetScreenHeight() / 2 - buttonHeight - 10;
        int button2Y = button1Y + buttonHeight + 20;

        Rectangle button1 = new Rectangle(buttonX, button1Y, buttonWidth, buttonHeight);
        Rectangle button2 = new Rectangle(buttonX, button2Y, buttonWidth, buttonHeight);

        Raylib.DrawRectangleRec(button1, Color.Green);
        Raylib.DrawText(_button1Text, buttonX + 60, button1Y + 10, 30, Color.Black);

        Raylib.DrawRectangleRec(button2, Color.Red);
        Raylib.DrawText(_button2Text, buttonX + 70, button2Y + 10, 30, Color.Black);

        Raylib.DrawText(_headerText, _screenWidth / 2 - _headerText.Count() * 12, 70, 50, Color.White);

        if (Raylib.IsMouseButtonPressed(0))
        {
            Vector2 mouse = Raylib.GetMousePosition();
            if (Raylib.CheckCollisionPointRec(mouse, button1))
            {
                _button1Pressed = true;
            }
            else if (Raylib.CheckCollisionPointRec(mouse, button2))
            {
                _button2Pressed = true;
            }
        }
    }

    public bool Button1Pressed()
    {
        return _button1Pressed;
    }

    public bool Button2Pressed()
    {
        return _button2Pressed;
    }

    public void ClearPressed()
    {
        _button1Pressed = false;
        _button2Pressed = false;
    }
}