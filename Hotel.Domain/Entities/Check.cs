using System;
using System.Collections.Generic;

namespace Hotel.Domain.Entities
{
    public class Check
    {
        public Check()
        {
            Rooms = new List<Room>();

            Date = DateTime.Now;
        }

        public int CheckId { get; set; }   
        
        public DateTime Date { get; set; }

        public bool IsPaid { get; set; }

        public int? UserId { get; set; }

        public int? IdRoom { get; set; }

        public int Price { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
