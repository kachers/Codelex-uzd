using System;

namespace DragRace;

public class Opel : Car, IBoostable
{
    public void UseNitrousOxideEngine()
    {
        CurrentSpeed += 13;
    }

    public override void SpeedUp()
    {
        CurrentSpeed += 4;
    }

    public override void SlowDown()
    {
        CurrentSpeed -= 4;
    }

    public override string ShowCurrentSpeed()
    {
        return CurrentSpeed.ToString();
    }

    public override void StartEngine()
    {
        Console.WriteLine("Wrrrrummmm");
    }
}