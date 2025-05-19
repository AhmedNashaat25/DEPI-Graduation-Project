using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurvaHagz.Models.App
{
    public class BookingParticipants
    {
        public int BookingID { get; set; }
        public int PlayerID { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal AmountPaid { get; set; }
        public User Player {  get; set; }
        public Booking Booking { get; set; }
    }
}
