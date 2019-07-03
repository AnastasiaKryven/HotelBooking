using Hotel.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hotel.Domain.Entities
{
    public class Room
    {
        public Room()
        {
            RoomClass = Class.A;
            RoomState = State.Free;
        }

        [Key]
        public int RoomId { get; set; }

        [Range(30,1000)]
        [Required(ErrorMessage = "Please, input the Price")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Please, input the CountOfPeople")]
        [Range(1,6)]
        public int CountOfPeople { get; set; }

        [EnumDataType(typeof(Class))]
        [Range(1, 5)]
        [Required(ErrorMessage = "Please, input the RoomClass")]
        public Class RoomClass { get; set; }

        [EnumDataType(typeof(State))]
        [Range(1, 5)]
        [Required(ErrorMessage = "Please, input the RoomState")]
        public State RoomState { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        //public DateTime DateStart { get; set; }

        //public DateTime DateEnd { get; set; }
  
    }

}
