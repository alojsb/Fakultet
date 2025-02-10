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

namespace DLWMS.WinApp.IB220347
{
    public partial class frmStudentEdit : Form
    {
        private Student student;
        DLWMSContext db = new DLWMSContext();

        public frmStudentEdit(Student student)
        {
            InitializeComponent();
            this.student = student;
            cmbDrzava.DataSource = db.Drzave.ToList();
        }

        private void frmStudentEdit_Load(object sender, EventArgs e)
        {
            lblImePrezime.Text=$"{student.Ime} {student.Prezime}";
            lblIndeks.Text = $"{student.BrojIndeksa}";
            pictureBox1.Image = Ekstenzije.ToImage(student.Slika);
            var drz = cmbDrzava.SelectedValue as Drzava;
            cmbGrad.DataSource = db.Gradovi.Where(x => x.DrzavaId == drz.Id).ToList();
        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnSpasi_Click(object sender, EventArgs e)
        {
            if (Validno())
            {
                student.Slika = Helpers.Ekstenzije.ToByteArray(pictureBox1.Image);
                student.Grad = cmbGrad.SelectedValue as Grad;
                student.Grad.Drzava = cmbDrzava.SelectedValue as Drzava;
                db.Studenti.Update(student);
                db.SaveChanges();
                Close();
            }
        }

        private bool Validno()
        {
            return Helpers.Validator.ProvjeriUnos(pictureBox1, err, Kljucevi.RequiredField) &&
                Helpers.Validator.ProvjeriUnos(cmbDrzava, err, Kljucevi.RequiredField) &&
                Helpers.Validator.ProvjeriUnos(cmbGrad, err, Kljucevi.RequiredField);
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var drz = cmbDrzava.SelectedValue as Drzava;
            cmbGrad.DataSource = db.Gradovi.Where(x => x.DrzavaId == drz.Id).ToList();
        }
    }
}
