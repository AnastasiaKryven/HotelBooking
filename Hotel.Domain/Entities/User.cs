using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;


namespace Hotel.Domain.Entities
{
    public class User : IUser<int>
    {
        public User()
        {
            Roles = new List<Role>();

            Bookings = new List<Booking>();

            Checks = new List<Check>();

            Requests = new List<Request>();

            UserName = Email;
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public IList<Role> Roles { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public ICollection<Check> Checks { get; set; }

        public ICollection<Request> Requests { get; set; }
        
    }
}
