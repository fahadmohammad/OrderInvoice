using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoOrder.Data;

namespace GoOrder.Entities
{
    public class Invoice : Entity
    {
        public double Amount { get; set; }
        public bool IsCreated { get; set; }
        public bool IsPaid { get; set; }

        //public Guid OrderId { get; set; }
        //[ForeignKey("OrderId")]
        //public Order Order { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
