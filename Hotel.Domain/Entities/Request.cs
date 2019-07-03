using Hotel.Domain.Enums;
using Hotel.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hotel.Domain.Entities
{
    public class Request
    {
        public Request()
        {
            Rooms = new List<Room>();

            Users = new List<User>();
        }

        [HiddenInput(DisplayValue = false)]
        public int RequestId { get; set; }

        [Required]
        //[ValidateDateRange]
        public DateTime DateEntry { get; set; }

        [Required]
        //[ValidateDateRange]
        public DateTime DateExit { get; set; }
      
        [Required]
        public int CountOfPlace { get; set; }

        public int? RoomId { get; set; }
        public ICollection<Room> Rooms { get; set; }

        public int? UserId { get; set; }    
    public ICollection<User> Users { get; set; }
    }
}
