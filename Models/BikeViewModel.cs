using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BIKE_SHOWROOM_MANAGEMENT.Models
{
    public class BikeViewModel
    {
        [Key]
        [Required(ErrorMessage = "Enter  BikeId")]
        public int BikeId { get; set; }

        [Required(ErrorMessage = "Enter  BikeName")]
        public string BikeName { get; set; }

        [Required(ErrorMessage = "Enter  Company")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Enter  Milage")]
        public int Milage { get; set; }

        [Required(ErrorMessage = "Enter  Price")]
        public int Price { get; set; }
    }
}
