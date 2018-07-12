using System;
using MicrowaveOven.Interfaces;

namespace MicrowaveOven.StateMachine
{
    public class MicrowaveOvenHw : IMicrowaveOvenHW
    {
        private readonly IDoor door;

        public MicrowaveOvenHw(IDoor door, ILight light, IHeater heater, IStartButton startButton, ITimer timer)
        {
            this.door = door;

            var stateManager = new StateManager(door, light, heater, startButton,timer);
            RegisterStateManagerTriggerChanges(stateManager);

            var driver = new Driver(stateManager);

            DoorOpenChanged += driver.DoorOpenHandler;
            StartButtonPressed += driver.StartButtonPressedHandler;
        }

        public void TurnOnHeater()
        {
            StartButtonPressed(this, EventArgs.Empty);
        }

        public void TurnOffHeater()
        {
            DoorOpenChanged(false);
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
                IsButtonPressed = false,
                IsTimerOn = false
            };

            var doorOpenCondition = new StateCondition
            {
                IsDoorOpen = true,
                IsLightOn = true,
                IsHeaterOn = false,
                IsButtonPressed = false,
                IsTimerOn = false,
            };
            var buttonIsPressedCondition = new StateCondition
            {
                IsDoorOpen = false,
                IsLightOn = true,
                IsHeaterOn = true,
                IsButtonPressed = true,
                IsTimerOn = true
            };

            var stateChangerToDoorOpen = new StateChangerToDoorOpen();
            var stateChangerToInitial = new StateChangerToInitial();
            var stateChangerToButtonPressed =
                new StateChangerToButtonPressed();

            stateManager.Register(initialCondition, MicrowaveTrigger.Open, stateChangerToDoorOpen);
            stateManager.Register(doorOpenCondition, MicrowaveTrigger.Close, stateChangerToInitial);
            stateManager.Register(initialCondition, MicrowaveTrigger.PressStart,
                stateChangerToButtonPressed);
            stateManager.Register(buttonIsPressedCondition, MicrowaveTrigger.PressStart,
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
    }
}