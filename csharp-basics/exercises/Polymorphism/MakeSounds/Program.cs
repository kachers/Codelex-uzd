using System;
using System.Collections.Generic;

namespace MakeSounds
{
    class Program
    {
        private static void Main(string[] args)
        {
            Parrot parrot1 = new Parrot("Squawk grr grr Squawk grr grr");
            Radio radio1 = new Radio("ffffsssshhhhh ffffsssshhhhh");
            Firework firework1 = new Firework("whoosh-bang whoosh-bang");
            Parrot parrot2 = new Parrot("Squawk grr grr");
            Radio radio2 = new Radio("ffffsssshhhhh");
            Firework firework2 = new Firework("whoosh-bang");


            List<object> objectList = new()
            {
                parrot1,
                radio1,
                firework1,
                parrot2,
                radio2,
                firework2,
            };

            foreach (var obj in objectList)
            {
                if (obj is ISound playable)
                {
                    playable.PlaySound();
                }
            }
        }
    }
}