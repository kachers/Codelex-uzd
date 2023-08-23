using System;

namespace DragRace;

public class Bmw : Car
{
    public override void SpeedUp()
    {
        CurrentSpeed += 9;
    }

    public override void SlowDown()
    {
        CurrentSpeed -= 9;
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