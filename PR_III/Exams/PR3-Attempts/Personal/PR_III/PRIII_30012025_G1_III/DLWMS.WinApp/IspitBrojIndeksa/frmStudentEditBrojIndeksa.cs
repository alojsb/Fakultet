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
        private DLWMSContext dbContext = new DLWMSContext();
        private Student student = new Student();

        public frmStudentEditBrojIndeksa(Student st, DLWMSContext db)
        {
            this.student = st;
            this.dbContext = db;
            InitializeComponent();
        }

        private void frmStudentEditBrojIndeksa_Load(object sender, EventArgs e)
        {
            this.Text = "Podaci o studentu";

            lblImePrezime.Text = $"{student.Ime} {student.Prezime}";
            lblIndeks.Text = $"{student.BrojIndeksa}";

            UcitajDrzave();
            cmbDrzava.SelectedValue = student.Grad.DrzavaId;

            UcitajGradove();
            cmbGrad.SelectedValue = student.GradId;

            pbSlika.Image = Helpers.Ekstenzije.ToImage(student.Slika);
        }

        private void UcitajDrzave()
        {
            cmbDrzava.UcitajPodatke(dbContext.Drzave.ToList());
        }

        private void UcitajGradove()
        {
            if (cmbDrzava.SelectedValue != null)
            {
                int selectedDrzavaId = (int)cmbDrzava.SelectedValue;
                cmbGrad.UcitajPodatke(dbContext.Gradovi.Where(g => g.DrzavaId == selectedDrzavaId).ToList());
            }

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbGrad.SelectedIndex >= 0)
            {
                student.Slika = Helpers.Ekstenzije.ToByteArray(pbSlika.Image);

                student.GradId = (int)cmbGrad.SelectedValue;

                dbContext.SaveChanges();
                this.Close();
            }
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UcitajGradove();
        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbSlika.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
