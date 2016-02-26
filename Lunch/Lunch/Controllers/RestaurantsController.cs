using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YelpSharp;
using YelpSharp.Data;
using YelpSharp.Data.Options;

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

    }
}