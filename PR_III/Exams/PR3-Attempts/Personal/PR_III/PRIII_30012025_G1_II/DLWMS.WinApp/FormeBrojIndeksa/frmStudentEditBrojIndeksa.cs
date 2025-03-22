using DLWMS.Data;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinApp.FormeBrojIndeksa
{
    public partial class frmStudentEditBrojIndeksa : Form
    {
        DLWMSContext dbContext = new DLWMSContext();
        Student student = new Student();

        public frmStudentEditBrojIndeksa(Student st, DLWMSContext db)
        {
            student = st;
            dbContext = db;
            InitializeComponent();
        }

        private void frmStudentEditBrojIndeksa_Load(object sender, EventArgs e)
        {
            this.Text = "Podaci o studentu";

            pbProfilnaSlika.Image = Helpers.Ekstenzije.ToImage(student.Slika);

            lblImePrezime.Text = $"{student.Ime} {student.Prezime}";
            lblBrojIndeksa.Text = $"{student.BrojIndeksa}";

            cmbDrzava.UcitajPodatke(dbContext.Drzave.ToList());
            cmbDrzava.SelectedValue = student.Grad.DrzavaId;

            var gradoviList = dbContext.Gradovi.Where(g => g.DrzavaId == student.Grad.DrzavaId).ToList();
            cmbGrad.UcitajPodatke(gradoviList);
            cmbGrad.SelectedValue = student.GradId;
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDrzava.SelectedValue == null)
            {
                return;
            }

            int selectedDrzavaId = (int)cmbDrzava.SelectedValue;
            var gradoviList = dbContext.Gradovi.Where(g => g.DrzavaId == selectedDrzavaId).ToList();
            cmbGrad.UcitajPodatke(gradoviList);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbGrad.SelectedValue == null) { return; }

            student.Slika = Helpers.Ekstenzije.ToByteArray(pbProfilnaSlika.Image);

            student.GradId = (int)cmbGrad.SelectedValue;

            dbContext.SaveChanges();
            this.Close();
        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbProfilnaSlika.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
