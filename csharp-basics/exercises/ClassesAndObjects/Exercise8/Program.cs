namespace Exercise8;

internal class Program
{
    private static void Main(string[] args)
    {
        var p1 = new Point(5, 2);
        var p2 = new Point(-3, 6);
        SwapPoints(p1, p2);
        Console.WriteLine("(" + p1.x + ", " + p1.y + ")");
        Console.WriteLine("(" + p2.x + ", " + p2.y + ")");
    }

    private static void SwapPoints(Point p1, Point p2)
    {
        var p1NewX = p2.Getx();
        var p1NewY = p2.Gety();
        var p2NewX = p1.Getx();
        var p2NewY = p1.Gety();
        p1.Setx(p1NewX);
        p1.Sety(p1NewY);
        p2.Setx(p2NewX);
        p2.Sety(p2NewY);
    }
}