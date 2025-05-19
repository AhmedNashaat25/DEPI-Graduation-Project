using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurvaHagz.Data.App;
using CurvaHagz.Models.App;
using Microsoft.EntityFrameworkCore;

namespace CurvaHagz.Bussines.App
{
    public class PlaygroundManager
    {
        private CurvaHagzContext _context;
        public PlaygroundManager(CurvaHagzContext context)
        {
            _context = context;
        }
        public bool Add(PlayGround PlayGround)
        {
            _context.playGrounds.Add(PlayGround);
            int Index = _context.SaveChanges();
            if (Index == 0) return false;
            return true;
        }
        public List<PlayGround> GetAll()
        {
            return _context.playGrounds.ToList();
        }
        public List<PlayGround> GetOwnerPlaygrounds(int ownerId)
        {
            List<PlayGround> playGrounds = new List<PlayGround>();
            foreach (PlayGround PlayGround in _context.playGrounds)
            {
                if (PlayGround.OwnerId == ownerId) playGrounds.Add(PlayGround);
            }
            return playGrounds;
        }
        public PlayGround GetPlayground(int PlaygroundId)
        {
            return _context.playGrounds.FirstOrDefault(p => p.PlaygroundId == PlaygroundId);
        }
        public async Task<PlayGround> GetPlaygroundAsync(int id)
        {
            return await _context.playGrounds.FirstOrDefaultAsync(p => p.PlaygroundId == id);
        }
        public bool Update(PlayGround playGround)
        {
            _context.Update(playGround);
            int index = _context.SaveChanges();
            if (index > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsTeamNameTaken(string PlaygroundName, string Government)
        {
            PlayGround playGround = _context.playGrounds.FirstOrDefault(p => p.PlaygroundName == PlaygroundName);
            if (playGround == null)
            {
                return false;
            }
            else
            {
                if (playGround.Government == Government)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
