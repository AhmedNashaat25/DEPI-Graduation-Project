using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurvaHagz.Data.App;
using CurvaHagz.Models.App;
using Microsoft.EntityFrameworkCore;

namespace CurvaHagz.Bussines.App
{
    public class BookingManager
    {
        private CurvaHagzContext _context;
        public BookingManager(CurvaHagzContext context)
        {
            _context = context;
        }
        public List<Booking> GetAll()
        {
            return _context.Booking.ToList();
        }
        public int Add(Booking booking)
        {
            _context.Booking.Add(booking);
            int Index=_context.SaveChanges();
            return booking.BookingId;
        }
        public void Update(Booking booking)
        {
            _context.Booking.Update(booking);
        }
        public List<Booking> GetPlayerBookings(int PlayerId)
        {

            return _context.Booking
                .Include(b => b.Playground)
                .Where(b => b.PlayerId == PlayerId)
                .ToList(); ;
        }
        public Booking GetBookingbyId(int BookingId)
        {
            return _context.Booking.FirstOrDefault(b => b.BookingId == BookingId);
        }
        public List<Booking> GetPlaygroundBookings(int PlaygroundId)
        {

            return _context.Booking
                .Include(b => b.Playground)
                .Where(b => b.PlaygroundId == PlaygroundId)
                .ToList(); ;
        }

    }
}
