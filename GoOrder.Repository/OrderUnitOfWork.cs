using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoOrder.Repository
{
    public class OrderUnitOfWork : IDisposable
    {
        public OrderContext _orderContext { get; set; }
        public OrderRepository _orderRepository { get; set; }

        public OrderUnitOfWork(OrderContext orderContext)
        {
            _orderContext = orderContext;
            _orderRepository = new OrderRepository(_orderContext);
        }
        public OrderRepository OrderRepository
        {
            get
            {
                return _orderRepository;
            }
        }

        public void Save()
        {
            _orderContext.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
