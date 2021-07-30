using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BIKE_SHOWROOM_MANAGEMENT.Models
{
    public class EmployeeViewModel
    {

        [Key]
        [Required(ErrorMessage = "Enter  EmpId")]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Enter  EmpName")]
        public string EmpName { get; set; }

        [Range(25,40, ErrorMessage = "Enter Age within 25 - 40")]
        public int Age { get; set; }

        [StringLength(12,ErrorMessage = "Enter 12 digit AdharNUmner") ]
        public string AdharId { get; set; }

       
        public string EmailId { get; set; }

        public string Designation { get; set; }
        public int CTC { get; set; }
        public string JoiningDate { get; set; }
    }
}
