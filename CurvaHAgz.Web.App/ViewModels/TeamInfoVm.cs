using CurvaHagz.Models.App;

namespace CurvaHAgz.Web.App.ViewModels
{
    public class TeamInfoVm
    {
        public string TeamName { get; set; }
        public string City { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public string CaptainName { get; set; } 
        public List<string> MembersName { get; set; }=new List<string>();
        public List<User> Members { get; set; } = new List<User>();
        public int RemovedMemberId { get; set; }

    }
}
