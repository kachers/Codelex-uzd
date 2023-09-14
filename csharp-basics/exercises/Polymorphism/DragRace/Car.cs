namespace DragRace;

public abstract class Car
{
    public int CurrentSpeed;

    public Car()
    {
        CurrentSpeed = 0;
    }

    public abstract void SpeedUp();
    public abstract void SlowDown();
    public abstract void StartEngine();
    public abstract string ShowCurrentSpeed();
}