using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Room room, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Room.RoomId == room.RoomId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Room = room,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

       

        public void RemoveLine(Room room)
        {
            lineCollection.RemoveAll(l => l.Room.RoomId == room.RoomId);
        }

        public decimal ComputeTotalValue()
        {
            
            return lineCollection.Sum(e => (decimal)e.Room.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public int CartLineId { get; set; }
        public Room Room{ get; set; }
        public int Quantity { get; set; }
    }




}

