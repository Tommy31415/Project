using Microsoft.VisualStudio.TestTools.UnitTesting;
using MicrowaveOven;
using MicrowaveOven.Interfaces;
using MicrowaveOven.StateMachine;
using MicrowaveOven.Units;
using Moq;

namespace MicrowaveOvenTest
{
    [TestClass]
    public class MicrowaveOvenHwTest
    {
        private MicrowaveOvenHw microwaveOvenHw;
        private Mock<IDoor> doorMock;
        private Mock<ILight> lightMock;
        private Mock<IHeater> heaterMock;
        private Mock<IStartButton> startButtonMock;
        private Mock<ITimer> timerMock;


        [TestInitialize]
        public void Setup()
        {
            doorMock = new Mock<IDoor>();
            doorMock.SetupGet(m => m.IsDoorOpen).Returns(false);

            lightMock = new Mock<ILight>();
            lightMock.SetupGet(m => m.IsIsLightOn).Returns(false);

            heaterMock = new Mock<IHeater>();
            heaterMock.SetupGet(m => m.IsHeaterOn).Returns(false);

            startButtonMock = new Mock<IStartButton>();
            startButtonMock.SetupGet(m => m.IsStartButtonPressed).Returns(false);

            timerMock = new Mock<ITimer>();

            microwaveOvenHw = new MicrowaveOvenHw(doorMock.Object, lightMock.Object, heaterMock.Object, startButtonMock.Object,timerMock.Object);
        }

        [TestMethod]
        public void WhenDoorIsOpenedThenLightdIsTurnedOn()
        {
            microwaveOvenHw.OpenDoor(); 
            lightMock.Verify( m => m.TurnOnLight(),Times.Once);
        }

        [TestMethod]
        public void WhenDoorIsClosedThenLightIsTurnedOff()
        {
            doorMock.SetupGet(m => m.IsDoorOpen).Returns(true);
            lightMock.SetupGet(m => m.IsIsLightOn).Returns(true);
            microwaveOvenHw.CloseDoor();
            lightMock.Verify(m => m.TurnOffLight(), Times.Once);
        }

        [TestMethod]
        public void WhenDoorIsOpenedThenHeaterStopsRunning()
        {
            microwaveOvenHw.OpenDoor();
            heaterMock.Verify(m=>m.TurnOff(),Times.Once);
        }

        [TestMethod]
        public void WhenButtonIsPressedAndDoorIsOpenTheanHeaterIsNotStarted()
        {
            doorMock.SetupGet(m => m.IsDoorOpen).Returns(true);
            microwaveOvenHw.TurnOnHeater();
            heaterMock.Verify(m => m.TurnOn(), Times.Never);
        }

        [TestMethod]
        public void WhenButtonIsPressedAndDoorIsClosedThenHeaterRunsFor1Minute()
        {
            microwaveOvenHw.TurnOnHeater();
            heaterMock.Verify(m => m.TurnOn(), Times.Once);
        }

        [TestMethod]
        public void WhenButtonIsPressedAndDoorIsClosedAndIsAlreadyHeatingThenHeaterIncreaseHeatingFor1Minute()
        {
            microwaveOvenHw.TurnOnHeater();
            microwaveOvenHw.TurnOnHeater();

            timerMock.Verify(m => m.Start(),Times.Exactly(2));
        }
    }
}