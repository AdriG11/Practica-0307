using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica_0307.Data;
using Practica_0307.Models;

namespace Practica_0307.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly HotelDbContext _context2;
        public ReservationsController(HotelDbContext context2)
        {
            _context2 = context2;
        }
        // GET /api/reservation  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservations>>> GetReservations()
        {
            return await _context2.Reservation.ToListAsync();
        }
        // GET /api/reservation/{id} 
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservations>> GetReservations(int id)
        {
            var reser = await _context2.Reservation.FindAsync(id);

            if (reser == null)
            {
                return NotFound();
            }
            return reser;
        }
        // POST /api/reservation 
        [HttpPost]
        public async Task<ActionResult<Reservations>> PostReservation(Reservations reservation)
        {
            _context2.Reservation.Add(reservation);
            await _context2.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReservations), new { id = reservation.Id }, reservation);
        }

        // PUT /api/reservation/{id}  
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservations reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }
            _context2.Entry(reservation).State = EntityState.Modified;
            try
            {
                await _context2.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE /api/reservation/{id}
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _context2.Reservation.FindAsync(id);
            if (reservation == null) { return NotFound(); }
            _context2.Reservation.Remove(reservation);
            await _context2.SaveChangesAsync();
            return NoContent();
        }

        private bool ReservationExists(int id)
        {
            return _context2.Room.Any(e => e.Id == id);
        }
    }
}
