# AsyncInn
C# Entity Framework for Hotel Management System

## How it works
AsyncInn is a MVC .NET core Entity Framework web application.

Users will be able to:
- Add and update Hotels
- Add and udate Rooms
- Add and update Amenitites

As well as:
- Add rooms to hotels
- Add amenities to rooms

### Modeling
This application has a five model schema
- Hotels
```c#
public class Hotel
{
public int ID { get; set; }
public string Name { get; set; } = "Async Inn";
public int Phone { get; set; }

public ICollection<HotelRoom> HotelRoom { get; set; }
}
```
- Rooms
```c#
public class Room
{
public int ID { get; set; }
public string Name { get; set; }
public Layout Layout { get; set; }

ICollection<HotelRoom> HotelRoom { get; set; }
ICollection<Hotel> Hotel { get; set; }
}

public enum Layout
{
Studio,
OneBedroom,
TwoBedroom,
}
```
- Amenities
```c#
public class Amenities
{
public int ID { get; set; }
public string Name { get; set; }

public ICollection<RoomAmenities> RoomAmenities { get; set; }
}
```
- RoomAmenities
```c#
public class RoomAmenities
{
public int AmenitiesID { get; set; }
public int RoomID { get; set; }

public Amenities Amenities { get; set; }
public Room Room { get; set; }
}
```
- HotelRooms
```c#
public class HotelRoom
{
public int HotelID { get; set; }
public decimal RoomNumber { get; set; }
public int RoomID { get; set; }
public decimal Rate { get; set; }
public byte PetFriendly { get; set; }

public Hotel Hotel { get; set; }
public Room Room { get; set; }
}
```
