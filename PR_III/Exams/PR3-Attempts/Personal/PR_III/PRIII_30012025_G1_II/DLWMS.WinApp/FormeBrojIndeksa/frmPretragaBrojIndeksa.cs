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

namespace DLWMS.WinApp.FormeBrojIndeksa
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

            int studentiCount = _DLWMSContext.Studenti.ToList().Count;

            this.Text = $"Broj prikazanih studenata: {studentiCount}";

            //dgvStudenti.DataSource = _DLWMSContext.Studenti.ToList();
            FiltrirajStudente();
        }

        private void FiltrirajStudente()
        {
            var query = _DLWMSContext.Studenti
                .Include(s => s.Grad)
                .Include(s => s.Spol)
                .AsQueryable();

            if (cmbDrzava.SelectedIndex > -1 && cmbDrzava.SelectedValue != null)
            {
                int selectedDrzavaId = (int)cmbDrzava.SelectedValue;
                query = query.Where(s => s.Grad.DrzavaId == selectedDrzavaId);
            }

            if (cmbSpol.SelectedIndex > -1 && cmbSpol.SelectedValue != null)
            {
                query = query.Where(s => s.SpolId == (int)cmbSpol.SelectedValue);
            }

            string filterTekst = txtImeIliPrezime.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filterTekst))
            {
                query = query.Where(s => s.Ime.ToLower().Contains(filterTekst) || s.Prezime.ToLower().Contains(filterTekst));
            }

            var filtriraniStudenti = query.ToList();
            int studentiCount = filtriraniStudenti.Count;
            this.Text = $"Broj prikazanih studenata: {studentiCount}";

            if (studentiCount == 0)
            {
                dgvStudenti.DataSource = filtriraniStudenti;
                MessageBox.Show(
                        $"U bazi nisu evidentirani studenti spola {cmbSpol.Text}, koji u imenu i prezimenu posjeduju sadržaj {filterTekst}, a koji su državljani {cmbDrzava.Text}.",
                        "Info"
                    );
            }
            else
            {
                dgvStudenti.DataSource = filtriraniStudenti;
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

        private void txtImeIliPrezime_KeyUp(object sender, KeyEventArgs e)
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
                _DLWMSContext.SaveChanges();
            }
        }
    }
}
