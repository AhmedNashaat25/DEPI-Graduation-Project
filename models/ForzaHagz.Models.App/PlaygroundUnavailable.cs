using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurvaHagz.Models.App
{
    public class PlaygroundUnavailable
    {
        public int Id { get; set; }
        public int PlaygroundId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime EndTime { get; set; }
        public PlayGround PlayGround { get; set; }
    }
}
