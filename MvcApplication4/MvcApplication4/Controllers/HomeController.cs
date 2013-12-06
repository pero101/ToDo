using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string username, string password){

            Status result = DbUser.CheckLogin(username, password);

            if (result == Status.Ok)
            {
                Models.User logdInUser = DbUser.GetUser(username);
                Session["logedInUser"] = logdInUser;

                var idUserCookie = new HttpCookie("cookieIdUser", logdInUser.Id.ToString());
                var nameCookie = new HttpCookie("cookieUsername", username);
                var passwordCookie = new HttpCookie("cookiePassword", password);

                Response.Cookies.Add(idUserCookie);
                Response.Cookies.Add(nameCookie);
                Response.Cookies.Add(passwordCookie);
                
                Response.Redirect("~/List/Index");
            }
            
            return null;
        }

        public ActionResult Register(string username, string password, string confirmPassword)
        {
            password = username;

            return null;
        }
    }
}
