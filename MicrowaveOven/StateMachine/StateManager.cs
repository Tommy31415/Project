using System;
using System.Collections.Generic;
using MicrowaveOven.Interfaces;
using MicrowaveOven.Units;

namespace MicrowaveOven.StateMachine
{
    public class StateManager : Dictionary<StateKey, IStateChanger>
    {
        private readonly IDoor door;
        private readonly IHeater heater;
        private readonly ILight light;
        private readonly IStartButton startButton;

        public StateManager(IDoor door, ILight light, IHeater heater, IStartButton startButton)
        {
            this.door = door;
            this.light = light;
            this.heater = heater;
            this.startButton = startButton;
        }

        private StateCondition GetCurrentState()
        {
            return new StateCondition
            {
                IsDoorOpen = door.IsDoorOpen,
                IsLightOn = light.IsIsLightOn,
                IsHeaterOn = heater.IsHeaterOn,
                IsButtonPressed = startButton.IsStartButtonPressed
            };
        }

        public void Register(StateCondition stateCondition, MicrowaveTrigger trigger, IStateChanger stateChanger)
        {
            var key = new StateKey
            {
                InitialStateCondition = stateCondition,
                Trigger = trigger
            };

            Add(key, stateChanger);
        }

        public void ChangeState(MicrowaveTrigger trigger)
        {
            var key = new StateKey
            {
                InitialStateCondition = GetCurrentState(),
                Trigger = trigger
            };

            if (TryGetValue(key, out var stateChanger))
                stateChanger.ChangeState(door, light, heater, startButton);
        }
    }

    public class StateKey
    {
        public StateCondition InitialStateCondition { get; set; }
        public MicrowaveTrigger Trigger { get; set; }

        protected bool Equals(StateKey other)
        {
            return Object.Equals(InitialStateCondition, other.InitialStateCondition) && Trigger == other.Trigger;
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(null, obj)) return false;
            if (Object.ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((StateKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((InitialStateCondition != null ? InitialStateCondition.GetHashCode() : 0) * 397) ^
                       (int) Trigger;
            }
        }
    }
}