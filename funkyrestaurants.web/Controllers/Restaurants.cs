using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using funkyrestaurants.web.Models;

namespace funkyrestaurants.web.Controllers
{
    [RoutePrefix("Api/Jimmy")]
    public class RestaurantsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Funkyrestaurant> Get()
        {
            var Db = new FunkyDb ();
            List<Funkyrestaurant> list = new List<Funkyrestaurant> () ;

            foreach( var restaurant in Db.Funkyrestaurants )
            {
                list.Add(restaurant);
            }

            return list;
        }
    }
}