using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TinyCRM
{
    public class Order
    {
        public int OrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalAmount { get; set; }
        //public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
    }
}