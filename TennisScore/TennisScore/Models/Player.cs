using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScore.Models
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int CurrentScore { get; set; } = 0;
        public int Set { get; set; } = 0;
    }
}
