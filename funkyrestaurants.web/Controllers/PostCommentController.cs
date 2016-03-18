using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using funkyrestaurants.web.Models;

namespace funkyrestaurants.web.Controllers
{
    public class PostCommentsController : ApiController
    {
        [HttpPost]
        public bool PostComment(RegisterComment data)
        {
            var db = new FunkyDb();
            var comment = new Comment();
            comment.Text = data.CommentText;
            comment.Ratings = data.Ratings;
            comment.UserId = data.UserId;
            comment.RestaurantId = 1;
            db.Comments.Add(comment);
            db.SaveChanges();
            return true;
        }
    }
    public class RegisterComment
    {
        public string CommentText { get; set; }
        public int Ratings { get; set; }
        public int UserId { get; set; }
    }
}
