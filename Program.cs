// See https://aka.ms/new-console-template for more information
using software_architectuur_3_xin_jascha.domain;

Console.WriteLine("Hello, World!");

Order Test = new Order(1, true);
var Movie = new Movie("Steamboat Willie");
var Screening = new MovieScreening(Movie, DateTime.Now, 10.50);
var Ticket = new MovieTicket(Screening, false, 1, 1);
Test.AddSeatReservation(Ticket);
Test.Export(TicketExportFormat.JSON);
