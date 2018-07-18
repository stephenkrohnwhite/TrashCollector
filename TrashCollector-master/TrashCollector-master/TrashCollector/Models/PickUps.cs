using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class PickUps
    {
        [Key]
        public int PickUpID { get; set; }
        public UserAddress PickUpAddress { get; set; }
        public DateTime PickUpTime { get; set; }
    }
}