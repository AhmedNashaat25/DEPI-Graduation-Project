using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CurvaHagz.Models.App
{
    [Owned]
    public class TeamStats
    {
        public int Wins { get; set; }
        public int Losses { get; set; }

    }
}
