// See https://aka.ms/new-console-template for more information
using software_architectuur_3_xin_jascha.domain;

Console.WriteLine("Hello, World!");

Order Test = new Order(1, true);
Test.Export(TicketExportFormat.JSON);
