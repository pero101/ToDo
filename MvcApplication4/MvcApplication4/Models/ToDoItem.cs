using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft;

namespace MvcApplication4.Models
{
    public class ToDoItem
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        
        [Newtonsoft.Json.JsonProperty(PropertyName = "text")]
        public string text { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "priority")]
        public int priority { get; set; }
    }
}