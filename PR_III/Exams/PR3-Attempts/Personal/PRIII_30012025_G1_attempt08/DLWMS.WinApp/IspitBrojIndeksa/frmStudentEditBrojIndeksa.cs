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

        public frmStudentEditBrojIndeksa(Student student, DLWMSContext db)
        {
            InitializeComponent();

            this.student = student;
            this.dbContext = db;
        }

        private void frmStudentEditBrojIndeksa_Load(object sender, EventArgs e)
        {
            lblImePrezime.Text = $"{student.Ime} {student.Prezime}";
            lblBrojIndeksa.Text = student.BrojIndeksa;

            pbSlika.Image = Helpers.Ekstenzije.ToImage(student.Slika);

            cmbDrzava.UcitajPodatke(dbContext.Drzave.ToList());
            cmbDrzava.SelectedValue = student.Grad.DrzavaId;

            cmbGrad.UcitajPodatke(dbContext.Gradovi.Where(g => g.DrzavaId == (int)cmbDrzava.SelectedValue).ToList());
            cmbGrad.SelectedValue = student.GradId;
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbGrad.UcitajPodatke(dbContext.Gradovi.Where(g => g.DrzavaId == (int)cmbDrzava.SelectedValue).ToList());
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
            if (cmbGrad.SelectedValue != null)
            {
                student.GradId = (int)cmbGrad.SelectedValue;        
            }

            student.Slika = pbSlika.Image.ToByteArray();

            dbContext.SaveChanges();
            this.Close();
        }
    }
}
