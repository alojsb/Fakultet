using DLWMS.Data;
using DLWMS.Data.IspitBrojIndeksa;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
using Microsoft.EntityFrameworkCore;
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
    public partial class frmStipendijaAddEditBrojIndeksa : Form
    {
        DLWMSContext db;
        StudentStipendijaBrojIndeksa ss;
        bool isEditMode;

        public frmStipendijaAddEditBrojIndeksa(DLWMSContext context, StudentStipendijaBrojIndeksa studentStipendija = null)
        {
            InitializeComponent();
            db = context;
            ss = studentStipendija;
            isEditMode = studentStipendija != null;
        }

        private void frmStipendijaAddEditBrojIndeksa_Load(object sender, EventArgs e)
        {
            this.Text = "Dodjela stipendije";

            if (isEditMode)
            {
                var student = ss.Student;
                cmbStudent.DataSource = new List<Student> { student };
                cmbStudent.ValueMember = "Id";
                cmbStudent.DisplayMember = "Prikaz";
                cmbStudent.Enabled = false;

                cmbGodina.SelectedItem = ss.StipendijaGodina.Godina.ToString();

                OsvjeziStipendije();
                cmbStipendija.SelectedValue = ss.StipendijaGodina.StipendijaId;
            }
            else
            {
                cmbStudent.UcitajPodatke(db.Studenti.ToList());
                cmbStudent.DisplayMember = "Prikaz";
                cmbGodina.SelectedIndex = 0;
                OsvjeziStipendije();
            }
        }

        private void OsvjeziStipendije()
        {
            var stipendijeZaGodinu = db.StipendijeGodineBrojIndeksa
                .Include(sg => sg.Stipendija)
                .Where(sg => sg.Godina == int.Parse(cmbGodina.SelectedItem.ToString()!))
                .Select(sg => sg.Stipendija)
                .ToList();
            cmbStipendija.UcitajPodatke(stipendijeZaGodinu);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            var studentId = cmbStudent.SelectedValue as int?;
            var godinaText = cmbGodina.SelectedItem.ToString();
            var stipendijaId = cmbStipendija.SelectedValue as int?;

            if (studentId == null || stipendijaId == null || string.IsNullOrWhiteSpace(godinaText))
            {
                MessageBox.Show("Molimo unesite vrijednosti za polja student, godina i stipendija.");
                return;
            }

            var godina = int.Parse(godinaText);

            var stipendijaGodina = db.StipendijeGodineBrojIndeksa
                .FirstOrDefault(sg => sg.StipendijaId == stipendijaId && sg.Godina == godina);

            bool isDuplikat = db.StudentiStipendijeBrojIndeksa
                .Any(item => item.StudentId == studentId && item.StipendijaGodinaId == stipendijaGodina.Id &&
                        (!isEditMode || item.Id != ss.Id));

            if (isDuplikat)
            {
                MessageBox.Show("Za studenta već postoji zapis o odabranoj stipendiji.");
                return;
            }

            if (isEditMode)
            {
                ss.StipendijaGodinaId = stipendijaGodina.Id;
            }
            else
            {
                var novaStudentStipendija = new StudentStipendijaBrojIndeksa
                {
                    StudentId = studentId.Value,
                    StipendijaGodinaId = stipendijaGodina.Id
                };
                db.StudentiStipendijeBrojIndeksa.Add(novaStudentStipendija);
            }
            db.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmbGodina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OsvjeziStipendije();
        }
    }
}
