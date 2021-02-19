using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table ("Tb_M_Supplier")]
    public class Supplier
    {
        [Key]
        public int id { get; set; }
        [StringLength(6, ErrorMessage = "hanya terdiri dari 6 karakter")]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage ="hanya terdiri dari huruf dan angka")]
        public string Nama { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}