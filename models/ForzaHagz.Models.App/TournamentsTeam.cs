using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurvaHagz.Models.App
{
    public class TournamentsTeam
    {
        public int TournamentId { get; set; }
        public int TeamId { get; set; }
        public Tournament Tournament { get; set; }
        public Team Team { get; set; }
    }
}
