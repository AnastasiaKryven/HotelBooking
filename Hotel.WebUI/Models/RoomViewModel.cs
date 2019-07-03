using Hotel.Domain.Entities;
using Hotel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WebUI.Models
{
    public class RoomViewModel
    {
        public IEnumerable<Room> Rooms { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}