using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoOrder.Data;
using GoOrder.Entities;

namespace GoOrder.Repository
{
    public class ItemContext : GoOrderContext<ItemContext>
    {
        public DbSet<Item> Items { get; set; }
    }
}
