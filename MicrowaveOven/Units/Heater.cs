using System;
using MicrowaveOven.Interfaces;

namespace MicrowaveOven.Units
{
    public class Heater : IHeater
    {
        public bool IsHeaterOn { get; private set; }

        public void TurnOff()
        {
            IsHeaterOn = false;
            Console.WriteLine("Heater is off");
        }

        public void TurnOn()
        {
            IsHeaterOn = true;
            Console.WriteLine("Heater is on");
        }
    }
}