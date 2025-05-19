using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurvaHagz.Models.App
{
    public class PlaygroundRating
    {
        [Key]
        public int RatingId { get; set; }
        public int PlaygroundId { get; set; }
        public int PlayerId { get; set; }
        public int CleanRating { get; set; }
        public int ServiceRating { get; set; }
        public int TimingRating { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string ReviewText { get; set; }
        public DateTime CreatedAt { get; set; }
        public User Player { get; set; }
        public PlayGround PlayGround { get; set; }
    }
}
