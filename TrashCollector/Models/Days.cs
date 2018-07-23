using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Days
    {
        [Key]
        public int DayID { get; set; }
        public string Day { get; set; }
    }
}