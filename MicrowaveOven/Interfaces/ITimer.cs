using System.Timers;

namespace MicrowaveOven.Interfaces
{
    public interface ITimer
    {
        bool IsTimerOn { get; }

        void Start();
        void Stop();

        event ElapsedEventHandler TimeElapsed;
        //and other members you need
    }
}