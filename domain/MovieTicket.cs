using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace software_architectuur_3_xin_jascha.domain
{

    internal class MovieTicket
    {
        private int RowNr {  get; set; }
        private int SeatNr { get; set; }
        private bool IsPremium { get; set; }
        private MovieScreening MovieScreening { get; set; }

        public MovieTicket(MovieScreening MovieScreening, bool IsPremiumReservation, int SeatRow, int SeatNr)
        {
            this.RowNr = SeatRow;
            this.SeatNr = SeatNr;
            this.IsPremium = IsPremiumReservation;
            this.MovieScreening = MovieScreening;
        }

        public bool IsPremiumTicket()
        {
            return this.IsPremium;
        }

        public double GetPrice()
        {
            return -1;
        }

        public MovieScreening GetMovieScreening()
        {
            return MovieScreening;
        }

        public String ToString()
        {
            return "henk";
        }
    }
}
