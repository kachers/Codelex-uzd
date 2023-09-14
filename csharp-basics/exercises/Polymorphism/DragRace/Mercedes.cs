using System;

namespace DragRace;

public class Mercedes : Car
{
    public override void SpeedUp()
    {
        CurrentSpeed += 19;
    }

    public override void SlowDown()
    {
        CurrentSpeed -= 10;
    }

    public override string ShowCurrentSpeed()
    {
        return CurrentSpeed.ToString();
    }

    public override void StartEngine()
    {
        Console.WriteLine("brum brum");
    }
}