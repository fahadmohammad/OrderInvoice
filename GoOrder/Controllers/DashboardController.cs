using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoOrder.Models;
using Microsoft.AspNet.Identity;

namespace GoOrder.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                //ViewBag.displayMenu = "No";
                Session["IsAdmin"] = "No";

                var id = User.Identity.GetUserId();

                UserModel userModel = new UserModel();
                bool isAdminUser = userModel.IsAdminUser(id);

                if (isAdminUser)
                {
                    //ViewBag.displayMenu = "Yes";
                    Session["IsAdmin"] = "Yes";
                }
                var dashboardViewModel = new DashboardViewModel();
                return View(dashboardViewModel);
            }
            else
            {             
                return RedirectToAction("Login", "Default");
            }

        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            UserModel userModel = new UserModel();
            var dbContext = new ApplicationDbContext();
            var allRoles = (new ApplicationDbContext()).Roles.OrderBy(m => m.Name).ToList().Select(r => new SelectListItem { Value = r.Name.ToString(), Text = r.Name }).ToList();
            ViewBag.Roles = allRoles;
            return View(userModel);
        }
        [HttpPost]
        public ActionResult CreateUser(UserModel userModel)
        {
            userModel.CreateUser(userModel.UserEmail, userModel.UserPassword, userModel.UserRole);
            return RedirectToAction("Index");
        }
    }
}