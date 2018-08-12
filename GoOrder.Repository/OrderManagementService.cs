using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoOrder.Entities;

namespace GoOrder.Repository
{
    public class OrderManagementService
    {
        private OrderContext _orderContext;
        private OrderUnitOfWork _orderUnitOfWork;
       

        public OrderManagementService()
        {
            _orderContext = new OrderContext();
            _orderUnitOfWork = new OrderUnitOfWork(_orderContext);
           
        }
        public List<Order> GetPagedOrder(int index, int length, string searchValue,
            string sortColumnName, string sortDirection, out int recordsTotal, out int recordsFiltered)
        {
            recordsTotal = 0;
            recordsFiltered = 0;

            return _orderUnitOfWork.OrderRepository.GetDynamic(out recordsTotal, out recordsFiltered,
                x => x.CustomerName.Contains(searchValue), sortColumnName + " " + sortDirection, "", index, length).ToList();
        }
        

        public void AddOrder(string customerName,List<Item>items,List<Invoice>invoices)
        {
            Order order = new Order
            {
                CustomerName = customerName,
                Items = items,
                Invoices = invoices
            };
            //foreach (var v in order.Items)
            //{
            //    v.Name = itemName;
            //    v.Quantity = itemQuantity;
            //}
            //Item item = new Item
            //{
            //    Name = itemName,
            //    Quantity = itemQuantity,
            //    Price = itemPrice
            //};
            //Invoice invoice = new Invoice
            //{
            //    IsCreated = isCreated
            //};

            //order.Items.Add(item);
            //order.Invoices.Add(invoice);            

            _orderUnitOfWork.OrderRepository.Add(order);
            _orderUnitOfWork.Save();
        }
       

        public Order GetById(Guid id)
        {
            return _orderUnitOfWork.OrderRepository.GetByID(id);
        }
        public string GetAllOrder()
        {
            List<Order> orders = _orderUnitOfWork.OrderRepository.GetAll().ToList();
            return orders.Count().ToString(); 
        }
        public void DeleteOrder(Guid? id)
        {
            if (id.HasValue)
            {
                _orderUnitOfWork.OrderRepository.Delete(id);
                _orderUnitOfWork.Save();
            }
            else
            {
                throw new Exception();
            }

        }
    }
}
