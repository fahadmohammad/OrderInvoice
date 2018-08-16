﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoOrder.Models;

namespace GoOrder.Controllers
{
    
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult GetJsonData(DataTablesAjaxRequestModel model)
        {
            var jsonData = new OrderListModel().GetOrderJsonData(model);

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public ActionResult AddOrder()
        {
            var orderModel = new OrderModel();
            return View(orderModel);
        }
        [HttpPost]
        public ActionResult AddOrder(OrderModel orderModel)
        {
            orderModel.AddOrder();
            return RedirectToAction("Index");           
        }

        public ActionResult OrderDetails(Guid id)
        {
            TempData["itemData"] = id;
            return View();
        }

        public JsonResult GetItemJsonData(DataTablesAjaxRequestModel model)
        {
            Guid id = (Guid)TempData["itemData"];
            var jsonData = new OrderListModel().GetItemJsonData(model,id);

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }        
        public ActionResult InvoiceDetails(Guid id)
        {
            TempData["invoiceData"] = id;
            return View();
        }
        public JsonResult GetInvoiceJsonData(DataTablesAjaxRequestModel model)
        {
            Guid id = (Guid)TempData["invoiceData"];
            var jsonData = new OrderListModel().GetInvoiceJsonData(model,id);

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult UpdateInvoice(Guid id,InvoiceModel invoiceModel)
        {
            //var InvoiceModel = new InvoiceModel();
            invoiceModel.EditInvoice(id);
            //Guid orderid = (Guid)TempData["itemData"];
            return RedirectToAction("Index");
        }
        //public ActionResult EditInvoice(Guid id, string value, int? rowId,
        //   int? columnPosition, int? columnId, string columnName)
        //{
        //    var orderModel = new OrderModel();
        //    orderModel.EditInvoice(id, value, columnPosition);
        //    return RedirectToAction("InvoiceDetails");
        //}
        public ActionResult Delete(Guid? id)
        {
            try
            {
                var orderModel = new OrderModel();
                orderModel.DeleteOrder(id);

                TempData["message"] = "Successfully Deleted";
                TempData["alertType"] = "success";
            }
            catch
            {
                TempData["message"] = "Failed to Deleted";
                TempData["alertType"] = "danger";
            }
            return RedirectToAction("Index");
        }

    }
}