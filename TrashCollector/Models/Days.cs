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
        [Display(Name = "Scheduled Pick Up Day")]
        public string Day { get; set; }
    }
}