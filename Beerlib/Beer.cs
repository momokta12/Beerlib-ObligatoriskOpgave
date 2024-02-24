using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Beerlib
{
    public class Beer
    {
        // Properties til at holde øllets id, navn og alkoholprocent (Abv).
        public int Id { get; set; }
        public string Name { get; set; }
        public int Abv { get; set; }

        // Overskriver ToString metoden for at returnere øllets egenskaber som en streng.
        public override string ToString()
        {
            return $"{Id} {Name} {Abv}";
        }
        // Validerer øllets navn. Kaster en exception, hvis navnet er null eller for kort.
        public void ValidateName()
        {
            if (Name == null)
            {

                throw new ArgumentNullException("Name cannot be null");
            }
            if (Name.Length <= 3)
            {

                throw new ArgumentOutOfRangeException("Name must be 3 Characaters");
            }
        }
        // Validerer øllets alkoholprocent (Abv). Kaster en exception, hvis værdien er ugyldig.
        public void ValidateAbv()

        {
            if (Abv <= 0)
            {
                throw new ArgumentOutOfRangeException("Abv must be over 0");
            }
            if (Abv >= 67)
            {
                throw new ArgumentOutOfRangeException("Abv must be less than 67");
            }
        }
    }
    
}
