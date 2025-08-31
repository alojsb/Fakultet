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
                var student = db.Studenti.FirstOrDefault(s => s.Id == ss.StudentId);
                cmbStudent.Enabled = false;
                cmbStudent.DisplayMember = "Prikaz";
                cmbStudent.ValueMember = "Id";
                cmbStudent.DataSource = new List<Student> { student };

                // cmbGodina
                var godina = ss.StipendijaGodina.Godina;
                cmbGodina.SelectedItem = godina.ToString();

                // cmbStipendija
                UcitajStipendije();
                cmbStipendija.SelectedValue = ss.StipendijaGodina.StipendijaId;
            }
            else // add mode
            {
                // cmbStudent
                cmbStudent.UcitajPodatke(db.Studenti.ToList());
                cmbStudent.DisplayMember = "Prikaz";
                cmbStudent.ValueMember = "Id";

                // cmbGodina
                cmbGodina.SelectedIndex = 0;

                // cmbStipendija
                UcitajStipendije();
            }
        }

        private void UcitajStipendije()
        {
            if (cmbGodina.SelectedItem == null)
            {
                return;
            }

            int odabranaGodina = int.Parse(cmbGodina.SelectedItem.ToString()!);

            var stipendije = db.StipendijeGodineBrojIndeksa
                .Where(sg => sg.Godina == odabranaGodina)
                .Select(sg => sg.Stipendija)
                .ToList();

            cmbStipendija.UcitajPodatke(stipendije);
        }

        private void cmbGodina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UcitajStipendije();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            var studentId = (cmbStudent.SelectedItem as Student)?.Id;
            var stipendijaId = (cmbStipendija.SelectedItem as StipendijaBrojIndeksa)?.Id;
            var godinaText = cmbGodina.SelectedItem?.ToString();

            if (studentId is null || stipendijaId is null || string.IsNullOrWhiteSpace(godinaText))
            {
                MessageBox.Show("Molimo odaberite studenta, godinu i stipendiju.");
                return;
            }

            var godina = int.Parse(cmbGodina.SelectedItem?.ToString()!);

            var stipendijaGodina = db.StipendijeGodineBrojIndeksa
                .FirstOrDefault(sg => sg.StipendijaId == stipendijaId && sg.Godina == godina);

            bool isDuplikat = db.StudentiStipendijeBrojIndeksa
                .Any(item =>  item.StudentId == studentId &&
                            item.StipendijaGodinaId == stipendijaGodina.Id &&
                            (!isEditMode || item.Id != ss.Id));

            if (isDuplikat)
            {
                MessageBox.Show("Student već ima odabranu stipendiju za navedenu godinu.");
                return;
            }

            if (!isEditMode)  // add mode
            {
                var nova = new StudentStipendijaBrojIndeksa
                {
                    StudentId = studentId.Value,
                    StipendijaGodinaId = stipendijaGodina.Id
                };
                db.StudentiStipendijeBrojIndeksa.Add(nova);
            }
            else  // edit mode
            {
                var original = db.StudentiStipendijeBrojIndeksa.First(o => o.Id == ss.Id);
                original.StipendijaGodinaId = stipendijaGodina.Id;
            }

            db.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
