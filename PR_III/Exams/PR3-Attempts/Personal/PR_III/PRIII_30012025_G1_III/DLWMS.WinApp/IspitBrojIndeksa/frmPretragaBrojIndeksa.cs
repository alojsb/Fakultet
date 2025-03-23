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
        DLWMSContext _DLWMSContext = new DLWMSContext();

        public frmPretragaBrojIndeksa()
        {
            InitializeComponent();
            dgvStudenti.AutoGenerateColumns = false;
            dgvStudenti.CellFormatting += dgvStudenti_CellFormatting;
        }

        private void frmPretragaBrojIndeksa_Load(object sender, EventArgs e)
        {
            cmbDrzava.UcitajPodatke(_DLWMSContext.Drzave.ToList());
            cmbDrzava.SelectedIndex = -1;
            cmbSpol.UcitajPodatke(_DLWMSContext.Spolovi.ToList());
            cmbSpol.SelectedIndex = -1;
            FiltrirajStudente();
        }

        public void FiltrirajStudente()
        {
            var query = _DLWMSContext.Studenti
                .Include(s => s.Grad.Drzava)
                .Include(s => s.Spol)
                .AsQueryable();

            if (cmbDrzava.SelectedIndex > -1 && cmbDrzava.SelectedValue != null)
            {
                var selectedDrzavaId = (int)cmbDrzava.SelectedValue;
                query = query.Where(s => s.Grad.DrzavaId == selectedDrzavaId);
            }

            if (cmbSpol.SelectedIndex > -1 && cmbSpol.SelectedValue != null)
            {
                var selectedSpolId = (int)cmbSpol.SelectedValue;
                query = query.Where(s => s.SpolId == selectedSpolId);
            }

            if (!string.IsNullOrWhiteSpace(txtImePrezime.Text))
            {
                var textFilter = txtImePrezime.Text.Trim().ToLower();
                query = query.Where(s => s.Ime.ToLower().Contains(textFilter) || s.Prezime.ToLower().Contains(textFilter));
            }

            var brojRezultata = query.ToList().Count;
            if (brojRezultata == 0)
            {
                this.Text = $"Broj prikazanih studenata: {brojRezultata}";
                dgvStudenti.DataSource = query.ToList();
                MessageBox.Show($"U bazi nisu evidentirani studenti spola {cmbSpol.Text}, koji u imenu i prezimenu posjeduju sadržaj {txtImePrezime.Text}, a koji su državljani {cmbDrzava.Text}");
            }
            else
            {
                this.Text = $"Broj prikazanih studenata: {brojRezultata}";
                dgvStudenti.DataSource = query.ToList();
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
            var studentRow = dgvStudenti.Rows[e.RowIndex].DataBoundItem as Student;
            var colName = dgvStudenti.Columns[e.ColumnIndex].Name;

            //System.Diagnostics.Debug.WriteLine("Formatting cell...");

            if (colName == "colIndeksImePrezime")
            {
                e.Value = $"({studentRow.BrojIndeksa}) {studentRow.Ime} {studentRow.Prezime}";
            }
            else if (colName == "colDrzava")
            {
                e.Value = studentRow.Grad.Drzava.Naziv;
            }
            else if (colName == "colGrad")
            {
                e.Value = studentRow.Grad.Naziv;
            }
            else if (colName == "colSpol")
            {
                e.Value = studentRow.Spol.Naziv;
            }
            colAktivan.DataPropertyName = "Aktivan";
        }

        private void dgvStudenti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && dgvStudenti.Columns[e.ColumnIndex].Name == "colAktivan")
            if (e.RowIndex >= 0 && dgvStudenti.Columns[e.ColumnIndex].Name == "colAktivan")
            {
                //dgvStudenti.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dgvStudenti.EndEdit();
                _DLWMSContext.SaveChanges();
            }
        }
    }
}
