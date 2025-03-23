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
    public partial class frmRazmjeneBrojIndeksa : Form
    {
        private DLWMSContext _dbContext = new DLWMSContext();
        private Student _student = new Student();

        public frmRazmjeneBrojIndeksa(Student st, DLWMSContext db)
        {
            this._student = st;
            this._dbContext = db;
            InitializeComponent();
            dgvRazmjene.AutoGenerateColumns = false;
            dgvRazmjene.CellFormatting += dgvRazmjene_CellFormatting;
        }

        private void frmRazmjeneBrojIndeksa_Load(object sender, EventArgs e)
        {
            this.Text = $"Razmjene studenta: ({_student.BrojIndeksa}) {_student.Ime} {_student.Prezime}";

            UcitajDrzave();
            cmbDrzava.SelectedIndex = -1;

            UcitajUniverzitete();
            //cmbUniverzitet.SelectedIndex = -1;

            UcitajRazmjene();
        }

        private void UcitajRazmjene()
        {
            dgvRazmjene.DataSource = _dbContext.Razmjene
                .Include(r => r.Univerzitet)
                .ThenInclude(r => r.Drzava)
                .Where(r => r.Student.Id == _student.Id)
                .ToList();
        }

        private void dgvRazmjene_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var razmjena = dgvRazmjene.Rows[e.RowIndex].DataBoundItem as Razmjena;
            var colName = dgvRazmjene.Columns[e.ColumnIndex].Name;

            if (colName == "colUniverzitet")
            {
                e.Value = $"{razmjena.Univerzitet.Naziv} ({razmjena.Univerzitet.Drzava.Naziv})";
            }
            else if (colName == "colPocetak")
            {
                e.Value = razmjena.PocetakRazmjene.ToString("dd.MM.yyyy.");
            }
            else if (colName == "colKraj")
            {
                e.Value = razmjena.KrajRazmjene.ToString("dd.MM.yyyy.");
            }
            else if (colName == "colECTS")
            {
                e.Value = razmjena.ECTS;
            }

            colOkoncana.DataPropertyName = "Okoncana";
        }

        private void UcitajDrzave()
        {
            cmbDrzava.UcitajPodatke(_dbContext.Drzave.ToList());
        }

        private void UcitajUniverzitete()
        {
            if (cmbDrzava.SelectedIndex >= 0)
            {
                int selectedDrzavaId = (int)cmbDrzava.SelectedValue;
                cmbUniverzitet.UcitajPodatke(_dbContext.Univerziteti.Where(u => u.DrzavaId == selectedDrzavaId).ToList());
            }
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UcitajUniverzitete();
        }

        private bool ValidacijaUnosa()
        {
            if (cmbDrzava.SelectedIndex == -1 || cmbUniverzitet.SelectedIndex == -1)
            {
                MessageBox.Show("Unos drzave i univerziteta obligatoran.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtECTS.Text) || !int.TryParse(txtECTS.Text, out int ects) || ects <= 0)
            {
                MessageBox.Show("Unos validne vrijednosti ECTS kredita obligatoran.");
                return false;
            }

            return true;
        }

        private bool ValidacijaHronologijeDatuma()
        {
            if (dtpKraj.Value <= dtpPocetak.Value)
            {
                MessageBox.Show("Datum početka mora biti prije datuma kraja.");
                return false;
            }

            return true;
        }

        private bool ValidacijaPerioda()
        {
            var postojeceRazmjeneStudenta = _dbContext.Razmjene.Where(r => r.StudentId == _student.Id).ToList();

            foreach (var razm in postojeceRazmjeneStudenta)
            {
                if (dtpPocetak.Value <= razm.KrajRazmjene && razm.PocetakRazmjene <= dtpKraj.Value)
                {
                    MessageBox.Show("Uneseni period se poklapa sa periodom postojeće razmjene.");
                    return false;
                }
            }

            return true;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidacijaUnosa() && ValidacijaHronologijeDatuma() && ValidacijaPerioda()) // validacija
            {
                var newRazmjena = new Razmjena
                {
                    StudentId = _student.Id,
                    UniverzitetId = (int)cmbUniverzitet.SelectedValue,
                    PocetakRazmjene = dtpPocetak.Value,
                    KrajRazmjene = dtpKraj.Value,
                    ECTS = int.Parse(txtECTS.Text),
                    IsOkoncana = dtpKraj.Value < DateTime.Now
                };

                _dbContext.Razmjene.Add(newRazmjena);
                _dbContext.SaveChanges();
                MessageBox.Show("Razmjena uspješno spašena.", "Info");

                UcitajRazmjene();
            }
        }

        private void dgvRazmjene_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRazmjene.Columns[e.ColumnIndex].Name == "colObrisi")
            {
                var razmjena = dgvRazmjene.Rows[e.RowIndex].DataBoundItem as Razmjena;
                
                var confirm = MessageBox.Show($"Da li ste sigurni da želite obrisati podatke o razmjeni ({razmjena.Student.BrojIndeksa}) {razmjena.Student.Ime} {razmjena.Student.Prezime} na {razmjena.Univerzitet.Naziv} ({razmjena.Univerzitet.Drzava.Naziv})", "Upit", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    _dbContext.Remove(razmjena);
                    _dbContext.SaveChanges();

                    UcitajRazmjene();
                }
            }
        }
    }
}
