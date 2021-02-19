using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("Tb_M_Item")]
    public class Item
    {
        [Key]
        public int id { get; set; }
        public string nama { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int supplierId { get; set; }
        public Supplier Suppliers { get; set; }
    }
}