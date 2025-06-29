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

namespace DLWMS.WinApp.IspitBrojIndeksa
{
    public partial class frmStudentEditBrojIndeksa : Form
    {
        Student student = new Student();
        DLWMSContext dbContext = new DLWMSContext();
        public frmStudentEditBrojIndeksa(Student st, DLWMSContext db)
        {
            student = st;
            dbContext = db;
            InitializeComponent();
        }

        private void frmStudentEditBrojIndeksa_Load(object sender, EventArgs e)
        {
            lblImePrezime.Text = $"{student.Ime} {student.Prezime}";
            lblBrojIndeksa.Text = student.BrojIndeksa;

            cmbDrzava.UcitajPodatke(dbContext.Drzave.ToList());
            cmbDrzava.SelectedValue = student.Grad.DrzavaId;

            cmbGrad.UcitajPodatke(dbContext.Gradovi.Where(g => g.DrzavaId == student.Grad.DrzavaId).ToList());
            cmbGrad.SelectedValue = student.GradId;

            pbProfilnaSlika.Image = Helpers.Ekstenzije.ToImage(student.Slika);
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDrzava.SelectedValue != null)
            {
                var selectedDrzava = (int)cmbDrzava.SelectedValue;
                cmbGrad.UcitajPodatke(dbContext.Gradovi.Where(g => g.DrzavaId == selectedDrzava).ToList());
            }
        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbProfilnaSlika.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbGrad.SelectedValue == null) { return; }

            student.Slika = pbProfilnaSlika.Image.ToByteArray();

            student.GradId = (int)cmbGrad.SelectedValue;

            dbContext.SaveChanges();
            this.Close();
        }
    }
}
