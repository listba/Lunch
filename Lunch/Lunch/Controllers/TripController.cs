using LunchWars.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Lunch.Models;

namespace Lunch.Controllers
{
    public class TripController : ApiController
    {

        public IEnumerable<TripModel> GetTrips()
        {
            var result = new List<TripModel> ();

            using (var s = new LunchWarsEntities())
            {
                var now = DateTime.Now.AddHours(1);
                var o = s.Set<Trip>().Where(x => x.Date > now).ToList();
                foreach (var trip in o)
                {
                    var tripusers = trip.TripUsers.Select(user => new UserModel()
                    {
                        UserId = user.UserId,
                        UserName = user.User.Name,
                        Votes = user.Votes
                    }).ToList();
                    var tripM = new TripModel
                    {
                        TripUsers = tripusers,
                        Date = trip.Date,
                        Length = trip.Length,
                        Id = trip.Id,
                        Name = trip.Name
                    };
                    result.Add(tripM);
                }
                
            }

            return result;
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