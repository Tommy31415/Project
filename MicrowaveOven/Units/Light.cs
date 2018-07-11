using System;

namespace MicrowaveOven.Units {
    public class Light
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