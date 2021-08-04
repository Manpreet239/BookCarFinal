using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCar.Models
{
    public class CarBook
    {
        public int Id { get; set; }

        [Display(Name = "Car Name")]
        public string CarName { get; set; }

        [Display(Name = "CarModel")]
        public string CarModel { get; set; }

        [Display(Name = "CarAge")]
        public string CarAge { get; set; }

        [Display(Name = "CarPrice")]
        public string CarPrice { get; set; }

        [Display(Name = "UserId")]
        public int UserId { get; set; }
    }
}
