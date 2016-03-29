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
      

    }

    public class RegisterReservation
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RestaurantID { get; set; }
        public DateTime DateAndTime { get; set; }
    }

}