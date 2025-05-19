using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CurvaHagz.Models.App
{
    public enum IsOwner
    {
        Owner = 1,
        Player = 0
    }
    public enum IdentifyVerified
    {
        Yes = 1,
        No = 0
    }
    public class User:IdentityUser<int>
    {
        [Column(TypeName ="varchar(25)")]
        public string FName { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string MName { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string LName { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Gender { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Government { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string Address { get; set; }
        public string ProfileImagePath { get; set; } = "~/Images/userphoto.png";
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        public IsOwner IsOwner { get; set; }
        public IdentifyVerified IdentifyVerified { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<PlayGround> PlayGrounds { get; set; }
        public List<PlaygroundRating> PlaygroundRatings { get; set; }
        public List<OwnerPaymentInfo> ownerPaymentInfos { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Media> Media { get; set; }
        public List<Chat> SenderChats { get; set; }
        public List<Chat> RecepientChats { get; set; }


    }
}
