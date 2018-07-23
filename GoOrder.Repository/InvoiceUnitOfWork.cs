using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoOrder.Repository
{
    public class InvoiceUnitOfWork
    {
        private InvoiceContext _invoiceContext { get; set; }
        private InvoiceRepository _invoiceRepository { get; set; }

        public InvoiceUnitOfWork(InvoiceContext invoiceContext)
        {
            _invoiceContext = invoiceContext;
            _invoiceRepository = new InvoiceRepository(_invoiceContext);
        }
        public InvoiceRepository InvoiceRepository
        {
            get
            {
                return _invoiceRepository;
            }
        }

        public void Save()
        {
            _invoiceContext.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
