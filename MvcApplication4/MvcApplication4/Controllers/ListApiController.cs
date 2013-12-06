using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApplication4.Models;
using Newtonsoft.Json;

namespace MvcApplication4.Controllers
{
    public class ListApiController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get(int UserId)
        {
            if(DbUser.GetUser(UserId) == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "", Configuration.Formatters.JsonFormatter);
            
            List<Models.ToDoItem> list = DbList.GetList(UserId);

            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(list), Configuration.Formatters.JsonFormatter ) ;
        }

        public HttpResponseMessage Post(int userId, string text, int priority)
        {
            if (DbUser.GetUser(userId) == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "", Configuration.Formatters.JsonFormatter);

            DbList.Add(userId, text, priority);

            return Request.CreateResponse(HttpStatusCode.Created, "", Configuration.Formatters.JsonFormatter);
        }
        public HttpResponseMessage Delete(int todoItemId)
        {
            Status result = DbList.Delete(todoItemId);

            if(result == Status.BadRequest)
                return Request.CreateResponse(HttpStatusCode.NotFound, "", Configuration.Formatters.JsonFormatter);

            return Request.CreateResponse(HttpStatusCode.OK, "", Configuration.Formatters.JsonFormatter);
        }
    }
}