using software_architectuur_3_xin_jascha.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace software_architectuur_3_xin_jascha.Test
{
    public class Class1
    {
        [Fact]
        public void test_calculation_price_Student()
        {
            DateTime monday = new DateTime(2024, 01, 29);
            Movie little_witch = new Movie("Little Witch Academia");

            MovieScreening movieScreening = new MovieScreening(little_witch, monday, 3.0);
            MovieTicket premium = new MovieTicket(movieScreening, false, 1, 1);
            MovieTicket premium2 = new MovieTicket(movieScreening, false, 1, 1);
            MovieTicket premium3 = new MovieTicket(movieScreening, false, 1, 1);

            Order order = new Order(1, true);
            List<MovieTicket> ticket = new List<MovieTicket>()
            {
                premium, premium2, premium3
            };

            order.AddSeatReservation(premium);
            order.AddSeatReservation(premium2);
            order.AddSeatReservation(premium3);

            double result = order.CalculatePrice();
            Assert.Equal(6, result);

        }
    }
}
