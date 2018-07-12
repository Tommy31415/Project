using MicrowaveOven.Interfaces;
using MicrowaveOven.Units;

namespace MicrowaveOven.StateMachine
{
    public class StateChangerToButtonPressed : IStateChanger
    {
        public void ChangeState(IDoor door, ILight light, IHeater heater, IStartButton startButton,ITimer timer)
        {
            door.CloseDoor();
            light.TurnOnLight();
            heater.TurnOn();
            startButton.ButtonIsPressed();
            timer.Start();
        }
    }
}