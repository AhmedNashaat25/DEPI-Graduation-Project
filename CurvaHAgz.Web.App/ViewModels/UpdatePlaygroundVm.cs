using CurvaHagz.Models.App;
using System.ComponentModel.DataAnnotations;

namespace CurvaHAgz.Web.App.ViewModels
{
    public class UpdatePlaygroundVm
    {
        public int Id { get; set; }
        [Required]
        public string PlaygroundName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Government { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string SurfaceType { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Width must be between 1 and 1000 meters")]
        public decimal Width { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Length must be between 1 and 1000 meters")]
        public decimal Length { get; set; }

        [Required]
        public AvailableForWomen AvailableForWomen { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Hourly price must be a positive number")]
        public decimal HourlyPrice { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Deposit amount must be a positive number")]
        public decimal DepositeAmount { get; set; }
        [Required]
        [Range(0, 7, ErrorMessage = "Cancellation policy must be between 0 and 7 days")]
        public int CancelationPolicy { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string ContactNumber { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "Description is too long (max 1000 characters)")]
        public string? Description { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Feature is too long (max 100 characters)")]
        public string? Feature1 { get; set; }
        [Required]
        [StringLength(100)]
        public string? Feature2 { get; set; }
        [Required]
        [StringLength(100)]
        public string? Feature3 { get; set; }

        [StringLength(100)]
        public string? Feature4 { get; set; }

        [StringLength(100)]
        public string? Feature5 { get; set; }

        [StringLength(100)]
        public string? Feature6 { get; set; }

        [Required]
        public TimeSpan OpeningHour { get; set; }

        [Required]
        public TimeSpan ClosingHour { get; set; }
    }
}
