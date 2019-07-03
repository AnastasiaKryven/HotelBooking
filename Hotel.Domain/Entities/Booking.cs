using Hotel.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hotel.Domain.Entities
{
    public class Booking
    {
        public Booking()
        {
            Rooms = new List<Room>();

            Users = new List<User>();
        }

        [Key]
        [HiddenInput(DisplayValue = false)]
        public int BookingId { get; set; }

        [Required]
        //[ValidateDateRange]
        public DateTime DateEntry { get; set; }

        [Required]
        //[ValidateDateRange]
        public DateTime DateExit { get; set; }

        public int? RoomId { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public ICollection<User> Users { get; set; }
    }

    
}
