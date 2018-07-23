using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoOrder.Data;
using GoOrder.Entities;

namespace GoOrder.Repository
{
    public class OrderContext : GoOrderContext<OrderContext>
    {
        public DbSet<Order> Orders { get; set; }
    }
}
