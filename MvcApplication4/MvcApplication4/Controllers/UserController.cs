using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class UserController : ApiController
    {
        public Status Login(string username, string password, string email)
        {
            Status result = DbUser.CheckCanUserRegisterd(username, password, email);
            
            return result;
        }
    }
}