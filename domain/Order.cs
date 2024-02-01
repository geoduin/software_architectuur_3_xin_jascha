using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace software_architectuur_3_xin_jascha.domain
{
    public class Order
    {
        public int OrderNr {  get; set; }
        public bool IsStudentOrder { get; set; }
        public List<MovieTicket> MovieTickets { get; set; }

        public Order(int OrderNr, bool IsStudentOrder)
        {
            this.OrderNr = OrderNr;
            this.IsStudentOrder = IsStudentOrder;
            this.MovieTickets = new List<MovieTicket>();
        }

        public void AddSeatReservation(MovieTicket Ticket)
        {
            MovieTickets.Add(Ticket);
        }

        public double CalculatePrice()
        {
            int counter = 0;
            double totalPrice = 0;
            for (int i = 0; i < MovieTickets.Count; i++)
            {
                counter++;
                MovieTicket ticket = MovieTickets[i];
                double singlePrice = calculatePremiumTicket(ticket);
                
                if (IsStudentOrder || isWorkDay(ticket.GetMovieScreening()) && counter % 2 != 0)
                {
                    totalPrice += singlePrice;
                }
            }
            return totalPrice;
        }

        private double calculatePremiumTicket(MovieTicket Ticket)
        {
            
            if (Ticket.IsPremiumTicket())
            {
                if (IsStudentOrder)
                {
                    return Ticket.GetPrice() + 2;
                }
                return Ticket.GetPrice() + 2;
            }
            return Ticket.GetPrice();
        }

        public double calculatePriceAfterDiscount(double totalPriceBefore)
        {   
            // Returns total after discount
            if(MovieTickets.Count >= 6)
            {
                return totalPriceBefore * 0.9;
            }
            return totalPriceBefore;
        }

        private bool isWorkDay(MovieScreening movieScreening)
        {
            // Validates for everybody if moviescree is on weekdays.s
            int dayOfWeek = (int)movieScreening.DateAndTime.DayOfWeek;
            return dayOfWeek >= 1 & (dayOfWeek <= 4);
        }


        public void Export(TicketExportFormat Format)
        {
            if (Format == TicketExportFormat.JSON)
            {
                File.WriteAllText("C:\\Temp\\test.json", JsonConvert.SerializeObject(this));
            }
            else
            {
                File.WriteAllText("C:\\Temp\\test.txt", this.ToString());
            }
        }

        override
        public String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("OrderNr: " + OrderNr + "\n");
            sb.Append("Is student order: " + IsStudentOrder + "\n");
            MovieTickets.ForEach(t =>
            {
                sb.Append(t.ToString() + "\n");
            });
            return sb.ToString();
        }
    }
}
