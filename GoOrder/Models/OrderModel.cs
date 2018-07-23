using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoOrder.Entities;
using GoOrder.Repository;

namespace GoOrder.Models
{
    public class OrderModel
    {
        private OrderManagementService _orderManagementService;
        private ItemManagementService _itemManagementService;
        private InvoiceManagementService _invoiceManagementService;

       
        public string CustomerName { get; set; }
        public virtual List<Item> Items { get; set; }
        //public string ItemName { get; set; }
        //public string ItemQuantity { get; set; }
        //public string ItemPrice { get; set; }
        //public virtual bool CreateInvoice { get; set; }
        public List<Invoice> Invoices { get; set; }

        //public virtual Invoice Invoice { get; set; }

        public OrderModel()
        {
            _orderManagementService = new OrderManagementService();
            _itemManagementService = new ItemManagementService();
            _invoiceManagementService = new InvoiceManagementService();
            //Invoice = new Invoice();
            //Items = new List<Item>();

        }
        public OrderModel(Guid id) : this()
        {
            var order = _orderManagementService.GetById(id);
            CustomerName = order.CustomerName;            
        }

        public void AddOrder()
        {
            _orderManagementService.AddOrder(CustomerName, Items, Invoices);
        }
        
        //public void EditInvoice(Guid id,string value, int? columnPosition)
        //{
        //    _invoiceManagementService.EditInvoice(id,value, columnPosition);
        //}
    }
    
}