namespace Exercise8;

internal class Program
{
    private static void Main(string[] args)
    {
        var p1 = new Point(5, 2);
        var p2 = new Point(-3, 6);
        SwapPoints(p1, p2);
        Console.WriteLine("(" + p1.X + ", " + p1.Y + ")");
        Console.WriteLine("(" + p2.X + ", " + p2.Y + ")");
    }

    private static void SwapPoints(Point p1, Point p2)
    {
        var p1NewX = p2.X;
        var p1NewY = p2.Y;
        var p2NewX = p1.X;
        var p2NewY = p1.Y;
        p1.X = p1NewX;
        p1.Y = p1NewY;
        p2.X = p2NewX;
        p2.Y = p2NewY;
    }
}