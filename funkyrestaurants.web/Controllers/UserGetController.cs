using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using funkyrestaurants.web.Models;

namespace funkyrestaurants.web.Controllers
{
    [RoutePrefix("Api/Restaurants")]
    public class UserGetController : ApiController
    {
        public IEnumerable<User> Get(string Username)
        {
            var Db = new FunkyDb();
            List<User> list = new List<User>();
            foreach (var user in Db.Users)
            {
                if (user.Username == Username)
                {
                    list.Add(user);
                }
            }
            return list;
        }
    }
}
