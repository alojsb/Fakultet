using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data.IspitBrojIndeksa
{
    [Table("RazmjeneBrojIndeksa")]
    public class Razmjena
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int UniverzitetId { get; set; }
        public DateTime PocetakRazmjene {  get; set; }
        public DateTime KrajRazmjene { get; set; }
        public int ECTS {  get; set; }
        public bool isOkoncana { get; set; }

        public Univerzitet Univerzitet { get; set; } = null;
    }
}
