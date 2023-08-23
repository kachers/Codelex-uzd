using System;

namespace DragRace;

public class Tesla : Car
{
    public override void SpeedUp()
    {
        CurrentSpeed += 10;
    }

    public override void SlowDown()
    {
        CurrentSpeed -= 15;
    }

    public override string ShowCurrentSpeed()
    {
        return CurrentSpeed.ToString();
    }

    public override void StartEngine()
    {
        Console.WriteLine("-- silence ---");
    }
}