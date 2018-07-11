using Microsoft.VisualStudio.TestTools.UnitTesting;
using MicrowaveOven.Units;
using MicrowaveOven;

namespace MicrowaveOvenTest
{
    [TestClass]
    public class MicrowaveOvenHwTest
    {
        private MicrowaveOvenHw microwaveOvenHw;
        private Driver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new Driver();
            microwaveOvenHw = new MicrowaveOvenHw(driver);
        }

        [TestMethod]
        public void WhenDoorIsOpenedThenLightdIsTurnedOn()
        {
            microwaveOvenHw.OpenDoor(); //czy w property da sie uzywac eventów ? czy to dobry pattern
            Assert.IsTrue(driver.GetLightState());
        }

        [TestMethod]
        public void WhenDoorIsClosedThenLightIsTurnedOff()
        {
            microwaveOvenHw.CloseDoor();
            Assert.IsFalse(driver.GetLightState());
        }

        [TestMethod]
        public void WhenDoorIsOpenedThenHeaterStopsRunning()
        {
            microwaveOvenHw.OpenDoor();
            Assert.IsFalse(driver.GetHeaterState());
        }

        [TestMethod]
        public void WhenButtonIsPressedAndDoorIsOpenTheanHeaterIsNotStarted()
        {
            microwaveOvenHw.OpenDoor();
            microwaveOvenHw.TurnOnHeater();
            Assert.IsFalse(driver.GetHeaterState());
        }

        [TestMethod]
        public void WhenButtonIsPressedAndDoorIsClosedThenHeaterRunsFor1Minute()
        {
            microwaveOvenHw.CloseDoor();
            microwaveOvenHw.TurnOnHeater();
            Assert.IsTrue(driver.GetHeaterState());
        }

        [TestMethod]
        public void WhenButtonIsPressedAndDoorIsClosedAndIsAlreadyHeatingThenHeaterIncreaseHeatingFor1Minute()
        {
            microwaveOvenHw.CloseDoor();
            microwaveOvenHw.TurnOnHeater();
            microwaveOvenHw.TurnOnHeater();

            Assert.IsTrue(driver.GetHeaterState());
            Assert.IsTrue(microwaveOvenHw.GetTimeLeft() > 60 * 1000);
        }
    }
}