using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.WebUI.Models
{
    public class BookingViewModel
    {
        public IEnumerable<Booking> Bookings { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}