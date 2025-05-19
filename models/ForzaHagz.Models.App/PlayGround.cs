using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurvaHagz.Models.App
{
    public enum AvailableForWomen 
    { 
        No=0,
        Yes=1
    }
    public class PlayGround
    {
        
        public int PlaygroundId { get; set; }
        public int OwnerId  { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string PlaygroundName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Government { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string SurfaceType { get; set; }
        [Column(TypeName = "decimal(10,2)")]

        public decimal Width { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Length { get; set; }
        public AvailableForWomen AvailableForWomen { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal HourlyPrice { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal DepositeAmount { get; set; }
        public int CancelationPolicy { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string ContactNumber  { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string? Description { get; set; }
        public string? Feature1 { get; set; }
        public string? Feature2 { get; set; }
        public string? Feature3 { get; set; }
        public string? Feature4 { get; set; }
        public string? Feature5 { get; set; }
        public string? Feature6 { get; set; }
        [Column(TypeName = "time(0)")]
        public TimeSpan OpeningHour { get; set; }

        [Column(TypeName = "time(0)")]
        public TimeSpan ClosingHour { get; set; }

        public User Owner { get; set; }
        public List<PlaygroundRating> PlaygroundRatings { get; set; }
        public List<PlaygroundPhoto> PlaygroundPhotos { get; set; }
        public List<PlaygroundUnavailable> PlaygroundUnavailable { get; set; }
        public List<Booking> Bookings { get; set; }

    }
}
