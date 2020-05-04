using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TinyCRM
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public string Phone { get; set; }
        public decimal TotalGross { get; private set; }
        public DateTime Created { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeliveryAddress { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Order> Orders { get; set; }
    }
}
