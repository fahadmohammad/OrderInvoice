using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoOrder.Data;
using GoOrder.Entities;

namespace GoOrder.Repository
{
    public class OrderRepository : Repository<Order>
    {
        private OrderContext _context;

        public OrderRepository(OrderContext context)
            :base(context)
        {
            _context = context;
        }
    }
}
