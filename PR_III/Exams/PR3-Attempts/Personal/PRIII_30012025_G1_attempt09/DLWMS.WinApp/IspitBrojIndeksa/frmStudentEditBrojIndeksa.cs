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
        private Student student;
        private DLWMSContext db;

        public frmStudentEditBrojIndeksa(Student student, DLWMSContext db)
        {
            InitializeComponent();

            this.student = student;
            this.db = db;
        }

        private void frmStudentEditBrojIndeksa_Load(object sender, EventArgs e)
        {
            pbSlika.Image = student.Slika.ToImage();

            lblImePrezime.Text = $"{student.Ime} {student.Prezime}";

            lblIndeks.Text = student.BrojIndeksa.ToString();

            cmbDrzava.UcitajPodatke(db.Drzave.ToList());
            cmbDrzava.SelectedValue = student.Grad.DrzavaId;

            OsvjeziListuGradova();
            cmbGrad.SelectedValue = student.GradId;
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OsvjeziListuGradova();
        }

        private void OsvjeziListuGradova()
        {
            if (cmbDrzava.SelectedValue != null)
            {
                cmbGrad.UcitajPodatke(db.Gradovi.Where(g => g.DrzavaId == (int)cmbDrzava.SelectedValue).ToList());
            }
        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbSlika.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            //student.Slika = Helpers.Ekstenzije.ToByteArray(pbSlika.Image);
            student.Slika = pbSlika.Image.ToByteArray();

            if (cmbGrad.SelectedValue != null)
            {
                student.GradId = (int)cmbGrad.SelectedValue;
            }

            db.SaveChanges();
            this.Close();
        }
    }
}
