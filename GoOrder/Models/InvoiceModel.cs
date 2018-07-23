using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoOrder.Repository;

namespace GoOrder.Models
{
    public class InvoiceModel
    {
        private InvoiceManagementService _invoiceManagementService;
        public InvoiceModel()
        {
            _invoiceManagementService = new InvoiceManagementService();
        }
        public bool IsPaid { get; set; }
        //public string Amount { get; set; }

        public void EditInvoice(Guid id)
        {
            _invoiceManagementService.EditInvoice(id,IsPaid);
        }
    }
}