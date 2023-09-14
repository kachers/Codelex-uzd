using System;

namespace MakeSounds
{
    public class Firework: ISound
    {
        public string Sound;
        public Firework(string sound)
        {
            Sound = sound;
        }
        public void PlaySound()
        {
            Console.WriteLine(Sound);
        }
    }
}