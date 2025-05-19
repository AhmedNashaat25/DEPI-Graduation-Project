using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurvaHagz.Models.App
{
    public class Media
    {
        public int MediaId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string MediaURL { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Caption { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string MediaType { get; set; }
        public DateTime UploadedAt { get; set; }
        public DateTime CurrentTime { get; set; }
        public User User { get; set; }
    }
}
