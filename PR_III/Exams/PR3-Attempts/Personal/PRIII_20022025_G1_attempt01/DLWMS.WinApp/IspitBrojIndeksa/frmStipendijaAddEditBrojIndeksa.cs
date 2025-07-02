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
        private StudentStipendijaBrojIndeksa model;
        DLWMSContext db = new DLWMSContext();
        private bool editMode = false;

        public frmStipendijaAddEditBrojIndeksa(StudentStipendijaBrojIndeksa? studStip = null)
        {
            InitializeComponent();
            this.model = studStip ?? new StudentStipendijaBrojIndeksa();
            this.editMode = studStip != null;

            if (editMode)
            {
                this.model = db.StudentiStipendijeBrojIndeksa
                    .Include(ss => ss.StipendijaGodina)
                    .FirstOrDefault(ss => ss.Id == model.Id);
            }
        }

        private void frmStipendijaAddEditBrojIndeksa_Load(object sender, EventArgs e)
        {
            if (!editMode) // Add Mode
            {
                cmbStudent.Enabled = true;
                cmbStudent.DisplayMember = "Prikaz";
                cmbStudent.ValueMember = "Id";
                cmbStudent.DataSource = db.Studenti.ToList();

            }
            else // Edit Mode
            {
                cmbStudent.Enabled = false;
                cmbStudent.DisplayMember = "Prikaz";
                cmbStudent.ValueMember = "Id";
                var student = db.Studenti.FirstOrDefault(s => s.Id == model.StudentId);
                cmbStudent.DataSource = new List<Student> { student };
            }

            cmbGodina.SelectedIndex = 0;
            if (cmbGodina.SelectedValue != null)
                StipendijeZaOdabranuGodinu(int.Parse(cmbGodina.SelectedItem.ToString()));

            if (editMode)
            {
                cmbStipendija.SelectedValue = model.StipendijaGodina.Id;
            }
        }

        private void StipendijeZaOdabranuGodinu(int godina)
        {
            var stipendijeZaGodinu = db.StipendijeGodineBrojIndeksa
                .Include(sg => sg.Stipendija)
                .Where(sg => sg.Godina == godina)
                .ToList();

            cmbStipendija.DisplayMember = nameof(StipendijaBrojIndeksa.Naziv);
            cmbStipendija.ValueMember = "Id";
            cmbStipendija.DataSource = stipendijeZaGodinu.Select(sg => sg.Stipendija).ToList();
        }


        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            var studentId = (cmbStudent.SelectedItem as Student)?.Id;
            var stipendijaId = (cmbStipendija.SelectedItem as StipendijaBrojIndeksa)?.Id;
            var godina = int.Parse(cmbGodina.SelectedItem.ToString());

            var stipendijaGodina = db.StipendijeGodineBrojIndeksa
                .FirstOrDefault(s => s.StipendijaId == stipendijaId && s.Godina == godina);

            bool duplikat = db.StudentiStipendijeBrojIndeksa
                .Any(ss =>  ss.StudentId == studentId &&
                            ss.StipendijaGodinaId == stipendijaGodina.Id);

            if (duplikat)
            {
                MessageBox.Show("Student već ima ovu stipendiju za izabranu godinu.");
                return;
            }

            if (!editMode)
            {
                // New
                var nova = new StudentStipendijaBrojIndeksa
                {
                    StudentId = studentId.Value,
                    StipendijaGodinaId = stipendijaGodina.Id
                };

                db.StudentiStipendijeBrojIndeksa.Add(nova);
            }
            else
            {
                // Edit
                var original = db.StudentiStipendijeBrojIndeksa
                    .FirstOrDefault(ss => ss.Id == model.Id);

                if (original != null)
                {
                    original.StipendijaGodinaId = stipendijaGodina.Id;
                }
            }

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }

        private void cmbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGodina.SelectedItem != null && int.TryParse(cmbGodina.SelectedItem.ToString(), out int godina))
                StipendijeZaOdabranuGodinu(godina);
        }

    }
}
