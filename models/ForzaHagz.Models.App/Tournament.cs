using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurvaHagz.Models.App
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public int OrganizerId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string TournamentName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string TournamentCity { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string Prize { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public User Organizer { get; set; }
    }
}
