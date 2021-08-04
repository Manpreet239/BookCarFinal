using System.ComponentModel.DataAnnotations;

namespace BookCar.Models
{
    public class Cars
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
    }
}
