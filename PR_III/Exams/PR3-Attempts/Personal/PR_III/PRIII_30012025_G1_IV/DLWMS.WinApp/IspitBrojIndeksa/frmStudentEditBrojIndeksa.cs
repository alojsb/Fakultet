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
        private DLWMSContext _context = new DLWMSContext();
        private Student _student = new Student();

        public frmStudentEditBrojIndeksa(Student st, DLWMSContext db)
        {
            this._context = db;
            this._student = st;
            InitializeComponent();
        }

        private void frmStudentEditBrojIndeksa_Load(object sender, EventArgs e)
        {
            this.Text = "Podaci o studentu:";

            lblImePrezime.Text = $"{_student.Ime} {_student.Prezime}";
            lblBrojIndeksa.Text = _student.BrojIndeksa;

            UcitajDrzave();
            cmbDrzava.SelectedValue = _student.Grad.DrzavaId;

            UcitajGradove();
            cmbGrad.SelectedValue = _student.GradId;

            pbSlika.Image = Helpers.Ekstenzije.ToImage(_student.Slika);
        }

        private void UcitajGradove()
        {
            int selectedDrzavaId = (int)cmbDrzava.SelectedValue;
            cmbGrad.UcitajPodatke(_context.Gradovi.Where(g => g.DrzavaId == selectedDrzavaId).ToList());
        }

        private void UcitajDrzave()
        {
            cmbDrzava.UcitajPodatke(_context.Drzave.ToList());
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

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbGrad.SelectedIndex >= 0)
            {
                _student.GradId = (int)cmbGrad.SelectedValue;
            }

            if (pbSlika.Image != null)
            {
                _student.Slika = pbSlika.Image.ToByteArray();
            }

            _context.SaveChanges();
            this.Close();
        }
    }
}
