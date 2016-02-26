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
    }

    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool Attended { get; set; }

        public bool IsDriving { get; set; }

        public int Votes { get; set; }
    }
}