using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoOrder.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GoOrder.Models
{
    public class UserModel
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }        
        public string UserRole { get; set; }      

        public void CreateUser(String email, string password, string userRole)
        {
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            if (usermanager.FindByName("manager") == null)
            {
                var user = new ApplicationUser();
                user.Id = IdentityGenerator.NewSequentialGuid().ToString();
                user.UserName = email;
                user.Email = email;
                string pass = password;

                var newUser = usermanager.Create(user, pass);
                if (newUser.Succeeded)
                {
                    //var userRole = new ApplicationUser();
                    usermanager.AddToRole(user.Id, userRole);

                }

            }
        }
        public Boolean IsAdminUser(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roles = userManager.GetRoles(id);

            if (roles[0] == "Admin")
                return true;
            else
                return false;
        }
        
    }
}