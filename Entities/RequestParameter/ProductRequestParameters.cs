using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameter
{
    public class ProductRequestParameters:RequestParameters
    {
        public int CategoryId { get; set; }
        public decimal MaxPrice { get; set; } = int.MaxValue;
        public decimal MinPrice { get; set; } = 0;

        public bool IsValidPrice => MaxPrice > MinPrice;
    }
}
