using funkyrestaurants.web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace funkyrestaurants.web.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        public IHttpActionResult PostRegisterUser(RegisterData data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var db = new FunkyDb();
            var user = new User();
            user.Username = data.username;
            user.Name = data.username;
            user.Password = data.password;
            user.EmailAdress = data.emailadress;
            user.Birthday = DateTime.Today;
            db.Users.Add(user);
            db.SaveChanges();
            return Ok(true);
        }
    }
    public class RegisterData
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [EmailAddress]
        [Required]
        public string emailadress { get; set; }
    }
}
