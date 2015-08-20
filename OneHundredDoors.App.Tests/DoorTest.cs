using OneHundredDoors.App;
using NUnit.Framework;
using System;

namespace OneHundredDoors.Tests
{
    [TestFixture]
    public class DoorTest
    {
        [Test]
        public void Status_InitialState_Closed()
        {
            var door = new Door(number: 1);

            Assert.That(door.Status, Is.EqualTo(DoorStatus.Closed));
        }

        [Test]
        public void Constructor_ParameterNumberIsNull_ThrowsException()
        {
            Assert.That(() => new Door(number: null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
