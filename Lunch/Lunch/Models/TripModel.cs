using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LunchWars.Domain;

namespace Lunch.Models
{
    public class TripModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public System.DateTime Date { get; set; }

        public byte Length { get; set; }

        public List<UserModel> TripUsers {get;set;}

        public List<TripRestaurantModel> TripRestaurants { get; set; }

    }

    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool Attended { get; set; }

        public bool IsDriving { get; set; }

        public int Votes { get; set; }
    }

    public class RestaurantModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }

    public class TripRestaurantModel
    {
        public int Id { get; set; }

        public string YelpId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string ImageUrl { get; set; }

        public int Votes { get; set; }

        public List<String> TripUsers { get; set; }
    }
}