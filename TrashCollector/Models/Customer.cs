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

        [ForeignKey("PickUpDay")]
        [Display(Name = "Scheduled Pick Up Day")]
        public int DayID { get; set; }
        public Days PickUpDay { get; set; }
        public string SelectedPickUp { get; set; }
        [Display(Name = "One time extra pick up")]
        [DataType(DataType.Date)]
        public DateTime? ExtraPickUp { get; set; }
        [Display(Name = "Temporarily suspend pickup Start Date")]
        [DataType(DataType.Date)] 
        public DateTime? SuspendStart { get; set; }
        [Display(Name = "Temporarily suspend pickup End Date")]
        [DataType(DataType.Date)]
        public DateTime? SuspendEnd { get; set; }
        [Display(Name = "Account Balance")]
        [DataType(DataType.Currency)]
        public Double? AccountBalance{ get; set; }

        [ForeignKey("Address")]
        [Display(Name = "User Address")]
        public int UserAddressKey { get; set; }
        public UserAddress Address { get; set; }
        [Display(Name = "Confirmed last pickup")]
        public bool ConfirmedPickUp { get; set; }
        public IEnumerable<UserAddress> UserAddresses { get; set; }
        public string UserID { get; set; }
        public IEnumerable<Days> DaysOfWeek { get; set; }
    }
}