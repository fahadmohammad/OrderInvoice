using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoOrder.Entities;

namespace GoOrder.Repository
{    
    public class InvoiceManagementService
    {
        private InvoiceContext _invoiceContext;
        private InvoiceUnitOfWork _invoiceUnitOfWork;

        public InvoiceManagementService()
        {
            _invoiceContext = new InvoiceContext();
            _invoiceUnitOfWork = new InvoiceUnitOfWork(_invoiceContext);
        }

        public List<Invoice> GetInvoicePagedOrder(int index, int length, string searchValue,
           string sortColumnName, string sortDirection, out int recordsTotal, out int recordsFiltered)
        {
            recordsTotal = 0;
            recordsFiltered = 0;

            return _invoiceUnitOfWork.InvoiceRepository.GetDynamic(out recordsTotal, out recordsFiltered,
                x => x.Amount.ToString().Contains(searchValue), sortColumnName + " " + sortDirection, "", index, length).ToList();
        }
        public void EditInvoice(Guid id,bool isPaid)
        {
            Invoice invoice = _invoiceUnitOfWork.InvoiceRepository.GetByID(id);
            invoice.IsPaid = isPaid;           
            
            _invoiceUnitOfWork.InvoiceRepository.Update(invoice);
            _invoiceUnitOfWork.Save();

        }
        //public void EditInvoice(Guid id,string value,int? columnPosition)
        //{
        //    Invoice invoice = _invoiceUnitOfWork.InvoiceRepository.GetByID(id);
        //    switch (columnPosition)
        //    {
        //        case 1:
        //           invoice.Amount = value;
        //            break;                            
        //        default:
        //            break;
        //    }
        //    _invoiceUnitOfWork.InvoiceRepository.Update(invoice);
        //    _invoiceUnitOfWork.Save();

        //}

        public string GetAllInvoice()
        {
            List<Invoice> invoices = _invoiceUnitOfWork.InvoiceRepository.GetAll().ToList();
            return invoices.Count().ToString();
        }

        public double TotalAmount()
        {
            List<Invoice> invoices = _invoiceUnitOfWork.InvoiceRepository.GetAll().ToList();
            double totalAmount = 0;
            foreach(var item in invoices)
            {
                if(item.IsPaid)
                {
                    totalAmount += item.Amount;
                }
                
            }
            return totalAmount;
        }
    }
}
