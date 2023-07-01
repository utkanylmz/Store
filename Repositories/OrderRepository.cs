using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => context.Orders
                                                        .Include(o=>o.Lines)
                                                        .ThenInclude(cl=>cl.Product)
                                                        .OrderBy(o=>o.Shipped)
                                                        .ThenByDescending(o=>o.Shipped);

        public int NumberOfInProcess => context.Orders.Count(o=>o.Shipped.Equals(false));

        public void Complete(int id)
        {
            var order = FindByCondition(o => o.OrderId.Equals(id),true);
            if (order is null)
                throw new Exception("Order could nor found");
            order.Shipped = true;
            context.SaveChanges();
        }

        public Order? GetOneOrder(int id)
        {
            return FindByCondition(o => o.OrderId.Equals(id), false);
        }

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l=>l.Product));
            if (order.OrderId==0)
                context.Orders.Add(order);

            context.SaveChanges();

            
        }
    }
}
