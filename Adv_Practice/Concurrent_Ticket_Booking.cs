using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace CSharp.Adv_Practice{
public class BookingModel {
    public int  BookID {get; set;}
    public bool IsBooked {get; set;}
}

public class BookingApplication{
    private object bookingObject = new object();
    private List<BookingModel> bookingList = new List<BookingModel>();

    public BookingApplication(int noOfSeats){
        for (int i=0;i<noOfSeats;i++){
            bookingList.Add(new BookingModel {BookID = i, IsBooked = false});
        }
    }
    public bool BookingSystem(int seatNo, string userID){
    lock (bookingObject)
    {
        BookingModel seat = bookingList.FirstOrDefault(s => s.BookID == seatNo);
        if (seat == null){
            throw new Exception("Invalid seat number");
        }
        if (seat.IsBooked)
        {
            Console.WriteLine("Already Booked");
            return false; 
        }
        seat.IsBooked = true;
        Console.WriteLine("Seat is booked "+ seat.BookID + "||" + userID);
        return true;
    }
    }
}

class Concurrent_Ticket_Booking
    {
        static void Main(String[] args)
        {
            var booking = new BookingApplication(5);
            var user1 =  booking.BookingSystem(1, "USer1");
            var user2 = booking.BookingSystem(1, "USer2");
            Console.WriteLine(user1);
            Console.WriteLine(user2);

        }
    }
}


