    using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using funkyrestaurants.web.Models;

namespace funkyrestaurants.web.Controllers
{
    public class CommentsController : ApiController
    {
        public IEnumerable<Comment> Get(int RestaurantID)
        {
            var Db = new FunkyDb();
            List<Comment> list = new List<Comment>();

            foreach (var comment in Db.Comments)
            {
                if (comment.RestaurantId == RestaurantID)
                {
                    list.Add(comment);
                }

            }
            return list;
        }
    }
}
