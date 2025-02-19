using System.ComponentModel.DataAnnotations.Schema;

namespace DLWMS.Data
{
    [Table("Gradovi")]
    public class Grad
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka{ get; set; }
        public int DrzavaId { get; set; }
        public bool Aktivan { get; set; }

        public Drzava Drzava { get; set; } = null!;
    }
}
