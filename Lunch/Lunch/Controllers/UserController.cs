using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;

namespace Lunch.Controllers
{
    public class UserController : ApiController
    {

        public UserController()
        {
        }

        // GET api/values
        public HttpResponseMessage Login(string Email)
        {





            var resp = new HttpResponseMessage();
            var cookie = new CookieHeaderValue("userId", "1");
            cookie.Expires = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";  
            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return resp;
        }


        [HttpPost]
        public void PostUser(string Email, string Name)
        {

        }


        

    }
}