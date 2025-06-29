using DLWMS.Data;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
using DocumentFormat.OpenXml.InkML;
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
    public partial class frmPretragaBrojIndeksa : Form
    {
        DLWMSContext db = new DLWMSContext();

        public frmPretragaBrojIndeksa()
        {
            InitializeComponent();
            dgvStudenti.AutoGenerateColumns = false;
            dgvStudenti.CellFormatting += dgvStudenti_CellFormatting;
        }

        void FiltrirajStudente()
        {
            var query = db.Studenti.Include(s => s.Grad).Include(s => s.Spol).AsQueryable();

            if (cmbDrzava.SelectedIndex >= 0 && cmbDrzava.SelectedValue != null)
            {
                query = query.Where(s => s.Grad.DrzavaId == (int)cmbDrzava.SelectedValue);
            }

            if (cmbSpol.SelectedIndex >= 0 && cmbSpol.SelectedValue != null)
            {
                query = query.Where(s => s.Spol.Id == (int)cmbSpol.SelectedValue);
            }

            var pretragaImePrezime = txtImePrezime.Text.ToLower().Trim();
            query = query.Where((s) => s.Ime.ToLower().Trim().Contains(pretragaImePrezime));

            this.Text = $"Broj prikazanih studenata: {query.ToList().Count()}";

            dgvStudenti.DataSource = query.ToList();

            colAktivan.DataPropertyName = "Aktivan";

            if (query.ToList().Count() == 0)
            {
                MessageBox.Show($"U bazi nisu evidentirani studenti spola {cmbSpol.Text}, koji u imenu i prezimenu posjeduju sadržaj {pretragaImePrezime}, a koji su državljani {cmbDrzava.Text}");
            }
        }

        private void frmPretragaBrojIndeksa_Load(object sender, EventArgs e)
        {
            cmbDrzava.UcitajPodatke(db.Drzave.ToList());
            cmbDrzava.SelectedIndex = -1;

            cmbSpol.UcitajPodatke(db.SpoloviBrojIndeksa.ToList());
            cmbSpol.SelectedIndex = -1;

            FiltrirajStudente();
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltrirajStudente();
        }

        private void cmbSpol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltrirajStudente();
        }

        private void txtImePrezime_KeyUp(object sender, KeyEventArgs e)
        {
            FiltrirajStudente();
        }

        private void dgvStudenti_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var student = dgvStudenti.Rows[e.RowIndex].DataBoundItem as Student;
            var kolona = dgvStudenti.Columns[e.ColumnIndex].Name;

            if (student != null)
            {
                if (kolona == "colImePrezime")
                {
                    e.Value = $"({student.BrojIndeksa}) {student.Ime} {student.Prezime}";
                }
                else if (kolona == "colDrzava")
                {
                    e.Value = student.Grad.Drzava.Naziv;
                }
                else if (kolona == "colGrad")
                {
                    e.Value = student.Grad.Naziv;
                }
                else if (kolona == "colSpol")
                {
                    e.Value = student.Spol.Naziv;
                }
            }
        }

        private void dgvStudenti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudenti.Columns[e.ColumnIndex].Name == "colAktivan")
            {
                dgvStudenti.EndEdit();
                db.SaveChanges();
            }

            if (e.RowIndex >= 0 && dgvStudenti.Columns[e.ColumnIndex].Name == "colRazmjene")
            {
                var studentItem = (Student)dgvStudenti.Rows[e.RowIndex].DataBoundItem;

                var frmRazmjene = new frmRazmjeneBrojIndeksa(studentItem, db);
                frmRazmjene.ShowDialog();
            }
        }

        private void dgvStudenti_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var studentItem = (Student)dgvStudenti.Rows[e.RowIndex].DataBoundItem;

            var frmStudentEdit = new frmStudentEditBrojIndeksa(studentItem, db);
            frmStudentEdit.ShowDialog();

            FiltrirajStudente();
        }
    }
}
