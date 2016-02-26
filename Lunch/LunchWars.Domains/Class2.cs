using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LunchWars.Domain
{
    [TestFixture]
    public class DomainTests
    {

        [Test]
        public void DataBase()
        {
            var something = new LunchWarsEntities();


            var users = something.Set<User>().ToList();
            Assert.IsTrue(users.Any());
        }
    }
}
