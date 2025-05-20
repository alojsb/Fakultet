using DLWMS.Data;
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
    public partial class frmPretragaBrojIndeksa : Form
    {
        private DLWMSContext dbContext = new DLWMSContext();

        public frmPretragaBrojIndeksa()
        {
            InitializeComponent();
            dgvStudenti.AutoGenerateColumns = false;
            dgvStudenti.CellFormatting += dgvStudenti_CellFormatting;
        }

        private void frmPretragaBrojIndeksa_Load(object sender, EventArgs e)
        {
            cmbDrzava.UcitajPodatke(dbContext.Drzave.ToList());
            cmbDrzava.SelectedIndex = -1;
            cmbSpol.UcitajPodatke(dbContext.Spolovi.ToList());
            cmbSpol.SelectedIndex = -1;

            //dgvStudenti.DataSource = dbContext.Studenti.ToList();
            FiltrirajStudente();
        }

        private void FiltrirajStudente()
        {
            var query = dbContext.Studenti
                .Include(s => s.Grad)
                .Include(s => s.Spol)
                .AsQueryable();

            if (cmbDrzava.SelectedIndex >= 0 && cmbDrzava.SelectedValue != null)
            {
                int selectedDrzavaId = (int)cmbDrzava.SelectedValue;
                query = query.Where(s => s.Grad.DrzavaId == selectedDrzavaId);
            }

            if (cmbSpol.SelectedIndex >= 0 && cmbSpol.SelectedValue != null)
            {
                int selectedSpolId = (int)cmbSpol.SelectedValue;
                query = query.Where(s => s.SpolId == selectedSpolId);
            }

            string filterText = txtImePrezime.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(filterText))
            {
                query = query.Where(s => s.Ime.ToLower().Contains(filterText) || s.Prezime.ToLower().Contains(filterText));
            }

            int brojRezultata = query.ToList().Count();
            this.Text = $"Broj prokazanih studenata: {brojRezultata}";
            dgvStudenti.DataSource = query.ToList();

            if (brojRezultata == 0)
            {
                MessageBox.Show($"U bazi nisu evidentirani studenti spola {cmbSpol.Text}, koji u imenu i prezimenu posjeduju sadržaj {txtImePrezime.Text}, a koji su državljani {cmbDrzava.Text}");
            }

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
            var colName = dgvStudenti.Columns[e.ColumnIndex].Name;

            if (colName == "colIndeksImePrezime")
            {
                e.Value = $"({student.BrojIndeksa}) {student.Ime} {student.Prezime}";
            }
            else if (colName == "colDrzava")
            {
                e.Value = student.Grad.Drzava.Naziv;
            }
            else if (colName == "colGrad")
            {
                e.Value = student.Grad.Naziv;
            }
            else if (colName == "colSpol")
            {
                e.Value = student.Spol.Naziv;
            }
            colAktivan.DataPropertyName = "Aktivan";
        }

        private void dgvStudenti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudenti.Columns[e.ColumnIndex].Name == "colAktivan")
            {
                dgvStudenti.EndEdit();
                dbContext.SaveChanges();
            }
        }
    }
}
