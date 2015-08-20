using OneHundredDoors.App;
using NUnit.Framework;
using System.Linq;

namespace OneHundredDoors.Tests
{
    [TestFixture]
    public class DoorsCollectionTest
    {
        [Test]
        public void _InitialState_Has100Doors()
        {
            var doors = new DoorsCollection();

            Assert.That(doors.Count, Is.EqualTo(100));
        }

        [Test]
        public void _InitialState_AllDoorsWithStatusClosed()
        {
            var doors = new DoorsCollection();

            Assert.IsTrue(doors.All(d => d.Status == DoorStatus.Closed));
        }

        [Test]
        public void _InitialState_EachDoorHasASequencialNumberFrom1To100()
        {
            var doors = new DoorsCollection();

            for (int i = 0; i < 100; i++)
            {
                var expectedDoorNumber = i + 1;

                Assert.That(doors.ElementAt(i).Number, Is.EqualTo(expectedDoorNumber));
            }
        }

        [Test]
        public void PassByDoors_OneTime_AllDoorsBecomeWithOpenedStatus()
        {
            // Arrange
            var doors = new DoorsCollection();

            // Act
            doors.PassByDoors(times: 1);

            // Assert
            Assert.IsTrue(doors.All(d => d.Status == DoorStatus.Opened));
        }

        [Test]
        public void PassByDoors_TwoTimes_2ndDoorsBemoceWithClosedStatus()
        {
            // Arrange
            var doors = new DoorsCollection();

            // Act
            doors.PassByDoors(times: 2);
            var secondDoors = doors.Where(d => d.Number % 2 == 0);

            // Assert
            Assert.IsTrue(secondDoors.All(d => d.Status == DoorStatus.Closed));
        }

        [Test]
        public void PassByDoors_TwoTimes_1stDoorsBecomeWithOpenedStatus()
        {
            // Arrange
            var doors = new DoorsCollection();

            // Act
            doors.PassByDoors(times: 2);
            var firstsDoors = doors.Where(d => d.Number % 2 != 0);

            // Assert
            Assert.IsTrue(firstsDoors.All(d => d.Status == DoorStatus.Opened));
        }

        [Test]
        public void PassByDoors_ThreeTimes_DoorNumber3WithClosedStatus()
        {
            // Arrange
            var doors = new DoorsCollection();

            // Act
            doors.PassByDoors(times: 3);

            // Assert
            Assert.That(doors.ElementAt(2).Status, Is.EqualTo(DoorStatus.Closed));
        }

        [TestCase(1, ExpectedResult = "OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO")]
        [TestCase(2, ExpectedResult = "OCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOCOC")]
        [TestCase(3, ExpectedResult = "OCCCOOOCCCOOOCCCOOOCCCOOOCCCOOOCCCOOOCCCOOOCCCOOOCCCOOOCCCOOOCCCOOOCCCOOOCCCOOOCCCOOOCCCOOOCCCOOOCCC")]
        [TestCase(4, ExpectedResult = "OCCOOOOOCCOCOCCOOOOOCCOCOCCOOOOOCCOCOCCOOOOOCCOCOCCOOOOOCCOCOCCOOOOOCCOCOCCOOOOOCCOCOCCOOOOOCCOCOCCO")]
        [TestCase(5, ExpectedResult = "OCCOCOOOCOOCOCOOOOOCCCOCCCCOOCOOCCCCOCCCOOOOOCOCOOCOOOCOCCOOOCCOCOOOCOOCOCOOOOOCCCOCCCCOOCOOCCCCOCCC")]
        [TestCase(6, ExpectedResult = "OCCOCCOOCOOOOCOOOCOCCCOOCCCOOOOOCCCOOCCCOCOOOCOOOOCOOCCOCCOCOCCOCCOOCOOOOCOOOCOCCCOOCCCOOOOOCCCOOCCC")]
        [TestCase(7, ExpectedResult = "OCCOCCCOCOOOOOOOOCOCOCOOCCCCOOOOCCOOOCCCOOOOOCOOCOCOOCCCCCOCOCOOCCOOCCOOOCOOCCOCCCOCCCCOOOCOCCCOOOCC")]
        [TestCase(8, ExpectedResult = "OCCOCCCCCOOOOOOCOCOCOCOCCCCCOOOCCCOOOCCOOOOOOCOCCOCOOCCOCCOCOCOCCCOOCCOCOCOOCCOOCCOCCCCCOOCOCCCCOOCC")]
        [TestCase(9, ExpectedResult = "OCCOCCCCOOOOOOOCOOOCOCOCCCOCOOOCCCOCOCCOOOOOCCOCCOCOOOCOCCOCOCCCCCOOCCOOOCOOCCOOOCOCCCCCOCCOCCCCOOOC")]
        [TestCase(10, ExpectedResult = "OCCOCCCCOCOOOOOCOOOOOCOCCCOCOCOCCCOCOCCCOOOOCCOCCCCOOOCOCCOOOCCCCCOOCOOOOCOOCCOCOCOCCCCCOOCOCCCCOOOO")]
        public string PassByDoors_XTimes_DoorsStatusWillBe(int times)
        {
            // Arrange
            var doors = new DoorsCollection();

            // Act
            doors.PassByDoors(times: times);

            // Assert
            return DoorsCollectionTestHelper.CreateAStringRepresentingTheFirstLetterOfTheStatusOfEachDoor(doors);
        }
    }
}
