using funkyrestaurants.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace funkyrestaurants.web.Controllers
{
    public class ReservationsController : ApiController
    {
      public bool GetCanReserve (int RestaurantID,int UserID, DateTime dateandtime)
        {
            var Db = new FunkyDb();
            var StartedDate = dateandtime.Date;
            var EndDate = dateandtime.Date.AddDays(1);
            var count = Db.Reservations.Where(r => r.RestaurantId == RestaurantID && r.DateAndTime < EndDate && r.DateAndTime > StartedDate).Count();
            var Restaurant = Db.Funkyrestaurants.Find(RestaurantID);
            if( Restaurant.Tables > count)
            {
                return true;
            } else
            {
                return false; 
            }

        }




    }

    public class RegisterReservation
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RestaurantID { get; set; }
        public DateTime DateAndTime { get; set; }
    }

}