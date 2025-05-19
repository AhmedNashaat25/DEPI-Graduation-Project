using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurvaHagz.Models.App
{
    public enum ChallengeStatus { Rejected,Accepted,Pending}
    public class Challenge
    {
        [Key]
        public int ChallangeID { get; set; }
       
        public int ChallengerTeamID { get; set; }
        public int OpponentTeamID {  get; set; }
        public DateTime Scheduled_date { get; set; }
        public Team ChallengerTeam { get; set; }
        public Team OpponentTeam { get; set; }
        public ChallengeStatus Status { get; set; }

    }
}
