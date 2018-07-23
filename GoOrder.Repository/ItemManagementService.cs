using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoOrder.Entities;

namespace GoOrder.Repository
{
    public class ItemManagementService
    {
        private ItemContext _itemContext;
        private ItemUnitOfWork _itemUnitOfWork;

        public ItemManagementService()
        {
            _itemContext = new ItemContext();
            _itemUnitOfWork = new ItemUnitOfWork(_itemContext);
        }
        public List<Item> GetItemPagedOrder(int index, int length, string searchValue,
           string sortColumnName, string sortDirection, out int recordsTotal, out int recordsFiltered)
        {
            recordsTotal = 0;
            recordsFiltered = 0;

            return _itemUnitOfWork.ItemRepository.GetDynamic(out recordsTotal, out recordsFiltered,
                x => x.Name.Contains(searchValue), sortColumnName + " " + sortDirection,"", index, length).ToList();
        }
        public string GetAllItem()
        {
            List<Item> items = _itemUnitOfWork.ItemRepository.GetAll().ToList();
            return items.Count().ToString();
        }
    }
    
}
