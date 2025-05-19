using CurvaHagz.Models.App;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurvaHAgz.Web.App.ViewModels
{
    public class PlaygroundDetailsVm
    {
        public int PlaygroundId { get; set; }
        public string PlaygroundName { get; set; }
        public string City { get; set; }
        public string Government { get; set; }
        public string Address { get; set; }
        public string SurfaceType { get; set; }

        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public AvailableForWomen AvailableForWomen { get; set; }
        public decimal HourlyPrice { get; set; }
        public decimal DepositeAmount { get; set; }
        public int CancelationPolicy { get; set; }
        public string ContactNumber { get; set; }
        public string? Description { get; set; }
        public string? Feature1 { get; set; }
        public string? Feature2 { get; set; }

        public string? Feature3 { get; set; }

        public string? Feature4 { get; set; }

        public string? Feature5 { get; set; }
        public string? Feature6 { get; set; }
        public TimeSpan OpeningHour { get; set; }

        public TimeSpan ClosingHour { get; set; }
        public DateTime BookingStart { get; set; }
        public int Duration { get; set; }
        public DateTime BookingDate { get; set; }
        public int PlayersNumber { get; set; }
        public string Notes { get; set; }
        public int BookingTimeHour { get; set; }
        public List<Booking> PlaygroundBookings { get; set; }
        public List<int> AvailableHours { get; set; }
    }
}
