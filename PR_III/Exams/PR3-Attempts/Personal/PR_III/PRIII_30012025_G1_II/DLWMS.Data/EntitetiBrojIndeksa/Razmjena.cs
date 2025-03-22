using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data.EntitetiBrojIndeksa
{
    [Table("RazmjeneBrojIndeksa")]
    public class Razmjena
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int UniverzitetId { get; set; }
        public DateTime Pocetak {  get; set; }
        public DateTime Kraj {  get; set; }
        public int ECTS {  get; set; }
        public bool IsOkoncana {  get; set; }

        public Student Student { get; set; }
        public Univerzitet Univerzitet { get; set; }
    }
}
