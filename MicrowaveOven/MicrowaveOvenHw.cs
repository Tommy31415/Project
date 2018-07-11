using System;
using System.Timers;
using MicrowaveOven.Interfaces;

namespace MicrowaveOven {
    public class MicrowaveOvenHw : IMicrowaveOvenHW
    {
        private Driver driver;
        private Timer microwaveTimer;


        public MicrowaveOvenHw(Driver driver)
        {
            this.driver = driver;
            DoorOpenChanged += driver.DoorOpenHandler;
            StartButtonPressed += driver.StartButtonPressedHandler;
            microwaveTimer.Elapsed += driver.TimeElapsed;

            microwaveTimer = new Timer
            {
                Interval = 60 * 1000, //to tutaj jakims constem
                AutoReset = false
            };
        }

        public void TurnOnHeater()
        {
            StartButtonPressed(this,EventArgs.Empty);

            //i oczywiscie czas zwiekszyc
            //musialbym uzyc callbacku 
            //ale to najmniejszy problem
        }

        public void TurnOffHeater()
        {
           microwaveTimer.Stop();//czy to wywoła Elapsed ?
            //albo wyzerowac zegar
        }

        public void OpenDoor()
        {
            DoorOpenChanged(true);
        }

        public void CloseDoor()
        {
            DoorOpenChanged(false);
        }

        public bool DoorOpen { get; }
        public event Action<bool> DoorOpenChanged;
        public event EventHandler StartButtonPressed;

        public int GetTimeLeft()
        {
            throw new NotImplementedException();
        }
    }
}