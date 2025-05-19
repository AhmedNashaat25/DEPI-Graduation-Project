using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurvaHagz.Models.App
{
    public class Team
    {
        public int TeamId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string TeamName { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? TeamLogoURL { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string City { get; set; }
        public int CaptainId { get; set; }
        [ForeignKey(nameof(CaptainId))]
        public User Captain { get; set; }
        public List<User> Members { get; set; } = new List<User>();
        public TeamStats? TeamStats { get; set; }
        public List<Challenge>? ChallengesAsOpponent { get; set; }
        public List<Challenge>? ChallengesAsChallenger { get; set; }

      
    }
}
