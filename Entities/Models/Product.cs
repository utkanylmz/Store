using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        

        public string ProductName { get; set; }=string.Empty;

        public String? Summary { get; set; } = String.Empty;
        public String? ImageUrl { get; set; } 

        public decimal Price { get; set; }

        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        public bool ShowCase { get; set; }
    }
}
