using System;
using System.Timers;
using MicrowaveOven.Interfaces;

namespace MicrowaveOven.Units
{
    public class MicrowaveTimer : ITimer
    {
        private const int Minute = 60 * 1000;
        private readonly Timer timer;

        public MicrowaveTimer()
        {
            timer = new Timer
            {
                Interval =  Minute,
                AutoReset = false
            };
            timer.Elapsed += TimerElapsedHandler;
        }

        private void TimerElapsedHandler(object sender, ElapsedEventArgs e)
        {
            TimeElapsed?.Invoke(this,null);
        }

        public bool IsTimerOn => timer.Enabled;

        public void Start()
        {
            Console.WriteLine("Timer started.");
            if (IsTimerOn)
                timer.Interval += Minute;
            else
                timer.Start();
        }

        public void Stop()
        {
            Console.WriteLine("Timer stoped");
            timer.Stop();
        }

        public event ElapsedEventHandler TimeElapsed;
    }
}

