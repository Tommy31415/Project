namespace MicrowaveOven.Interfaces {
    public interface IDoor {
        bool IsDoorOpen { get;  }
        void OpenDoor();
        void CloseDoor();
    }
}