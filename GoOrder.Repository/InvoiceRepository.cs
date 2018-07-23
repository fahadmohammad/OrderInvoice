using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoOrder.Data;
using GoOrder.Entities;

namespace GoOrder.Repository
{
    public class InvoiceRepository : Repository<Invoice>
    {
        private InvoiceContext _invoiceContext;
        public InvoiceRepository(InvoiceContext invoiceContext)
            :base(invoiceContext)
        {
            _invoiceContext = invoiceContext;
        }
    }
}
