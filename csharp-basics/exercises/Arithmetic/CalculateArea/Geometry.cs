using System;

namespace CalculateArea;

public class Geometry
{
    public static double AreaOfCircle(decimal radius)
    {
        if (radius < 0) Console.WriteLine("error - radius must be positive number");
        return Math.PI * (double)radius * 2;
    }

    public static double AreaOfRectangle(decimal length, decimal width)
    {
        if (length < 0 || width < 0) Console.WriteLine("error - length and width must be positive numbers");
        return (double)length * (double)width;
    }

    public static double AreaOfTriangle(decimal ground, decimal height)
    {
        if (ground < 0 || height < 0) Console.WriteLine("error - ground must height positive numbers");
        return (double)ground * (double)height * 0.5;
    }
}