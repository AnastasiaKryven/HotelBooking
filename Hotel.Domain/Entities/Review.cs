using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hotel.Domain.Entities
{
    public class Review
    {
        public Review()
        {
            Date = DateTime.Now;
        }
        [Key]
        public int ReviewId { get; set; }

        [MaxLength(100)]
        [Required]
        public string TextOfReview { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }
    }
}
