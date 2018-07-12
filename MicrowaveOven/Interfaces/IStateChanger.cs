using MicrowaveOven.Units;

namespace MicrowaveOven.Interfaces
{
    public interface IStateChanger
    {
        void ChangeState(IDoor door, ILight light, IHeater heater, IStartButton startButton);
    }
}