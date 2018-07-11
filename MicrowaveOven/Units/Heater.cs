using System;

namespace MicrowaveOven.Units
{
    public class Heater
    {
        public bool IsHeating { get; private set; }

        public void TurnOff()
        {
            IsHeating = false;
            Console.WriteLine("Heater is off");
        }

        public void TurnOn()
        {
            IsHeating = true;
            Console.WriteLine("Heater is on");
        }
    }
}