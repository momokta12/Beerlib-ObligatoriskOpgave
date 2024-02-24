using Microsoft.VisualStudio.TestTools.UnitTesting;
using Beerlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beerlib.Tests
{
    [TestClass()]
    public class BeerTests
    {
        // Test af ToString metoden i Beer klassen for at sikre, den returnerer den forventede streng.
        [TestMethod()]
        public void ToStringTest()
        {
            Beer beer = new Beer()
            {
                Name = "Test",
                Id = 1,
                Abv = 0
            };

            string b1 = beer.ToString();
            {
                Assert.AreEqual("1 Test 0", b1); // Verificerer at output er som forventet.
            }

        }
        // Test af ValidateName metoden for at sikre, den kaster de korrekte undtagelser.
        [TestMethod()]
        public void ValidateNameTest()
        {
            Beer beerNnull = new Beer()
            {
                Name = null,
                Id = 1,
                Abv = 31
            };
            // Forventer ArgumentNullException, hvis navn er null.
            Assert.ThrowsException<ArgumentNullException>(() => beerNnull.ValidateName());

            Beer beerName = new Beer()
            {
                Name = "Ti",
                Id = 1,
                Abv = 31
            };
            // Forventer ArgumentOutOfRangeException, hvis navnet er for kort.
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beerName.ValidateName());
        }
        // Test af ValidateAbv metoden for at sikre, den kaster de korrekte undtagelser.
        [TestMethod()]
        public void ValidateAbvTest()
        {
            Beer beerabv = new Beer()
            {
                Id = 1,
                Name = "Test",
                Abv = 68 // Værdi over den tilladte grænse
            };
            // Forventer ArgumentOutOfRangeException, hvis Abv er over den tilladte grænse.
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beerabv.ValidateAbv());

            Beer beerabvInrange = new Beer()
            {
                Id = 1,
                Name = "Test",
                Abv = 66 // Værdi inden for den tilladte grænse
            };
            // Tester for korrekt validering uden undtagelser for gyldige Abv-værdier.
            beerabvInrange.ValidateAbv();

           Beer beerout = new Beer()
            {
                Id = 1,
                Name = "Test",
                Abv = -1 // Negativ værdi, ikke tilladt
           };
            // Forventer ArgumentOutOfRangeException, hvis Abv er under den tilladte grænse.
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> beerout.ValidateAbv());
        }

         
      

    } 
   

    }

