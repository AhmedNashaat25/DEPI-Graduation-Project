using CurvaHagz.Data.App;
using CurvaHagz.Models.App;
using Microsoft.EntityFrameworkCore;

namespace CurvaHagz.Bussines.App
{
    public class TeamsManager
    {
        private CurvaHagzContext _context;
        public TeamsManager(CurvaHagzContext context)
        {
            _context = context;
        }
        public List<Team> GetAll()
        {
            return _context.Teams.Include(t=>t.Captain).ToList();
        }
        public bool Add(Team team)
        {
            _context.Teams.Add(team);
            int Index = _context.SaveChanges();
            if (Index == 0) return false;
            return true;
        }
        public bool Remove(int TeamId)
        {
            Team team = _context.Teams.FirstOrDefault(t => t.TeamId == TeamId);
            int Index = _context.SaveChanges();
            if (Index == 0) return false;
            return true;
        }
        public Team GetInfo(int TeamId)
        {
            Team team = _context.Teams.FirstOrDefault(t => t.TeamId == TeamId);
            if (team!=null) return team;
            return null;  
        }
        public Team GetInfo(int? TeamId)
        {
            return _context.Teams.FirstOrDefault(t => t.TeamId == TeamId);

        }
        public bool IsTeamNameTaken(string teamName)
        {
            return _context.Teams.Any(t => t.TeamName.ToLower() == teamName.Trim().ToLower());

        }
        //public bool HasTeam(int userId)
        //{

        //    return _context.Teams.Any(t => t.CaptainId == userId);
        //}
        //public bool MemberHasTeam(int? TeamId)
        //{

        //    return _context.Users.Any(t => t.TeamId == TeamId);
        //}
        public Team GetTeamByName(string TeamName)
        {
            Team team = _context.Teams.FirstOrDefault(t => t.TeamName == TeamName);
            if (team != null) return team;
            return null;
        }
        public bool AddPlayerToTeam(User user, Team team)
        {
            if (user.TeamId != null) return false;

            user.TeamId = team.TeamId;

            _context.Users.Update(user);
            _context.SaveChanges();

            return true;
        }
        public void RemoveFromTeam(int userId,List<User> Members)
        {
            foreach (User member in Members)
            {
                if(member.Id==userId)
                {
                    member.TeamId = null;
                    _context.Users.Update(member);
                    _context.SaveChanges();
                }
            }
        }
        public List<User> GetMembers(int TeamId)
        {
            List<User> members = new List<User>();
            foreach (User user in _context.Users)
            {
                if(user.TeamId==TeamId)
                {
                    members.Add(user);
                }
            }
            return members;
        }
    }
}
