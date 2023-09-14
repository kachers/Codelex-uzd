using System;

namespace DragRace;

public class Audi : Car
{
    public override void SpeedUp()
    {
        CurrentSpeed += 8;
    }

    public override void SlowDown()
    {
        CurrentSpeed -= 5;
    }

    public override string ShowCurrentSpeed()
    {
        return CurrentSpeed.ToString();
    }

    public override void StartEngine()
    {
        Console.WriteLine("Rrrrrrr.....");
    }
}