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
    public class MakeReservationController : ApiController
    {
        [HttpPost]
        public IHttpActionResult PostMakeReservation(ReservationData data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var db = new FunkyDb();
            var reservation = new Reservation();
            reservation.DateAndTime = data.dateandtime;
            reservation.RestaurantId = data.RestaurantId;
            reservation.UserId = data.UserId;
            db.Reservations.Add(reservation);
            db.SaveChanges();
            return Ok(true);

        }

       public class ReservationData
        {
            [Required]
            public DateTime dateandtime { get; set; }
            [Required]
            public int RestaurantId { get; set; }
            [Required]
            public int UserId { get; set; } 

        }

    }
}