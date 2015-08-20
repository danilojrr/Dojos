using OneHundredDoors.App;
using System.Linq;
using System.Text;

namespace OneHundredDoors.Tests
{
    class DoorsCollectionTestHelper
    {
        public static string CreateAStringRepresentingTheFirstLetterOfTheStatusOfEachDoor(DoorsCollection doors)
        {
            var stringBuilder = new StringBuilder();

            doors.ToList().ForEach(d =>
            {
                var statusFirstLetter = d.Status == DoorStatus.Opened ? "O" : "C";
                stringBuilder.Append(statusFirstLetter);
            });

            return stringBuilder.ToString();
        }
    }
}
