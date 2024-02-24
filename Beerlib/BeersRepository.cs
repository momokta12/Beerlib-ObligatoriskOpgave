using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beerlib
{
    public class BeersRepository
    {
        // Starter ID-tælleren fra 6, da der allerede er 5 øl i listen ved initialisering.
        private int _nextid = 6;
        // En privat liste, der indeholder de øl, der er tilgængelige i repository.
        private List<Beer> beers = new List<Beer>()
        {
                        // Initialiserer listen med 5 øl-objekter.
            new Beer() { Id = 1, Name = "Test1", Abv = 14 },

            new Beer() { Id = 2, Name = "Test2", Abv = 25 },

            new Beer(){ Id = 3, Name = "Test3", Abv = 6 },

            new Beer() { Id = 4, Name = "Test4", Abv = 43 },

            new Beer() { Id = 5, Name = "Test5", Abv = 58 }
        };

        // Tilføjer en ny øl til listen og returnerer den tilføjede øl.
        public Beer AddBeer(Beer beer)
        {
            beer.Id = _nextid++;  // Tildeler en ny ID og inkrementerer ID-tælleren.
            beers.Add(beer); // Tilføjer den nye øl til listen.
            return beer; // Returnerer den tilføjede øl
        }

        // Sletter en øl baseret på ID og returnerer den slettede øl.
        public Beer DeleteBeer(int id)
        {
            Beer beer = beers.Find (x => x.Id == id);  // Finder øllen med det givne ID.
            if (beer != null) // Hvis øllen findes, fjernes den fra listen.
            {
                beers.Remove (beer);
            }
            return beer; // Returnerer den slettede øl (eller null, hvis ikke fundet).
        }
        // Returnerer alle øl, eventuelt filtreret og sorteret baseret på de angivne parametre.
        public List<Beer> GetAll(int? minabv = null, string sortBy = null )
        {
            List<Beer> result = new List<Beer>(beers);
            if (minabv != null) // Filtrer baseret på minimum ABV, hvis angivet.
            {
                result = result.FindAll(x => x.Abv == minabv);
            }
            if (sortBy != null) // Sorterer baseret på det angivne kriterium, hvis angivet
            {
                switch (sortBy)
                {
                    case "Name":
                        result.Sort((b1, b2)=>b1.Name.CompareTo(b2.Name)); break;
                    case "Name_desc":
                        result.Sort((b1, b2) => b2.Name.CompareTo(b1.Name)); break;
                    case "abv":
                        result.Sort((b1, b2)=> b1.Abv - b2.Abv); break;
                }
            }
            return result; // Returnerer den filtrerede og/eller sorteret liste af øl.
        }

        // Returnerer en øl baseret på ID.
        public Beer GetById(int id)
        {
            return beers.Find(x => x.Id == id); // Finder og returnerer øllen med det angivne ID.
        }


        // Opdaterer en eksisterende øl baseret på ID med nye værdier og returnerer den opdaterede øl.
        public Beer UpdateBeer(Beer beer, int id)
        {
            Beer beertoUpdate = beers.Find (x => x.Id == id); // Finder øllen, der skal opdateres.
            if (beertoUpdate != null) // Hvis øllen findes, opdateres den med de nye værdier.
            {
                beertoUpdate.Abv = beer.Abv;
                beertoUpdate.Name = beer.Name;
            }
            return beertoUpdate; // Returnerer den opdaterede øl (eller null, hvis ikke fundet).
        }
    }
}

