using System;
using MicrowaveOven.StateMachine;
using MicrowaveOven.Units;

namespace MicrowaveOven
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var light = new Light();
            var heater = new Heater();
            var startButton = new StartButton();
            var door = new Door();
            var timer = new MicrowaveTimer();

            var microwave = new MicrowaveOvenHw(door, light, heater, startButton,timer);

            RunCommandLoop(microwave);
        }

        private static void RunCommandLoop(MicrowaveOvenHw microwave)
        {
            while (true)
            {
                PrintMenu();
                var commandNumer = 0;
                var result = Console.ReadLine();
                if (int.TryParse(result, out commandNumer))
                    switch (commandNumer)
                    {
                        case 1:
                            microwave.OpenDoor();
                            break;
                        case 2:
                            microwave.CloseDoor();
                            break;
                        case 3:
                            microwave.TurnOnHeater();
                            break;
                    }
                else
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1. Open Door");
            Console.WriteLine("2. Close Door");
            Console.WriteLine("3. Press Start Button");
            Console.WriteLine("Press Enter to exit.");
        }
    }
}