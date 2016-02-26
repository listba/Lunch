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
                var now = DateTime.Now;
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
                    var restaurants = new List<TripRestaurantModel>();

                    var something = trip.TripVotes.Select(x => x.Restaurant).Distinct().ToList();

                    foreach (var z in something)
                    {
                        var rmodel = new TripRestaurantModel
                        {
                            Name = z.Name,
                            ImageUrl = z.ImageUrl,
                            Id = z.Id,
                            TripUsers =
                                trip.TripVotes.Where(y => y.Restaurant.Name == z.Name).Select(x => x.User.Name).ToList(),
                            Votes = trip.TripVotes.Count(x => x.Restaurant.Name == z.Name),

                        };
                       restaurants.Add(rmodel);
                    }

                    tripM.TripRestaurants = restaurants;
                    result.Add(tripM);
                    


                }
                
            }
            
            return result;
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