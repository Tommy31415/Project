using System;

namespace MicrowaveOven.StateMachine
{
    public class StateCondition
    {
        public bool IsDoorOpen { get; set; }
        public bool IsLightOn { get; set; }
        public bool IsHeaterOn { get; set; }
        public bool IsButtonPressed { get; set; }
        public bool IsTimerOn { get; set; }

        protected bool Equals(StateCondition other)
        {
            return IsDoorOpen == other.IsDoorOpen && IsLightOn == other.IsLightOn && IsHeaterOn == other.IsHeaterOn &&
                   IsButtonPressed == other.IsButtonPressed && IsTimerOn == other.IsTimerOn;
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(null, obj)) return false;
            if (Object.ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((StateCondition) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = IsDoorOpen.GetHashCode();
                hashCode = (hashCode * 397) ^ IsLightOn.GetHashCode();
                hashCode = (hashCode * 397) ^ IsHeaterOn.GetHashCode();
                hashCode = (hashCode * 397) ^ IsButtonPressed.GetHashCode();
                hashCode = (hashCode * 397) ^ IsTimerOn.GetHashCode();
                return hashCode;
            }
        }
    }
}