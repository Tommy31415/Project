using System;
using System.Timers;
using MicrowaveOven.Units;

namespace MicrowaveOven {
    public class Driver
    {
        private Light light;
        private Heater heater;
        private StartButton startButton;
        private Door door;
        private StateManager stateManager;

        public Driver()
        {
            stateManager = new StateManager();
            stateManager.Register(MicrowaveTrigger.Open, light.TurnOnLight);//moze rejestrowac przy uzyciu refleksji ? musialby akceptowac wiele
            stateManager.Register(MicrowaveTrigger.Open, heater.TurnOff);
            stateManager.Register(MicrowaveTrigger.Open, startButton.ButtonIsNotPressed);
            stateManager.Register(MicrowaveTrigger.Open, door.OpenDoor);

            stateManager.Register(MicrowaveTrigger.Close, light.TurnOffLight);
            stateManager.Register(MicrowaveTrigger.Close, heater.TurnOff);
            stateManager.Register(MicrowaveTrigger.Close, startButton.ButtonIsNotPressed);
            stateManager.Register(MicrowaveTrigger.Close, door.OpenDoor);

            stateManager.Register(MicrowaveTrigger.PressStart, light.TurnOnLight);
            stateManager.Register(MicrowaveTrigger.PressStart, heater.TurnOn);
            stateManager.Register(MicrowaveTrigger.PressStart, startButton.ButtonIsPressed);
            stateManager.Register(MicrowaveTrigger.PressStart, door.CloseDoor);

            stateManager.Register(MicrowaveTrigger.Elapsed, light.TurnOffLight);
            stateManager.Register(MicrowaveTrigger.Elapsed, heater.TurnOff);
            stateManager.Register(MicrowaveTrigger.Elapsed, startButton.ButtonIsNotPressed);
            stateManager.Register(MicrowaveTrigger.Elapsed, door.CloseDoor);
        }

        public  void DoorOpenHandler(bool isDoorOpen)
        {
            if(isDoorOpen)
                stateManager.ExecuteAction(MicrowaveTrigger.Open);
            else
                stateManager.ExecuteAction(MicrowaveTrigger.Close);
        }

        public void StartButtonPressedHandler(object sender, EventArgs e)
        {
            stateManager.ExecuteAction(MicrowaveTrigger.PressStart);
        }

        public void TimeElapsed(object sender, ElapsedEventArgs e)
        {
            stateManager.ExecuteAction(MicrowaveTrigger.Elapsed);
        }

        public bool GetLightState()
        {
            return light.IsIsLightOn;
        }

        public bool GetHeaterState()
        {
            throw new NotImplementedException();
        }
    }
}
