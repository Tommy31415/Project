using System;
using MicrowaveOven.Interfaces;

namespace MicrowaveOven.Units
{
    public class Door : IDoor
    {
        public bool IsDoorOpen { get; private set; }

        public void OpenDoor()
        {
            IsDoorOpen = true;
            Console.WriteLine("Door is open");
        }

        public void CloseDoor()
        {
            IsDoorOpen = false;

            Console.WriteLine("Door is closed");
        }
    }
}