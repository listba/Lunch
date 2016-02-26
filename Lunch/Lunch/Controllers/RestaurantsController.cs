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

namespace Lunch.Controllers
{
    public class RestaurantsController : ApiController
    {
        private Yelp yApi;

        public RestaurantsController()
        {
            yApi = new Yelp(new Options()
            {
                AccessToken = Properties.Settings.Default.yelpToken,
                AccessTokenSecret = Properties.Settings.Default.yelpSecret,
                ConsumerKey = Properties.Settings.Default.yelpConsumerKey,
                ConsumerSecret = Properties.Settings.Default.yelpConsumerSecret
            });
        }

        // GET api/values
        public IEnumerable<Business> GetRestaurants(int zip)
        {
            return yApi.Search("food", zip.ToString()).Result.businesses;
        }

    }
}