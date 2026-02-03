namespace CSharp.Practice.Room_Booking_System;

class Room
{
    public int RoomNumber { get; set; }
    public string RoomType { get; set; }
    public double PricePerNight { get; set; }
    public bool IsAvailable { get; set; }
}

class HostelManagement
{
    private List<Room> _rooms = new List<Room>();

    public void AddRoom(int roomNumber, string type, double price)
    {
        // if room exists
        if (_rooms.Any(r => r.RoomNumber == roomNumber))
        {
            return;
        }

        _rooms.Add(
            new Room
            {
                RoomNumber = roomNumber,
                RoomType = type,
                PricePerNight = price,
                IsAvailable = true,
            }
        );
    }

    public Dictionary<string, List<Room>> GetRoomsByTpe()
    {
        return _rooms
            .Where(r => r.IsAvailable)
            .GroupBy(r => r.RoomType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public bool BookRoom(int roomNumber, int nights)
    {
        // if the room exists
        var room = _rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
        if (room == null || !room.IsAvailable)
        {
            return false;
        }
        room.IsAvailable = false;
        double totalCost = room.PricePerNight * nights;
        Console.WriteLine("TotalCost: " + totalCost);
        return true;
    }

    public List<Room> GetAvailableRoomByPriceRange(int minRange, int maxRange)
    {
        return _rooms
            .Where(r => r.IsAvailable && r.PricePerNight >= minRange && r.PricePerNight <= maxRange)
            .ToList();
    }
}

class Program
{
    static void Main(String[] args)
    {
        HostelManagement management = new HostelManagement();

        // add Rooms
        management.AddRoom(101, "deluxe", 2400);
        management.AddRoom(201, "suite", 5000);
        management.AddRoom(105, "simple", 1200);
        management.AddRoom(110, "simple", 1000);
        management.AddRoom(110, "deluxe", 2000);

        // book Room

        management.BookRoom(201, 2);
        management.BookRoom(105, 3);
        management.BookRoom(103, 2);

        // get rooms by type
        var roomType = management.GetRoomsByTpe();
        foreach (var room in roomType)
        {
            Console.WriteLine("Type: " + room.Key);
            foreach (var rooms in room.Value)
            {
                Console.WriteLine("Room Number: " + rooms.RoomNumber);
            }
        }

        // get rooms within price range

        var PriceRooms = management.GetAvailableRoomByPriceRange(1400, 2600);
        foreach (var rooms in PriceRooms)
        {
            Console.WriteLine("Rooms within Price Range:" + rooms.RoomNumber);
        }
    }
}
