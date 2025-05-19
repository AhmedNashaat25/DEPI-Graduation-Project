using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace CurvaHagz.Models.App
{
    public class OwnerPaymentInfo
    {
        public int OwnerID { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string VisaNumber { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string BankName { get; set; }
        [ForeignKey(nameof(OwnerID))]
        public User Owner { get; set; }
    }
}
