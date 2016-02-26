using System.Web.Http;
using YelpSharp;
using YelpSharp.Data;
using YelpSharp.Data.Options;
using LunchWars.Domain;

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
        public SearchResults GetRestaurants(int zip, int page = 0)
        {
            var so = new SearchOptions
            {
                GeneralOptions = new GeneralOptions
                {
                    limit = 20,
                    offset = page*20,
                    term = "food"
                },
                LocationOptions = new LocationOptions
                {
                    location = zip.ToString()
                },
                LocaleOptions = new LocaleOptions
                {

                }
            };
            return yApi.Search(so).Result;
        }

        public bool PostAddRestaurant()
        {

            var so = new SearchOptions
            {
                GeneralOptions = new GeneralOptions
                {
                    limit = 20,
                    offset = 0,
                    term = "food"
                },
                LocationOptions = new LocationOptions
                {
                    location = "45242"
                },
                LocaleOptions = new LocaleOptions
                {

                }
            };
            var ef = new LunchWarsEntities();
            for (int i = 0; i < 5; i++)
            {
                yApi.Search(so).Result.businesses.ForEach(b =>
                {
                    var r = ef.Restaurants.Create();
                    r.Address = b.location.address.Length > 0 ? b.location.address[0] : "";
                    r.City = b.location.city;
                    r.YelpId = b.id;
                    r.Name = b.name;
                    r.Zip = b.location.postal_code;
                    r.State = b.location.state_code;
                    r.Price = b.image_url;

                    ef.Restaurants.Add(r);
                });
                ef.SaveChanges();
                so.GeneralOptions.offset = i * 20;
            }
            return true;
        }


    }
}