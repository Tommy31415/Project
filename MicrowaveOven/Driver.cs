using System;
using System.Timers;
using MicrowaveOven.StateMachine;

namespace MicrowaveOven
{
    public class Driver
    {
        private readonly StateManager stateManager;

        public Driver(StateManager stateManager)
        {
            this.stateManager = stateManager;
        }

        public void DoorOpenHandler(bool isDoorOpen)
        {
            stateManager.ChangeState(isDoorOpen ? MicrowaveTrigger.Open : MicrowaveTrigger.Close);
        }

        public void StartButtonPressedHandler(object sender, EventArgs e)
        {
            stateManager.ChangeState(MicrowaveTrigger.PressStart);
        }

        public void TimeElapsed(object sender, ElapsedEventArgs e)
        {
            stateManager.ChangeState(MicrowaveTrigger.Elapsed);
        }
    }
}