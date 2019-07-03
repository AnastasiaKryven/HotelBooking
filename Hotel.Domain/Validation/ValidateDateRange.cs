using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Validation
{
    public class ValidateDateRange : ValidationAttribute
    {
        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = Convert.ToDateTime(value);

            if (date >= FirstDate && date <= SecondDate || date < DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else

                return new ValidationResult("Date is not in given range.");
        }

    }
}
