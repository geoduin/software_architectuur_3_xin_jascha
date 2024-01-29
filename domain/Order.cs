using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void Export(TicketExportFormat Format) 
        {
           
        }



    }
}
