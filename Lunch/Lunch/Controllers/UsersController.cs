using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using LunchWars.Domain;



namespace Lunch.Controllers
{
    public class UsersController : ApiController
    {

        public UsersController()
        {
        }

        // GET api/values
        public HttpResponseMessage Login(string Email)
        {
            var resp = new HttpResponseMessage();

            var user = GetUser(Email);
            if (user != null)
            {
                var cookie = new CookieHeaderValue("userId", user.Id.ToString());
                cookie.Expires = DateTimeOffset.Now.AddDays(1);
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";
                resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            }
            return resp;
        }

        public User GetUser(string Email)
        {
            var user = new User();
            using (var s = new LunchWarsEntities())
            {
                user = s.Set<User>().SingleOrDefault(u => u.Email == Email);
            }
            return user;
        }


        [HttpPost]
        public bool PostUser(string Email, string Name)
        {
            var user = GetUser(Email);

            if(user == null)
            {
                using (var s = new LunchWarsEntities())
                {
                    user = s.Set<User>().Create();
                    user.Email = Email;
                    user.Name = Name;
                    s.Users.Add(user);
                    s.SaveChanges();
                }
            }

            return true;
        }
    }
}