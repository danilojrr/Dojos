using System;

namespace OneHundredDoors.App
{
    public class Door
    {
        public DoorStatus Status { get; set; }
        public int Number { get; set; }

        public Door(int? number)
        {
            if (!number.HasValue) { throw new ArgumentNullException(); }

            Number = number.Value;
            Status = DoorStatus.Closed;
        }

        internal void Toggle()
        {
            if (Status == DoorStatus.Opened)
            {
                Status = DoorStatus.Closed;
            }
            else
            {
                Status = DoorStatus.Opened;
            }
        }
    }
}