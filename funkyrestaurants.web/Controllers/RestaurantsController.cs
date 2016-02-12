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
    public class RestaurantsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Funkyrestaurant> Get(string Adress="", float Ratings=-1, int ID=-1)
        {
            //to do:filter by parameter if they exist
            var Db = new FunkyDb ();
            List<Funkyrestaurant> list = new List<Funkyrestaurant> () ;

            foreach( var restaurant in Db.Funkyrestaurants )
            {
                if ((Adress == "" || restaurant.Adress == Adress) && (Ratings == -1 || restaurant.AverageStars == Ratings) && (ID == -1 || restaurant.Id == ID))
                {
                    list.Add(restaurant);
                }             
            }
            return list;
        }
    }
}