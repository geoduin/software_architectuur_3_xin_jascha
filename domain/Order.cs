﻿using Newtonsoft.Json;
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
                bool isSecond = counter % 2 == 0;
                bool _is_work_Day = IsWorkDay(ticket.GetMovieScreening());
                double singlePrice = CalculatePremiumTicket(ticket);
                // Checks if order is either a studentorder/regular user on weekday and ticket is the second of ticket of the order. 
                totalPrice = CalculateSecondTicket(totalPrice, singlePrice, isSecond, _is_work_Day);
            }
            // Apply discount
            return CalculatePriceAfterDiscount(totalPrice);
        }

        private double CalculateSecondTicket(double currentTotal, double price, bool isSecond, bool isWorkDay)
        {
            if ((isWorkDay || IsStudentOrder) && isSecond)
            {
                return currentTotal;
            }
            else
            {
                return currentTotal + price;
            }
        }
        private double CalculatePremiumTicket(MovieTicket Ticket)
        {
            
            if (Ticket.IsPremiumTicket())
            {
                if (IsStudentOrder)
                {
                    return Ticket.GetPrice() + 2;
                }
                return Ticket.GetPrice() + 3;
            }
            return Ticket.GetPrice();
        }
        private double CalculatePriceAfterDiscount(double totalPriceBefore)
        {   
            // Returns total after discount
            if(MovieTickets.Count >= 6)
            {
                return totalPriceBefore * 0.9;
            }
            return totalPriceBefore;
        }
        private bool IsWorkDay(MovieScreening movieScreening)
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
