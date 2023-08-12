namespace Exercise8;

internal class Point
{
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int x { get; set; }
    public int y { get; set; }

    public int Getx()
    {
        return x;
    }

    public int Gety()
    {
        return y;
    }

    public void Setx(int x)
    {
        this.x = x;
    }

    public void Sety(int y)
    {
        this.y = y;
    }
}