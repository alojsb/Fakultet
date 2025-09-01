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

            if (isEditMode) // edit mode
            {
                // cmbStudent
                var student = ss.Student as Student;
                cmbStudent.DisplayMember = "Prikaz";
                cmbStudent.ValueMember = "Id";
                cmbStudent.DataSource = new List<Student> { student };
                cmbStudent.Enabled = false;

                // cmbGodina
                cmbGodina.SelectedItem = ss.StipendijaGodina.Godina.ToString();

                // cmbStipendija
                OsvjeziStipendije();
                cmbStipendija.SelectedValue = ss.StipendijaGodina.StipendijaId;
            }
            else // add mode
            {
                // cmbStudent
                cmbStudent.UcitajPodatke(db.Studenti.ToList());
                cmbStudent.DisplayMember = "Prikaz";

                // cmbGodina
                cmbGodina.SelectedIndex = 0;

                // cmbStipendija
                OsvjeziStipendije();
            }
        }

        private void OsvjeziStipendije()
        {
            if (cmbGodina.SelectedItem == null) return;

            var stipendijeZaGodinu = db.StipendijeGodineBrojIndeksa
                //.Include(sg => sg.Stipendija)
                .Where(sg => sg.Godina == int.Parse(cmbGodina.SelectedItem.ToString()!))
                .Select(sg => sg.Stipendija)
                .Distinct()
                .ToList();

            cmbStipendija.UcitajPodatke(stipendijeZaGodinu);
        }

        private void cmbGodina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OsvjeziStipendije();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            var studentId = cmbStudent.SelectedValue as int?;
            var godinaText = cmbGodina.SelectedItem?.ToString();
            var stipendijaId = cmbStipendija.SelectedValue as int?;

            if (studentId == null || stipendijaId == null || string.IsNullOrWhiteSpace(godinaText))
            {
                MessageBox.Show("Molimo unesite vrijednosti za studenta, godinu i stipendiju.");
                return;
            }

            var godina = int.Parse(godinaText);

            var stipendijaGodina = db.StipendijeGodineBrojIndeksa
                .FirstOrDefault(sg => sg.Godina == godina && sg.StipendijaId == stipendijaId);

            bool isDuplikat = db.StudentiStipendijeBrojIndeksa
                .Any(item => item.StudentId == studentId && item.StipendijaGodinaId == stipendijaGodina.Id &&
                (!isEditMode || item.Id != ss.Id));

            if (isDuplikat)
            {
                MessageBox.Show("Postoji već odabrana stipendija za navedenog studenta.");
                return;
            }

            if (isEditMode) // edit mode
            {
                ss.StipendijaGodinaId = stipendijaGodina.Id;
            }
            else // add mode
            {
                var nova = new StudentStipendijaBrojIndeksa
                {
                    StudentId = studentId.Value,
                    StipendijaGodinaId = stipendijaGodina.Id
                };
                db.StudentiStipendijeBrojIndeksa.Add(nova);
            }

            db.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
