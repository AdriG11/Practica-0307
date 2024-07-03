namespace Practica_0307.Models
{
    public class Reservations
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public int RoomId { get; set; }
        public Rooms Room { get; set; }
    }

    public enum ReservationStatus
    {
        Pendiente, 
        Confirmada,
        Cancelada
    }
}
