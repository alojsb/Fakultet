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
        List<Student> StudentiPodaci = new List<Student>();

        public frmPretragaBrojIndeksa()
        {
            InitializeComponent();

            dgvStudenti.AutoGenerateColumns = false;
        }

        private void frmPretragaBrojIndeksa_Load(object sender, EventArgs e)
        {
            cmbDrzava.UcitajPodatke(db.Drzave.ToList());
            cmbDrzava.SelectedIndex = -1;
            cmbSpol.UcitajPodatke(db.SpoloviBrojIndeksa.ToList());
            cmbSpol.SelectedIndex = -1;

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
                query = query.Where(s => s.Spol.Id == (int)cmbSpol.SelectedValue);
            }

            var tekstPretraga = txtImePrezime.Text.ToLower().Trim();
            query = query.Where(s => s.Ime.ToLower().Contains(tekstPretraga) || s.Prezime.ToLower().Contains(tekstPretraga));

            StudentiPodaci = query.ToList();

            this.Text = $"Broj prikazanih studenata: {StudentiPodaci.Count()}";

            if (StudentiPodaci.Count == 0)
            {
                dgvStudenti.DataSource = null;
                MessageBox.Show($"U bazi nisu evidentirani studenti spola {cmbSpol.Text}, koji u imenu i prezimenu posjeduju sadržaj {txtImePrezime.Text}, a koji su državljani {cmbDrzava.Text}.", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var Tabela = new DataTable();
            Tabela.Columns.Add("ImePrezime");
            Tabela.Columns.Add("Drzava");
            Tabela.Columns.Add("Grad");
            Tabela.Columns.Add("Spol");
            Tabela.Columns.Add("Aktivan");


            for (int i = 0; i < StudentiPodaci.Count(); i++)
            {
                var student = StudentiPodaci[i];
                var Red = Tabela.NewRow();

                Red["ImePrezime"] = $"({student.BrojIndeksa}) {student.Ime} {student.Prezime}";
                Red["Drzava"] = student.Grad.Drzava.Naziv;
                Red["Grad"] = student.Grad.Naziv;
                Red["Spol"] = student.Spol.Naziv;
                Red["Aktivan"] = student.Aktivan;

                Tabela.Rows.Add(Red);
            }

            dgvStudenti.DataSource = null;
            dgvStudenti.DataSource = Tabela;
        }

        private void cmbSpol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltrirajStudente();
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltrirajStudente();
        }

        private void txtImePrezime_KeyUp(object sender, KeyEventArgs e)
        {
            FiltrirajStudente();
        }

        private void dgvStudenti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 && dgvStudenti.Columns[e.ColumnIndex].Name == "Aktivan")
            {
                dgvStudenti.EndEdit();
                db.SaveChanges();
            }
        }
    }
}
