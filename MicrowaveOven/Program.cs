using System;

namespace MicrowaveOven
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, your microwave is speaking.");
            Console.WriteLine("What can I do for you ?");

            var microwave = new MicrowaveOvenHw(new Driver());

            RunCommandLoop(microwave);
        }

        private static void RunCommandLoop(MicrowaveOvenHw microwave)
        {
            while (true)
            {
                PrintMenu();
                int commandNumer = 0;
                var result = Console.ReadLine();
                if (Int32.TryParse(result, out commandNumer))
                {
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
                }
                else
                {
                    break;
                }
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
