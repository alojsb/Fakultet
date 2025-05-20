using DLWMS.Data;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLWMS.WinApp.IspitBrojIndeksa;

namespace DLWMS.WinApp.IspitBrojIndeksa
{
    public partial class frmStudentEditBrojIndeksa : Form
    {
        private readonly DLWMSContext db = new DLWMSContext();
        private Student student;

        public frmStudentEditBrojIndeksa(Student student, DLWMSContext dbContext)
        {
            InitializeComponent();
            this.student = student;
            this.db = dbContext;
        }

        private void frmStudentEditBrojIndeksa_Load(object sender, EventArgs e)
        {
            // loadaj podatke studenta u formu radi prikaza
            lblImePrezime.Text = $"{student.Ime} {student.Prezime}";
            lblBrojIndeksa.Text = student.BrojIndeksa;

            // ucitaj drzave u combobox
            cmbDrzava.UcitajPodatke(db.Drzave.ToList());

            // prikazi drzavu studenta
            cmbDrzava.SelectedValue = student.Grad.DrzavaId;

            // ucitaj gradove odgovarajuce drzave
            var gradoviList = db.Gradovi.Where(g => g.DrzavaId == student.Grad.DrzavaId).ToList();
            cmbGrad.UcitajPodatke(gradoviList);

            // prikazi grad studenta
            cmbGrad.SelectedValue = student.GradId;

            // prikazi sliku
            pbProfilna.Image = Helpers.Ekstenzije.ToImage(student.Slika);
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDrzava.SelectedValue == null)
                return;

            // Convert the SelectedValue to an integer
            int selectedDrzavaId = (int)cmbDrzava.SelectedValue;

            // Now filter the Gradovi by DrzavaId
            var gradovi = db.Gradovi.Where(g => g.DrzavaId == selectedDrzavaId).ToList();
            cmbGrad.DataSource = gradovi;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            // validacija ovdje??

            student.Slika = Helpers.Ekstenzije.ToByteArray(pbProfilna.Image);
            student.GradId = (int)cmbGrad.SelectedValue;
            db.SaveChanges();
            this.Close();
        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbProfilna.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
