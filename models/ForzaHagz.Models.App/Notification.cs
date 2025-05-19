using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurvaHagz.Models.App
{
    public enum IsRead { No,Yes}
    public class Notification
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public IsRead IsRead { get; set; }
        public User User { get; set; }

    }
}
