using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoOrder.Repository;

namespace GoOrder.Models
{
    public class DashboardViewModel
    {
        private OrderManagementService _orderManagementService;
        private ItemManagementService _itemManagementService;
        private InvoiceManagementService _invoiceManagementService;

        public string OrderCount { get; set; }
        public string ItemCount { get; set; }
        public double TotalAmount { get; set; }
        public string TotalInvoiceCreated { get; set; }

        public DashboardViewModel()
        {
            _orderManagementService = new OrderManagementService();
            _itemManagementService = new ItemManagementService();
            _invoiceManagementService = new InvoiceManagementService();

            OrderCount = _orderManagementService.GetAllOrder();
            ItemCount = _itemManagementService.GetAllItem();
            TotalInvoiceCreated = _invoiceManagementService.GetAllInvoice();
            TotalAmount = _invoiceManagementService.TotalAmount();
        }

    }
    
}