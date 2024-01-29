using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace software_architectuur_3_xin_jascha.domain
{
    internal class Order
    {
        private int OrderNr {  get; set; }
        private bool IsStudentOrder { get; set; }
        private List<MovieTicket> MovieTickets;

        public Order(int OrderNr, bool IsStudentOrder)
        {
            this.OrderNr = OrderNr;
            this.IsStudentOrder = IsStudentOrder;
            this.MovieTickets = new List<MovieTicket>();
        }

        public void AddSeatReservation(MovieTicket Ticket)
        {

        }

        public double CalculatePrice()
        {
            return -1;
        }

        private double calculateSecondTicketFree(int indexMovie)
        {
            if(indexMovie % 2 == 0 && indexMovie > 0)
            {
                return 0;
            }
            return MovieTickets[indexMovie].GetPrice();
        }

        public double calculatePriceAfterDiscount(double totalPriceBefore)
        {   
            // Returns total after discount
            return totalPriceBefore * 0.9;
        }

        private bool isWorkDay(MovieScreening movieScreening)
        {
            // Validates for everybody if moviescree is on weekdays.s
            int dayOfWeek = (int)movieScreening.DateAndTime.DayOfWeek;
            return dayOfWeek >= 1 & (dayOfWeek <= 4);
        }


        public void Export(TicketExportFormat Format) 
        {
           if(Format == TicketExportFormat.JSON)
            {
                var henk = JsonSerializer.Serialize(this);
                Console.WriteLine(henk);
            }
        }
    }
}
