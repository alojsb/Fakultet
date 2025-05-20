using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyGameStore.Data
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<GameGenre> GaneGenres { get; set; } = new List<GameGenre>();
    }
}
