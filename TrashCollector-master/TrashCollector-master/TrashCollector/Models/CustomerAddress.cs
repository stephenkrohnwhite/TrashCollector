using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class CustomerAddress
    {
        public Customer Customer { get; set; }
        public UserAddress Address { get; set; }
    }
}