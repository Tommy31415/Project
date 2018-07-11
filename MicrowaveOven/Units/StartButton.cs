using System;

namespace MicrowaveOven.Units {
    public class StartButton {
        private bool isStartButtonPressedState;

        public bool IsStartButtonPressedState => isStartButtonPressedState;
       
        public void ButtonIsNotPressed()
        {
            isStartButtonPressedState = false;
            Console.WriteLine("Button is not pressed");
        }

        public void ButtonIsPressed()
        {
            isStartButtonPressedState = true;
            Console.WriteLine("Button is pressed");
        }
    }
}