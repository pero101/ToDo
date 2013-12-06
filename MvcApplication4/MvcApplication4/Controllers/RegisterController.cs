using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class RegisterController : ApiController
    {
        public int Get(string username, string password, string email)
        {
            Status result = DbUser.CheckCanUserRegisterd(username, password, email);
            if (result == Status.Ok)
                return (int)Status.BadRequest;

            DbUser.RegisterUser(username, password, email);
            return (int)Status.Created;
        }
    }
}