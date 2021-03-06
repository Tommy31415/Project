using MicrowaveOven.Interfaces;
using MicrowaveOven.Units;

namespace MicrowaveOven.StateMachine
{
    internal class StateChangerToDoorOpen : IStateChanger
    {
        public void ChangeState(IDoor door, ILight light, IHeater heater, IStartButton startButton, ITimer timer)
        {
            door.OpenDoor();
            light.TurnOnLight();
            heater.TurnOff();
            startButton.ButtonIsNotPressed();
            timer.Stop();
        }
    }
}