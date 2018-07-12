using System;
using MicrowaveOven.Interfaces;

namespace MicrowaveOven.Units
{
    public class StartButton : IStartButton
    {
        public bool IsStartButtonPressed { get; private set; }

        public void ButtonIsNotPressed()
        {
            IsStartButtonPressed = false;
            Console.WriteLine("Button is not pressed");
        }

        public void ButtonIsPressed()
        {
            IsStartButtonPressed = true;
            Console.WriteLine("Button is pressed");
        }
    }
}