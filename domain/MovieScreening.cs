using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace software_architectuur_3_xin_jascha.domain
{
    public class MovieScreening
    {
        public DateTime DateAndTime { get; set; }
        public double PricePerSeat { get; set; }
        public Movie Movie { get; set; }
        
        public MovieScreening(Movie Movie, DateTime DateAndTime, double PricePerSeat) { 
            this.Movie = Movie;
            this.DateAndTime = DateAndTime;
            this.PricePerSeat = PricePerSeat;
        }

        public double GetPricePerSeat()
        {
            return PricePerSeat;
        }

        public static string ToString()
        {
            return "s";
        }
    }
}
