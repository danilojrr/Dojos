using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OneHundredDoors.App
{
    public class DoorsCollection : IEnumerable<Door>
    {
        private readonly List<Door> _doors;

        public DoorsCollection()
        {
            _doors = new List<Door>();
            _doors.AddRange(Create100Doors());            
        }

        private IEnumerable<Door> Create100Doors()
        {
            for (int i = 0; i < 100; i++)
            {
                yield return new Door(number: i + 1);
            }
        }

        public void PassByDoors(int times)
        {
            for (int i = 1; i <= times; i++)
            {
                var doors = _doors.Where(d => d.Number % i == 0);
                doors.ToList().ForEach(d => d.Toggle());                
            }
        }

        public IEnumerator<Door> GetEnumerator()
        {
            return _doors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _doors.GetEnumerator();
        }
    }
}
