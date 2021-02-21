using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class SupplierItem
    {
        public Item items { get; set; }
        public Supplier suppliers { get; set; }

        public int id { get; set; }
        public String NamaSupplier { get; set; }
        public String nama { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int supplierId {get; set;}
    }
}