using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoOrder.Repository
{
    public class ItemUnitOfWork : IDisposable
    {
        private ItemContext _itemContext { get; set; }
        private ItemRepository _itemRepository { get; set; }

        public ItemUnitOfWork(ItemContext itemContext)
        {
            _itemContext = itemContext;
            _itemRepository = new ItemRepository(_itemContext);
        }
        public ItemRepository ItemRepository
        {
            get
            {
                return _itemRepository;
            }
        }

        public void Save()
        {
            _itemContext.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
