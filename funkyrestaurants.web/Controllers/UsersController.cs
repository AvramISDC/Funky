using funkyrestaurants.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace funkyrestaurants.web.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        public bool PostRegisterUser(RegisterData data)
        {
            var db = new FunkyDb();
            var user = new User();
            user.Username = data.username;
            user.Name = data.username;
            user.Password = data.password;
            user.EmailAdress = data.emailadress;
            user.Birthday = DateTime.Today;
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }
    }
    public class RegisterData
    {
        public string username { get; set; }
        public string password { get; set; }
        public string emailadress { get; set; }
    }
}
