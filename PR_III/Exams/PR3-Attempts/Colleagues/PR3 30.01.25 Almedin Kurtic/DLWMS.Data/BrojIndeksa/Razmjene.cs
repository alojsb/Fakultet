using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data.IB220347
{
    public class Razmjene
    {
        public int Id { get; set; }
        public int UniverzitetId { get; set; }
        public int StudentId { get; set; }
        public int BrojECTS { get; set; }
        public bool Okoncana { get; set; }
        public DateTime PocetakRazmjene { get; set; }
        public DateTime KrajRazmjene { get; set; }
        public Student Student { get; set; }
        public required Univerziteti Univerzitet { get; set; }

    }
}
