using LunchWars.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Lunch.Controllers
{
    public class TripController : ApiController
    {

        public IEnumerable<Trip> GetTrips()
        {
            var o = Enumerable.Empty<Trip>();
            using (var s = new LunchWarsEntities())
            {
                o = s.Set<Trip>();
            }
            return o;
        }

        public bool PostTrip(string name)
        {
            using (var s = new LunchWarsEntities())
            {
                var t = s.Trips.Create();
                t.Name = name;
                t.Date = DateTime.Now.AddHours(1);
                t.Length = 2;
                s.Trips.Add(t);
                return s.SaveChanges() == 1;
            }
        }

        public bool JoinTrip(int tripId)
        {
            var userId = HttpContext.Current.Request.Cookies["userId"];

            var o = Enumerable.Empty<Trip>();
            using (var s = new LunchWarsEntities())
            {
                o = s.Set<Trip>().Where(t => t.Id == tripId);
                if (o.Count() > 0)
                {
                    var trip = o.First();

                    var tu = s.TripUsers.Create();
                    tu.TripId = trip.Id;
                    tu.UserId = Convert.ToInt32(userId.Value);
                    s.TripUsers.Add(tu);
                    return s.SaveChanges() > 0;
                }
            }
            return false;
        }
    }
}