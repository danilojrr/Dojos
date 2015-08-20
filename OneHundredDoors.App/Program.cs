using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneHundredDoors.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var doors = new DoorsCollection();
            doors.PassByDoors(times: 100);

            var firstLetterDoorStatues = doors.Select(d => d.Status.ToString().First()).ToList();

            firstLetterDoorStatues.ForEach(s => Console.Write(s));
            Console.ReadKey();
        }
    }
}
