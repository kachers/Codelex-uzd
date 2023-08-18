using System;
using System.Collections.Generic;
using System.Text;

namespace MakeSounds
{
    internal class Parrot:ISound
    {
        public string Sound;
        public Parrot(string sound)
        {
            Sound = sound;
        }
        public void PlaySound()
        {
            Console.WriteLine(Sound);
        }
    }
}
