using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public string UserName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Scheduled Pick Up Day")]
        [DataType(DataType.Date)]
        public DateTime? PickUpDay { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Extra Pick Up")]
        public DateTime? ExtraPickUp { get; set; }
        [Display(Name = "Account Balance")]
        public Double? AccountBalance{ get; set; }

        [ForeignKey("Address")]
        [Display(Name = "User Address")]
        public int UserAddressKey { get; set; }
        public UserAddress Address { get; set; }

        public IEnumerable<UserAddress> UserAddresses { get; set; }
        public string UserID { get; set; }
    }
}