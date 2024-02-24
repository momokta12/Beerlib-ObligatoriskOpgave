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

    public class BeersRepositoryTests
    {

        // Testmetode for at tilføje en øl til repository og bekræfte, at den er blevet tilføjet korrekt.
        [TestMethod()]
        public void AddBeerTest()
        {
            // Opretter en ny instans af BeersRepository.
            BeersRepository beerRepository = new();
            // Opretter en ny øl.
            Beer beer1 = new Beer() { Name = "Test", Abv = 33 };
            // Tilføjer den nye øl til repository og gemmer den returnerede øl.
            var addbeer = beerRepository.AddBeer(beer1);
            // Bekræfter, at antallet af øl i repository er øget med én.
            Assert.AreEqual(6, beerRepository.GetAll().Count());
            // Bekræfter, at den tilføjede øl er den samme som den oprindelige øl.
            Assert.AreEqual(beer1, addbeer);
        }
        // Testmetode for at slette en øl fra repository og bekræfte, at den er blevet slettet korrekt.
        [TestMethod()]
        public void DeleteBeerTest()
        {
            // Opretter en ny instans af BeersRepository.
            BeersRepository repository = new();
            Beer beer = new Beer() { Name = "Test", Abv = 33 };
            // Sletter en øl med et specifikt ID (i dette tilfælde 4).
            var deletedbeer = repository.DeleteBeer(4);
            // Bekræfter, at antallet af øl i repository nu er ét mindre.
            Assert.AreEqual(4, repository.GetAll().Count());
        }
        // Testmetode for at hente alle øl, filtrere dem baseret på ABV, og sortere dem baseret på navn.
        [TestMethod()]
        public void GetAllTest()
        {
            // Opretter en ny instans af BeersRepository.
            BeersRepository repository = new();
            // Henter alle øl uden filtrering eller sortering.
            var beers = repository.GetAll();
            // Bekræfter, at det samlede antal øl i repository er 5.
            Assert.AreEqual(5, beers.Count());

            // Henter øl filtreret på en minimum ABV værdi.
            var filteredBeersByAbv = repository.GetAll(minabv: 43);
            // Bekræfter, at kun én øl opfylder ABV-kriteriet.
            Assert.AreEqual(1, filteredBeersByAbv.Count());

            // Henter og sorterer øl baseret på navn.
            List<Beer> beersWithNameSorted = repository.GetAll(sortBy: "Name");
            // Bekræfter, at den fjerde øl i den sorteret liste har det forventede navn.
            Assert.AreEqual("Test4", beersWithNameSorted[3].Name);
        }

        // Testmetode for at opdatere en øl i repository og bekræfte, at den er blevet opdateret korrekt.
        [TestMethod()]
        public void UpdateBeerTest()
        {        
            // Opretter en ny instans af BeersRepository.
            BeersRepository repository = new BeersRepository();
            // Forbereder de opdaterede data for en øl.
            Beer updatedBeer = new Beer() { Name = "UpdatedTest", Abv = 65 };

            // Opdaterer øllen med ID 1 med de nye værdier.
            Beer result = repository.UpdateBeer(updatedBeer, 1);

            // Henter den opdaterede øl for at bekræfte ændringerne.
            Beer beerAfterUpdate = repository.GetById(1);

            // Bekræfter, at den opdaterede øl har de nye værdier.
            Assert.IsNotNull(result);
            Assert.AreEqual("UpdatedTest", beerAfterUpdate.Name);
            Assert.AreEqual(65, beerAfterUpdate.Abv);

           
        }
       
    }

}


