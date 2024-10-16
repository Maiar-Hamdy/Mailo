using Mailo.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Composition;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailo.Models
{
    [NotMapped]
    public class Product
    {
        public int ID { get; set; }
		[MaxLength(15)]
		public string Name { get; set; }
		[MaxLength(50)]
		public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [MaxLength(50)]
        public DateTime AdditionDate { get; set; } = DateTime.Now;
       
        [Range(1,5)]
        public decimal Rating { get; set; }
        public decimal Discount { get; set; } = 0;
        public decimal TotalPrice { get; set; }
        public decimal Price { get; set; }
        public Product_Categories Category { get; set; }
        public ICollection<Review>? reviews { get; set; }
		public ICollection<OrderProduct>? OrderProducts { get; set; }
        public ICollection<Wishlist>? wishlists { get; set; }

    }
}
