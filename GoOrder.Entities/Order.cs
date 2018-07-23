using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoOrder.Data;

namespace GoOrder.Entities
{
    public class Order : Entity
    {
        public string CustomerName { get; set; }        
        public virtual List<Item> Items { get; set; }

        //public Guid InvoiceId { get; set; }
        //[ForeignKey("InvoiceId")]
        //public Invoice Invoice { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
    }
}
