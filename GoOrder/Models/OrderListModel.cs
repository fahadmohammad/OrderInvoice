using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoOrder.Entities;
using GoOrder.Repository;

namespace GoOrder.Models
{
    public class OrderListModel
    {
        private OrderManagementService _orderManagementService;
        private ItemManagementService _itemManagementService;
        private InvoiceManagementService _invoiceManagementService;

        public IEnumerable<Order> Orders { get; private set; }

        public OrderListModel()
        {
            _orderManagementService = new OrderManagementService();
            _itemManagementService = new ItemManagementService();
            _invoiceManagementService = new InvoiceManagementService();
        }

        public object GetOrderJsonData(DataTablesAjaxRequestModel model)
        {
            // All Post Data
            string[] columnOrder = { null, "Item Name", null, null };
            int index = model.GetPageIndex();
            int length = model.GetPageSize();
            string searchValue = model.GetSearchText();
            string sortColumnName = model.GetSortColumnName(columnOrder);
            string sortDirection = model.GetSortDirection();
            int recordsTotal = 0;
            int recordsFiltered = 0;

            List<Order> records = _orderManagementService.GetPagedOrder(index, length, searchValue,
                sortColumnName, sortDirection, out recordsTotal, out recordsFiltered);

            int serial = model.GetSerialNumber();
            var dataSet = (
                    from record in records
                    select new string[]
                    {
                        serial++.ToString(),
                        record.CustomerName.ToString(),
                        record.CreatedAt.ToString(),                        
                        //record.CountryOfCitizenship.ToString(),
                        //(record.DateOfBirth != null ? record.DateOfBirth.Value.ToLongDateString() : "-" ),
                        //(record.FirstLanguage != null ? record.FirstLanguage.ToString() : "-" ),
                        //(record.PrimaryEmail != null ? record.PrimaryEmail.ToString() : "-" ),
                        //(record.MaritalStatus != null ? record.MaritalStatus.ToString() : "-" ),
                        record.Id.ToString()
                    }
                );

            var jsonData = new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = dataSet
            };

            return jsonData;
        }

        public object GetItemJsonData(DataTablesAjaxRequestModel model,Guid id)
        {
            // All Post Data
            string[] columnOrder = { null, "Item Name", null, null };
            int index = model.GetPageIndex();
            int length = model.GetPageSize();
            string searchValue = model.GetSearchText();
            string sortColumnName = model.GetSortColumnName(columnOrder);
            string sortDirection = model.GetSortDirection();
            int recordsTotal = 0;
            int recordsFiltered = 0;

            List<Item> records = _itemManagementService.GetItemPagedOrder(index, length, searchValue,
                sortColumnName, sortDirection, out recordsTotal, out recordsFiltered);

            List<Item> newReocrds = new List<Item>();
            //Item item = records.Find(x => x.OrderId == id);
            //newReocrds.Add(item);
            foreach(var v in records)
            {
                if (v.OrderId == id)
                {
                    newReocrds.Add(v);
                }
            }

            int serial = model.GetSerialNumber();
            var dataSet = (
                    from record in newReocrds
                    select new string[]
                    {
                        serial++.ToString(),
                        record.Name.ToString(),
                        record.Quantity.ToString(),
                        record.Price.ToString(),                        
                        //record.CountryOfCitizenship.ToString(),
                        //(record.DateOfBirth != null ? record.DateOfBirth.Value.ToLongDateString() : "-" ),
                        //(record.FirstLanguage != null ? record.FirstLanguage.ToString() : "-" ),
                        //(record.PrimaryEmail != null ? record.PrimaryEmail.ToString() : "-" ),
                        //(record.MaritalStatus != null ? record.MaritalStatus.ToString() : "-" ),
                        record.Id.ToString()
                    }
                );

            var jsonData = new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = dataSet
            };

            return jsonData;
        }
        public object GetInvoiceJsonData(DataTablesAjaxRequestModel model,Guid id)
        {
            // All Post Data
            string[] columnOrder = { null, "Amount"};
            int index = model.GetPageIndex();
            int length = model.GetPageSize();
            string searchValue = model.GetSearchText();
            string sortColumnName = model.GetSortColumnName(columnOrder);
            string sortDirection = model.GetSortDirection();
            int recordsTotal = 0;
            int recordsFiltered = 0;

            List<Invoice> records = _invoiceManagementService.GetInvoicePagedOrder(index, length, searchValue,
                sortColumnName, sortDirection, out recordsTotal, out recordsFiltered);
            //List<Order> orderRecords = _orderManagementService.GetPagedOrder(index, length, searchValue,
            //    sortColumnName, sortDirection, out recordsTotal, out recordsFiltered);
            //foreach(var order in orderRecords)
            //{
            //    if (order.Id == id)
            //    {
            //        Order newOrder = order;
            //    }

            //}
            List<Invoice> newRecords = new List<Invoice>();
            Order order = _orderManagementService.GetById(id);
            foreach (var invoice in order.Invoices)
            {
                newRecords.Add(invoice);

            }

            //List<Invoice> newRecords = new List<Invoice>();
            ////Item item = records.Find(x => x.OrderId == id);
            ////newReocrds.Add(item);
            //foreach (var invoice in records)
            //{
            //    foreach (var order in invoice.Orders)
            //    {
            //        if (order.Id == id)
            //        {
            //            newRecords.Add(invoice);
                        
            //        }                       

            //    }
            //}

            int serial = model.GetSerialNumber();
            var dataSet = (
                    from record in newRecords
                    select new string[]
                    {
                        serial++.ToString(),
                        record.Amount.ToString(),
                        record.CreatedAt.ToString(),
                        record.IsPaid.ToString(),
                        //record.Quantity.ToString(),
                        //record.Price.ToString(),                        
                        //record.CountryOfCitizenship.ToString(),
                        //(record.DateOfBirth != null ? record.DateOfBirth.Value.ToLongDateString() : "-" ),
                        //(record.FirstLanguage != null ? record.FirstLanguage.ToString() : "-" ),
                        //(record.PrimaryEmail != null ? record.PrimaryEmail.ToString() : "-" ),
                        //(record.MaritalStatus != null ? record.MaritalStatus.ToString() : "-" ),
                        record.Id.ToString()
                    }
                );

            var jsonData = new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = dataSet
            };

            return jsonData;
        }
    }
}