using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoOrder.Data;
using GoOrder.Entities;

namespace GoOrder.Repository
{
    public class ItemRepository : Repository<Item>
    {
        private ItemContext _context;

        public ItemRepository(ItemContext itemContext)
            :base(itemContext)
        {
            _context = itemContext;
        }

        
    }
}
