using CurvaHagz.Models.App;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurvaHAgz.Web.App.ViewModels
{
    public class AddPlaygroundVm
    {
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
    }
}
