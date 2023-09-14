using System;
using System.Collections.Generic;
using System.Text;

namespace MakeSounds
{
    internal class Radio:ISound
    {
        public string Sound;
        public Radio(string sound)
        {
            Sound = sound;
        }
        public void PlaySound()
        {
            Console.WriteLine(Sound);
        }
    }
}
