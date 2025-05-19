using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurvaHagz.Models.App
{
    public enum DepositPaid {Unpaid,Paid }
    public enum SplitPayment { Split, Total }
    public enum BookingStatus { Cancelled, Played,Pending }
    public class Booking
    {
        public int BookingId { get; set; }
        public int PlayerId { get; set; }
        public int PlaygroundId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public BookingStatus Status { get; set; }
        public DepositPaid DepositPaid { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Refund { get; set; }
        public SplitPayment SplitPayment { get; set; }
        public DateTime CreatedAt { get; set; }
        public User Player { get; set; }
        public PlayGround Playground { get; set; }

    }
}
