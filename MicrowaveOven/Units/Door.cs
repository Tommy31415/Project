using System;

namespace MicrowaveOven.Units
{
    public class Door
    {
        public bool IsDoorOpen { get; private set; }

        public void OpenDoor()
        {
            IsDoorOpen = true;
            Console.WriteLine("Door is open");
        }

        public void CloseDoor()
        {
            Console.WriteLine("Door is closed");
        }
    }
}