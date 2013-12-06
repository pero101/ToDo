using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public static class DbList
    {
        public static List<ToDoItem> GetList(int userId)
        {

            List<Models.ToDoItem> userList = new List<ToDoItem>();
            var listItems = (from x in DbConnector.GetConnection().Users
                                where x.Id == userId
                             select x).Single().ListItems.OrderBy(x => x.Priority).Reverse();

            foreach (var listItem in listItems)
            {
                Models.ToDoItem newItem = new Models.ToDoItem { 
                    id = listItem.Id, 
                    priority = listItem.Priority, 
                    text = listItem.Text 
                };

                userList.Add(newItem);
            }

            return userList;
        }
        public static Status Add(int userId, string text, int priority)
        {
            var user = (from x in DbConnector.GetConnection().Users
                       where x.Id == userId
                        select x).Single();

            var priorityItem = (from x in DbConnector.GetConnection().Priorities
                            where x.Id == priority
                            select x).Single();

            user.ListItems.Add(new EF.ListItem { Priority = priority, Text = text, UserId = userId, Priority1 = priorityItem, User = user });

            DbConnector.GetConnection().SaveChanges();

            return Status.Ok;
        }

        public static Status Delete(int listItemId) {
            var listItem = (from x in DbConnector.GetConnection().ListItems
                            where x.Id == listItemId
                            select x);

            if (listItem.Any() == false)
                return Status.BadRequest;

            DbConnector.GetConnection().ListItems.Remove(listItem.Single());
            DbConnector.GetConnection().SaveChanges();

            return Status.Ok;
        }
    }
}