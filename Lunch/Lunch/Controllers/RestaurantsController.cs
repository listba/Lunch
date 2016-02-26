using System.Web.Http;
using YelpSharp;
using YelpSharp.Data;
using YelpSharp.Data.Options;
using LunchWars.Domain;
using System.Collections.Generic;
using System.Linq;
using Lunch.Models;

namespace Lunch.Controllers
{
    public class RestaurantsController : ApiController
    {
        private Yelp yApi;
        private Options options;


        public RestaurantsController()
        {
            options = new Options()
            {
                AccessToken = Properties.Settings.Default.yelpToken,
                AccessTokenSecret = Properties.Settings.Default.yelpSecret,
                ConsumerKey = Properties.Settings.Default.yelpConsumerKey,
                ConsumerSecret = Properties.Settings.Default.yelpConsumerSecret
            };
            yApi = new Yelp(options);
        }

        // GET api/values
        public IEnumerable<RestaurantModel> GetRestaurants()
        {
            var rs = Enumerable.Empty<RestaurantModel>();
            using (var s = new LunchWarsEntities())
            {
                rs = s.Set<Restaurant>().Select(r => new RestaurantModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImageUrl = r.ImageUrl
                });
            }
            return rs;

        }

        public bool PostAddRestaurant()
        {

        //    var so = new SearchOptions
        //    {
        //        GeneralOptions = new GeneralOptions
        //        {
        //            limit = 20,
        //            offset = 0,
        //            term = "food"
        //        },
        //        LocationOptions = new LocationOptions
        //        {
        //            location = "45242"
        //        },
        //        LocaleOptions = new LocaleOptions
        //        {

        //        }
        //    };
        //    var ef = new LunchWarsEntities();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        yApi.Search(so).Result.businesses.ForEach(b =>
        //        {
        //            var r = ef.Restaurants.Create();
        //            r.Address = b.location.address.Length > 0 ? b.location.address[0] : "";
        //            r.City = b.location.city;
        //            r.YelpId = b.id;
        //            r.Name = b.name;
        //            r.Zip = b.location.postal_code;
        //            r.State = b.location.state_code;
        //            r.ImageUrl = b.image_url;

        //            ef.Restaurants.Add(r);
                    
        //        });
        //        ef.SaveChanges();
        //        so.GeneralOptions.offset = i * 20;
        //    }
            return true;
        }


    }
}