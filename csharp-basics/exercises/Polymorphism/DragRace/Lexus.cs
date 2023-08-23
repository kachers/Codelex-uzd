using System;

namespace DragRace;

public class Lexus : Car, IBoostable
{
    public void UseNitrousOxideEngine()
    {
        CurrentSpeed += 5;
    }

    public override void SpeedUp()
    {
        CurrentSpeed += 5;
    }

    public override void SlowDown()
    {
        CurrentSpeed -= 8;
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