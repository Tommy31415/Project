namespace MicrowaveOven.Interfaces {
    public interface IHeater {
        bool IsHeaterOn { get;  }
        void TurnOff();
        void TurnOn();
    }
}