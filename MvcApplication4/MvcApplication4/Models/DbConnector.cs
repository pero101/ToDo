using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication4.EF;

namespace MvcApplication4.Models
{
    public static class DbConnector
    {
        static dbToDoEntities2  database = new dbToDoEntities2();

        public static dbToDoEntities2 GetConnection() {
            return database;
        }

    }
}