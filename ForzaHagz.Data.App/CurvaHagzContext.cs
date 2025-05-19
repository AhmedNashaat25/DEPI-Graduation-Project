using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurvaHagz.Models.App;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CurvaHagz.Data.App
{
     public class CurvaHagzContext:IdentityDbContext<User,IdentityRole<int>,int>
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<OwnerPaymentInfo> ownerPaymentInfos { get; set; }
        public DbSet<PlayGround> playGrounds { get; set; }
        public DbSet<BookingParticipants> BookingParticipants { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<PlaygroundRating> playgroundRatings { get; set; }
        public DbSet<PlaygroundPhoto> playgroundPhotos { get; set; }
        public DbSet<PlaygroundUnavailable> playgroundUnavailables { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentsTeam> TournamentsTeams { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Media> Medias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;DataBase=CurvaHagztest4Db;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
            .HasOne(t => t.Captain)
            .WithMany()
            .HasForeignKey(t => t.CaptainId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete if captain is deleted

            modelBuilder.Entity<User>()
                .HasOne(u => u.Team)
                .WithMany(t => t.Members)
                .HasForeignKey(u => u.TeamId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete of users if team is deleted

            modelBuilder.Entity<Challenge>()
                .HasOne(c => c.ChallengerTeam)
                .WithMany(t=>t.ChallengesAsChallenger)
                .HasForeignKey(c => c.ChallengerTeamID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Challenge>()
                .HasOne(c => c.OpponentTeam)
                .WithMany(t=>t.ChallengesAsOpponent)
                .HasForeignKey(c => c.OpponentTeamID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Sender)
                .WithMany(u=>u.SenderChats)
                .HasForeignKey(c => c.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Recipient)
                .WithMany(u=>u.RecepientChats)
                .HasForeignKey(c => c.RecipientId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OwnerPaymentInfo>().HasKey(opi => new { opi.OwnerID, opi.VisaNumber });


            modelBuilder.Entity<BookingParticipants>().HasKey(bp => new { bp.BookingID, bp.PlayerID });

            modelBuilder.Entity<TournamentsTeam>().HasKey(tt => new { tt.TournamentId, tt.TeamId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
