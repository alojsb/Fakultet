using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data.IspitBrojIndeksa
{
    public class StudentStipendijaBrojIndeksa
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int StudentStipendijaId { get; set; }

        public Student Student {  get; set; }
        public StudentStipendijaBrojIndeksa StudentStipendija { get; set; }
    }
}
