using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCar.Models
{
    public class ContactUs
    {

        public int Id { get; set; }


        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Contact")]
        public string Contact { get; set; }
        

        [Display(Name = "Subject")]
        public string Subject { get; set; }


        [Display(Name = "Message")]
        public string Message { get; set; }

    }
}
