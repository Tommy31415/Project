using MicrowaveOven.Interfaces;
using MicrowaveOven.Units;

namespace MicrowaveOven.StateMachine
{
    public class StateChangerToInitial : IStateChanger
    {
        public void ChangeState(IDoor door, ILight light, IHeater heater, IStartButton startButton, ITimer timer)
        {
            door.CloseDoor();
            light.TurnOffLight();
            heater.TurnOff();
            startButton.ButtonIsNotPressed();
            timer.Stop();
        }
    }
}