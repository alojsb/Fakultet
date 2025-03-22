using DLWMS.Data;
using DLWMS.Data.EntitetiBrojIndeksa;
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
    public partial class frmRazmjeneBrojIndeksa : Form
    {
        Student student = new Student();
        DLWMSContext db = new DLWMSContext();

        public frmRazmjeneBrojIndeksa(Student st, DLWMSContext db)
        {
            this.student = st;
            this.db = db;

            InitializeComponent();
        }

        private void frmRazmjeneBrojIndeksa_Load(object sender, EventArgs e)
        {
            this.Text = $"({student.BrojIndeksa}) {student.Ime} {student.Prezime}";

            cmbDrzava.UcitajPodatke(db.Drzave.ToList());
            cmbDrzava.SelectedValue = -1;

            OsvjeziRazmjene();
        }

        private void OsvjeziRazmjene()
        {
            dgvRazmjene.AutoGenerateColumns = false;
            dgvRazmjene.CellFormatting += dgvRazmjene_CellFormatting;

            var razmjeneList = db.Razmjene
                .Include(r => r.Univerzitet)
                .Where(r => r.StudentId == student.Id).ToList();
            dgvRazmjene.DataSource = razmjeneList;
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDrzava.SelectedValue == null)
            {
                return;
            }

            var selectedDrzavaId = (int)cmbDrzava.SelectedValue;
            var univerziteti = db.Univerziteti.Where(u => u.DrzavaId == selectedDrzavaId).ToList();
            cmbUniverzitet.UcitajPodatke(univerziteti);
        }

        private bool ValidacijaUnosa()
        {
            if (cmbDrzava.SelectedIndex == -1 || cmbUniverzitet.SelectedIndex == -1)
            {
                MessageBox.Show("Molimo odaberite državu i univerzitet.", "Upozorenje");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEcts.Text) || !int.TryParse(txtEcts.Text, out int ects) || ects <= 0)
            {
                MessageBox.Show("Molimo unesite validnu vrijednost za ECTS kredit.", "Upozorenje");
                return false;
            }

            return true;
        }

        private bool ValidnaHronologijaDatuma()
        {
            if (dtpPocetak.Value > dtpKraj.Value)
            {
                MessageBox.Show("Datum kraja razmjene ne može biti ispred datuma početka.", "Upozorenje");
                return false;
            }

            return true;
        }

        private bool ValidanPeriodRazmjene()
        {
            var postojeceRazmjene = db.Razmjene
                .Where(s => s.StudentId == student.Id)
                .ToList();

            foreach (var raz in postojeceRazmjene)
            {
                if (dtpPocetak.Value <= raz.Kraj && dtpKraj.Value >= raz.Pocetak)
                {
                    MessageBox.Show("Period razmjene se poklapa sa periodom postojeće razmjene.", "Upozorenje");
                    return false;
                }
            }

            return true;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaUnosa() || !ValidnaHronologijaDatuma() || !ValidanPeriodRazmjene())
            {
                return;
            }

            var novaRazmjena = new Razmjena
            {
                StudentId = student.Id,
                UniverzitetId = (int)cmbUniverzitet.SelectedValue,
                Pocetak = dtpPocetak.Value,
                Kraj = dtpKraj.Value,
                ECTS = int.Parse(txtEcts.Text),
                IsOkoncana = dtpKraj.Value <= DateTime.Now
            };

            db.Razmjene.Add(novaRazmjena);
            db.SaveChanges();

            OsvjeziRazmjene();
        }

        private void dgvRazmjene_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var razmjena = (Razmjena)dgvRazmjene.Rows[e.RowIndex].DataBoundItem;
            var colName = dgvRazmjene.Columns[e.ColumnIndex].Name;

            if (colName == "colUniverzitet")
            {
                e.Value = razmjena.Univerzitet.Naziv;
            }
            else if (colName == "colPocetak")
            {
                e.Value = razmjena.Pocetak.ToString("dd.MM.yyyy.");
            }
            else if (colName == "colKraj")
            {
                e.Value = razmjena.Kraj.ToString("dd.MM.yyyy.");
            }
            else if (colName == "colEcts")
            {
                e.Value = razmjena.ECTS;
            }
            else if (colName == "colIsOkoncana")
            {
                e.Value = razmjena.IsOkoncana;
            }
        }

        private void dgvRazmjene_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRazmjene.Columns[e.ColumnIndex].Name == "colObrisi")
            {
                var selectedRazmjena = (Razmjena)dgvRazmjene.Rows[e.RowIndex].DataBoundItem;

                var razmjenaToDelete = db.Razmjene
                    .Include(r => r.Univerzitet)
                    .ThenInclude(u => u.Drzava)
                    .FirstOrDefault(r => r.Id == selectedRazmjena.Id);

                var confirmDeletion = MessageBox.Show(
                    $"Da li ste sigurni da želite obrisati podatke o razmjeni ({student.BrojIndeksa}) {student.Ime} {student.Prezime} na {razmjenaToDelete.Univerzitet.Naziv} ({razmjenaToDelete.Univerzitet.Drzava.Naziv})", "Upit", MessageBoxButtons.YesNo);

                if (confirmDeletion == DialogResult.Yes)
                {
                    db.Razmjene.Remove(razmjenaToDelete);
                    db.SaveChanges();

                    OsvjeziRazmjene();
                }
            }
        }
    }
}
