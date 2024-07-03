using Microsoft.EntityFrameworkCore;
using Practica_0307.Models;

namespace Practica_0307.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options)
           : base(options)
        {
        }

        public DbSet<Rooms> Room { get; set; }
        public DbSet<Reservations> Reservation { get; set; }


        
    }
}
