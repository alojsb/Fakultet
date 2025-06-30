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
        DLWMSContext db = new DLWMSContext();

        public frmPretragaBrojIndeksa()
        {
            InitializeComponent();

            dgvStudenti.AutoGenerateColumns = false;
            dgvStudenti.CellFormatting += dgvStudenti_CellFormatting;
        }

        private void frmPretragaBrojIndeksa_Load(object sender, EventArgs e)
        {
            cmbDrzava.UcitajPodatke(db.Drzave.ToList());
            cmbSpol.UcitajPodatke(db.SpoloviBrojIndeksa.ToList());

            FiltrirajStudente();
        }

        private void FiltrirajStudente()
        {
            var query = db.Studenti
                .Include(s => s.Grad)
                .ThenInclude(g => g.Drzava)
                .Include(s => s.Spol)
                .AsQueryable();

            if (cmbDrzava.SelectedIndex >= 0 && cmbDrzava.SelectedValue != null)
            {
                query = query.Where(s => s.Grad.DrzavaId == (int)cmbDrzava.SelectedValue);
            }

            if (cmbSpol.SelectedIndex >= 0 && cmbSpol.SelectedValue != null)
            {
                query = query.Where(s => s.SpolId == (int)cmbSpol.SelectedValue);
            }

            var pretragaImePrezime = txtImePrezime.Text.Trim().ToLower();

            query = query.Where(s => s.Ime.ToLower().Contains(pretragaImePrezime) || s.Prezime.ToLower().Contains(pretragaImePrezime));

            this.Text = $"Broj prikazanih studenata: {query.Count()}";

            if (query.Count() == 0)
            {
                MessageBox.Show($"U bazi nisu evidentirani studenti spola {cmbSpol.Text}, koji u imenu i prezimenu posjeduju sadržaj {txtImePrezime.Text}, a koji su državljani {cmbDrzava.Text}.", "Obavijest", MessageBoxButtons.OK);
            }

            dgvStudenti.DataSource = query.ToList();
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
            var kolona = dgvStudenti.Columns[e.ColumnIndex].Name;
            var student = dgvStudenti.Rows[e.RowIndex].DataBoundItem as Student;

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
        }
    }
}
