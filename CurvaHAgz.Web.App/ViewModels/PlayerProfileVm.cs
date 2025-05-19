using CurvaHagz.Models.App;

namespace CurvaHAgz.Web.App.ViewModels
{
    public class PlayerProfileVm
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone {  get; set; }
        public string FullName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string ProfileImagePath { get; set; }

        public List<PlayGround> OwnerPlaygrounds { get; set; }=new List<PlayGround>();
        public List<Booking> PlayerBookings { get; set; } = new List<Booking>();

    }
}
