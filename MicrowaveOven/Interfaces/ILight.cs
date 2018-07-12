namespace MicrowaveOven.Interfaces {
    public interface ILight {
        bool IsIsLightOn { get;  }
        void TurnOnLight();
        void TurnOffLight();
    }
}