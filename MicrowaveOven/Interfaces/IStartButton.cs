namespace MicrowaveOven.Interfaces {
    public interface IStartButton {
        bool IsStartButtonPressed { get;  }
        void ButtonIsNotPressed();
        void ButtonIsPressed();
    }
}