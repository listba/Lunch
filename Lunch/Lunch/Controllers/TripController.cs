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

        public bool PostTrip(String name)
        {
            using (var s = new LunchWarsEntities())
            {
                var t = s.Trips.Create();
                t.Name = name;
                s.Trips.Add(t);
                return s.SaveChanges() == 1;
            }
        }
    }
}