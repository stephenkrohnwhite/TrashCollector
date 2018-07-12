using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class UserAddress
    {
        [Key]
        public int UserAddressID { get; set; }
        [Display(Name = "Address Line One")]
        public string AddressLine { get; set; }
        [Display(Name = "Address Line 2")]
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
    
    }
}