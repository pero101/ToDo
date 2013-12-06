using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public static class DbUser
    {
        public static Models.User GetUser(int id)
        {
            var user = (from x in DbConnector.GetConnection().Users
                       where x.Id == id
                       select x).Single();

            if (user == null)
                return null;

            return new Models.User { Id = id, Email = user.Password, Password = user.Password, Username = user.UserName };
        }

        public static Status RegisterUser(string username, string password, string email)
        {
            EF.User newUser = new EF.User();
            newUser.UserName = username;
            newUser.Password = password;
            newUser.EMail = email;

            DbConnector.GetConnection().Users.Add(newUser);
            DbConnector.GetConnection().SaveChanges();

            return Status.Created;
        }

        public static Status CheckCanUserRegisterd(string username, string password, string email)
        {
            EF.User newUser = new EF.User();
            newUser.UserName = username;
            newUser.Password = password;
            newUser.EMail = email;

            var user = from x in DbConnector.GetConnection().Users
                       where x.UserName == username || x.EMail == email
                       select x;

            if (user.Any())
                return Status.Ok;
            else
                return Status.NotFoound;
        }
        public static Status CheckLogin(string username, string password) {
            var user = from x in DbConnector.GetConnection().Users
                       where x.UserName == username && x.Password == password
                       select x;

            if (user.Any())
                return Status.Ok;
            else
                return Status.NotFoound;
        }

        public static Models.User GetUser(string username) 
        {
            var userDb = (from x in DbConnector.GetConnection().Users
                       where x.UserName == username
                       select x).Single();

            Models.User userModel = new User { 
                Email= userDb.EMail, 
                Password = userDb.Password,
                Username = userDb.UserName,
                Id = userDb.Id};

            return userModel;

        }
    }
}