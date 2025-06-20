using System;

class Rectangle : Shape
{
    private double _side;
    private double _length;
    public Rectangle(string color, double side, double length) : base(color)
    {
        _side = side;
        _length = length;
    }

    public override double GetArea()
    {
        return _side * _length;
    }
}