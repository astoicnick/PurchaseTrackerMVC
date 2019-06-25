using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PurchaseTracker.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Display(Name = "Food Type")]
        public int Zipcode { get; set; }
    }

    public class PurchaseContext : DbContext
    {
        public DbSet<Purchase> Purchases { get; set;  }
    }
}