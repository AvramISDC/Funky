using funkyrestaurants.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace funkyrestaurants.web.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public int PostVerifyUser(CheckData credentials)
        {
            var db = new FunkyDb();
            foreach (var user in db.Users)
            {
                if (user.Username == credentials.username)
                {
                    if (user.Password == credentials.password)
                    {
                        return user.Id;
                    }
                }
            }
            return -1;
        }

        public class CheckData
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}