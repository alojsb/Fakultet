using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSteam.Core
{
    public class Ranking
    {
        public int Id { get; set; }
        public decimal AverageRating {  get; set; }
        public int VoteCount { get; set; }
        public Dictionary<int, int> RatingDistribution { get; set; }
        public Ranking() {
            RatingDistribution = new Dictionary<int, int>();
        }
    }
}
