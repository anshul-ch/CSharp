using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Scenario_based_questions
{
    class Ticket_Book
    {
        public static int TicketCount = 1000;
        public void AddTicket()
        {
            TicketCount++;
        }
        public void PrintDetails()
        {
            Console.WriteLine("TotalTickets: " + TicketCount);
        }
    }
    public class Ticket_Booking
    {
        static void Main(String[] args)
        {
            Ticket_Book booking = new Ticket_Book();
            booking.AddTicket();
            booking.AddTicket();
            booking.AddTicket();
            booking.AddTicket();
            booking.PrintDetails();
            booking.AddTicket();
            booking.AddTicket();
            booking.PrintDetails();
        }
    }
}
