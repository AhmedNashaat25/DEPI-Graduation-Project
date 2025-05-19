using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurvaHagz.Models.App
{
    public class PlaygroundPhoto
    {
        [Key]
        public int PhotoId { get; set; }
        public int PlaygroundId { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string PhotoURL { get; set; }
        public PlayGround PlayGround { get; set; }
    }
}
