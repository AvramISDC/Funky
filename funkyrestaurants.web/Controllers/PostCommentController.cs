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
            comment.RestaurantId = data.RestaurantID;
            db.Comments.Add(comment);
            //multiple users?
            //IEnumerable<int?> ratings = db.Comments.Where(c => c.RestaurantId == data.RestaurantID).Select(c => c.Ratings);
            db.SaveChanges();
            int? avg = 0;
            int count = 0;
            foreach (Comment R in db.Comments)
            {
                if (R.RestaurantId == comment.RestaurantId)
                {
                    avg += R.Ratings;
                    count++;
                }
            }
            Funkyrestaurant current = null;
            avg = avg / count;
            foreach (Funkyrestaurant restaurant in db.Funkyrestaurants)
            {
                if(restaurant.Id == comment.RestaurantId)
                {
                    current = restaurant;
                    break;
                }
            }
            current.AverageStars = avg;
            db.SaveChanges();
            return true;
        }
    }
    public class RegisterComment
    {
        public string CommentText { get; set; }
        public int? Ratings { get; set; }
        public int UserId { get; set; }
        public int RestaurantID { get; set; }
    }
}
