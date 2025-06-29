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
    public partial class frmRazmjeneBrojIndeksa : Form
    {
        DLWMSContext dbContext = new DLWMSContext();
        Student student = new Student();
        public frmRazmjeneBrojIndeksa(Student st, DLWMSContext db)
        {
            student = st;
            dbContext = db;
            InitializeComponent();
            dgvRazmjene.AutoGenerateColumns = false;
            dgvRazmjene.CellFormatting += dgvRazmjene_CellFormatting;
        }

        private void frmRazmjeneBrojIndeksa_Load(object sender, EventArgs e)
        {
            this.Text = $"Razmjene studenta ({student.BrojIndeksa}) {student.Ime} {student.Prezime}";

            cmbDrzava.UcitajPodatke(dbContext.Drzave.ToList());

            var selectedDrzavaId = (int)cmbDrzava.SelectedValue;

            cmbUniverzitet.UcitajPodatke(dbContext.UniverzitetiBrojIndeksa.Where(u => u.DrzavaId == selectedDrzavaId).ToList());

            OsvjeziRazmjene();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtECTS.Text) || int.Parse(txtECTS.Text) < 0)
            {
                MessageBox.Show("Molimo unesite validnu vrijednost za ECTS kredit.", "Upozorenje");
                return;
            }

            if (dtpPocetak.Value > dtpKraj.Value)
            {
                MessageBox.Show("Datum kraja razmjene ne može biti ispred datuma početka.", "Upozorenje");
                return;
            }

            if (!ValidanPeriodRazmjene())
            {
                MessageBox.Show("Period razmjene se poklapa sa periodom postojeće razmjene.", "Upozorenje");
                return;
            }

            var novaRazmjena = new RazmjenaBrojIndeksa
            {
                StudentId = student.Id,
                UniverzitetId = (int)cmbUniverzitet.SelectedValue,
                PocetakRazmjene = dtpPocetak.Value,
                KrajRazmjene = dtpKraj.Value,
                ECTS = int.Parse(txtECTS.Text),
                IsOkoncana = dtpKraj.Value <= DateTime.Now
            };

            dbContext.RazmjeneBrojIndeksa.Add(novaRazmjena);
            dbContext.SaveChanges();

            OsvjeziRazmjene();
        }

        private void OsvjeziRazmjene()
        {
            dgvRazmjene.DataSource = dbContext.RazmjeneBrojIndeksa.Where(r => r.StudentId == student.Id).ToList();

            colOkoncana.DataPropertyName = "IsOkoncana";
        }

        private bool ValidanPeriodRazmjene()
        {
            var postojeceRazmjene = dbContext.RazmjeneBrojIndeksa.Where(r => r.StudentId == student.Id).ToList();

            foreach (var raz in postojeceRazmjene)
            {
                if (dtpPocetak.Value <= raz.KrajRazmjene && dtpKraj.Value >= raz.PocetakRazmjene)
                {
                    return false;
                }
            }

            return true;
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedDrzavaId = (int)cmbDrzava.SelectedValue;

            cmbUniverzitet.UcitajPodatke(dbContext.UniverzitetiBrojIndeksa.Where(u => u.DrzavaId == selectedDrzavaId).ToList());
        }

        private void dgvRazmjene_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRazmjene.Columns[e.ColumnIndex].Name == "colObrisi")
            {
                var selectedRazmjena = (RazmjenaBrojIndeksa)dgvRazmjene.Rows[e.RowIndex].DataBoundItem;

                var confirmDeletion = MessageBox.Show(
    $"Da li ste sigurni da želite obrisati podatke o razmjeni ({student.BrojIndeksa}) {student.Ime} {student.Prezime} na {selectedRazmjena.Univerzitet.Naziv} ({selectedRazmjena.Univerzitet.Drzava.Naziv})",
    "Upit", MessageBoxButtons.YesNo);

                if (confirmDeletion == DialogResult.Yes)
                {
                    dbContext.RazmjeneBrojIndeksa.Remove(selectedRazmjena);
                    dbContext.SaveChanges();
                    OsvjeziRazmjene();
                }
            }
        }

        private void dgvRazmjene_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var razmjena = (RazmjenaBrojIndeksa)dgvRazmjene.Rows[e.RowIndex].DataBoundItem;
            var kolona = dgvRazmjene.Columns[e.ColumnIndex].Name;

            if (kolona == "colUniverzitet")
            {
                e.Value = razmjena.Univerzitet.Naziv;
            }
            else if (kolona == "colPocetak")
            {
                e.Value = razmjena.PocetakRazmjene;
            }
            else if (kolona == "colKraj")
            {
                e.Value = razmjena.KrajRazmjene;
            }
            else if (kolona == "colECTS")
            {
                e.Value = razmjena.ECTS;
            }
        }
    }
}
