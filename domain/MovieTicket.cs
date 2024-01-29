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

        public MovieTicket(MovieScreening movieScreening, bool IsPremiumReservation, int SeatRow, int SeatNr)
        {

        }

        public bool IsPremiumTicket()
        {
            return this.IsPremium;
        }

        public double GetPrice()
        {
            return -1;
        }

        public String ToString()
        {
            return "henk";
        }
    }
}
