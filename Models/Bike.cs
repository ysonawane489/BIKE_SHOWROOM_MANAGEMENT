using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BIKE_SHOWROOM_MANAGEMENT.Models
{
    public class Bike
    {
        [Key]
        public int BikeId { get; set; }
        public string BikeName { get; set; }
        public string Company { get; set; }
        public int Milage { get; set; }
        public int Price { get; set; }

    }
}
