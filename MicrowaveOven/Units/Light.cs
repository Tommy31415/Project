using System;
using MicrowaveOven.Interfaces;

namespace MicrowaveOven.Units
{
    public class Light : ILight
    {
        public bool IsIsLightOn { get; private set; }

        public void TurnOnLight()
        {
            IsIsLightOn = true;
            Console.WriteLine("Light is on");
        }

        public void TurnOffLight()
        {
            IsIsLightOn = false;
            Console.WriteLine("Light is off");
        }
    }
}