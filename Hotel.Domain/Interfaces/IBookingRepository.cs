using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> Bookings { get; }

        Booking GetBookingById(int? id);

        void Create(Booking booking);

        void Edit(Booking booking);

        void Delete(int? id);
    }
}
