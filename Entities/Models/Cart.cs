﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public Cart()
        {
            Lines=new List<CartLine>();
        }


        public List<CartLine> Lines { get; set; }


        public virtual void AddItem (Product product,int quantity)
        {
            CartLine? line = Lines.Where(l => l.Product.Id == product.Id).FirstOrDefault();

            if (line is null)
            {
                Lines.Add(line = new CartLine { Product = product,Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }


        public virtual void RemoveLine (Product product)
        {
            Lines.RemoveAll(l => l.Product.Id == product.Id);
        }

        public decimal ComputeTotalValue() => Lines.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear()=> Lines.Clear(); 
    }
}
