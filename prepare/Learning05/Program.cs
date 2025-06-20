using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("blue", 4);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("greeen", 4, 8);
        shapes.Add(rectangle);

        Circle circle = new Circle("yellow", 2);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The color of the square is {shape.GetColor()} and the area is: {shape.GetArea()}");

        }
    }
}