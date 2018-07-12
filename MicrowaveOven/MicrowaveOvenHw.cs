using System;
using System.Timers;
using MicrowaveOven.Interfaces;
using MicrowaveOven.StateMachine;
using MicrowaveOven.Units;

namespace MicrowaveOven
{
    public class MicrowaveOvenHw : IMicrowaveOvenHW
    {
        private readonly IDoor door;
        private const int Minute = 60 * 1000;
        private readonly Timer microwaveTimer;

        public MicrowaveOvenHw(IDoor door, ILight light, IHeater heater, IStartButton startButton)
        {
            this.door = door;
            microwaveTimer = new Timer
            {
                Interval = Minute,
                AutoReset = false
            };

            var stateManager = new StateManager(door, light, heater, startButton);
            RegisterStateManagerTriggerChanges(stateManager);

            var driver = new Driver(stateManager);

            DoorOpenChanged += driver.DoorOpenHandler;
            StartButtonPressed += driver.StartButtonPressedHandler;
            microwaveTimer.Elapsed += driver.TimeElapsed;
        }

        public void TurnOnHeater()
        {
            StartButtonPressed(this, EventArgs.Empty);

            microwaveTimer.Interval += Minute;
            microwaveTimer.Start();
        }

        public void TurnOffHeater()
        {
            microwaveTimer.Stop(); 
        }

        public bool DoorOpen => door.IsDoorOpen; 
        public event Action<bool> DoorOpenChanged;
        public event EventHandler StartButtonPressed;

        private static void RegisterStateManagerTriggerChanges(StateManager stateManager)
        {
            var initialCondition = new StateCondition
            {
                IsDoorOpen = false,
                IsLightOn = false,
                IsHeaterOn = false,
                IsButtonPressed = false
            };

            var doorOpenCondition = new StateCondition
            {
                IsDoorOpen = true,
                IsLightOn = false,
                IsHeaterOn = false,
                IsButtonPressed = false
            };
            var buttonIsPressedCondition = new StateCondition
            {
                IsDoorOpen = false,
                IsLightOn = false,
                IsHeaterOn = false,
                IsButtonPressed = true
            };

            var stateChangerToDoorOpen = new StateChangerToDoorOpen();
            var stateChangerToInitial = new StateChangerToInitial();
            var stateChangerToButtonPressed =
                new StateChangerToButtonPressed();

            stateManager.Register(initialCondition, MicrowaveTrigger.Open, stateChangerToDoorOpen);
            stateManager.Register(doorOpenCondition, MicrowaveTrigger.Close, stateChangerToInitial);
            stateManager.Register(initialCondition, MicrowaveTrigger.PressStart,
                stateChangerToButtonPressed);
            stateManager.Register(buttonIsPressedCondition, MicrowaveTrigger.Open, stateChangerToDoorOpen);
            stateManager.Register(buttonIsPressedCondition, MicrowaveTrigger.Elapsed, stateChangerToInitial);
        }

        public void OpenDoor()
        {
            DoorOpenChanged(true);
        }

        public void CloseDoor()
        {
            DoorOpenChanged(false);
        }

        public double GetTimeLeft()
        {
            return microwaveTimer.Interval;
        }
    }
}