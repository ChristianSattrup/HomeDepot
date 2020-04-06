using HomeDepotWebApp.Models;
using HomeDepotWebApp.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDepotWebApp.Controllers
{
    public class LoginController : Controller
    {
        private HomeDepotContext _context;
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Autherize(string usernameData, string passwordData)
        {
            _context = new HomeDepotContext();
            Customer user=null;
            _context.Customers.ToList().ForEach(c=>
            {
                if (c.Username == usernameData && c.Password == passwordData)
                {
                    user = c;
                }
            }
            );
            if (user == null)
            {
                return Redirect("/login/login");
            }
            else
            {
                Session["user"] = user;
                return View("Home");
            }                         
           
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}