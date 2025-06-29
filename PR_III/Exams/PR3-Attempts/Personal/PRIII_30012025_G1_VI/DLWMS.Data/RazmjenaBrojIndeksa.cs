using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data
{
    public class RazmjenaBrojIndeksa
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int UniverzitetId { get; set; }
        public DateTime PocetakRazmjene { get; set; }
        public DateTime KrajRazmjene { get; set; }
        public int ECTS { get; set; }
        public bool IsOkoncana { get; set; }

        public Student Student { get; set; }
        public UniverzitetBrojIndeksa Univerzitet { get; set; }
    }
}
