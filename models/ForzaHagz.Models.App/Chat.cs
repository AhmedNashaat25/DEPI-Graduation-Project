using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurvaHagz.Models.App
{
    public class Chat
    {
        [Key]
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime CurrentTime { get; set; }
        public User Sender { get; set; }
        public User Recipient { get; set; }
    }
}
