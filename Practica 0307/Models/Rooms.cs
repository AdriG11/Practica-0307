using System.Collections;

namespace Practica_0307.Models
{
    public class Rooms
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public RoomType RoomType { get; set; }
        public RoomStatus RoomStatus { get; set; }
        public decimal PricePerNight { get; set; }
        public ICollection Reservations { get; set; }
}

    public enum  RoomStatus
    {
        Disponible,
        Ocupada,
        Mantenimiento
    }

    public enum RoomType
    {
        Individual,
        Doble,
        Suite
    }
}
