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
        DLWMSContext dbContext = new DLWMSContext();
        Student student = new Student();

        public frmRazmjeneBrojIndeksa(Student? student, DLWMSContext db)
        {
            InitializeComponent();
            this.student = student;
            this.dbContext = db;
            dgvRazmjene.AutoGenerateColumns = false;
            dgvRazmjene.CellFormatting += dgvRazmjene_CellFormatting;
        }

        private void frmRazmjeneBrojIndeksa_Load(object sender, EventArgs e)
        {
            this.Text = $"Razmjene studenta: ({student.BrojIndeksa}) {student.Ime} {student.Prezime}";

            cmbDrzava.UcitajPodatke(dbContext.Drzave.ToList());

            if (cmbDrzava.SelectedValue != null)
            {
                var selectedDrzavaId = (int)cmbDrzava.SelectedValue;
                cmbUniverzitet.UcitajPodatke(dbContext.UniverzitetiBrojIndeksa.Where(u => u.DrzavaId == selectedDrzavaId).ToList());
            }

            OsvjeziRazmjene();
        }

        private void OsvjeziRazmjene()
        {
            dgvRazmjene.DataSource = dbContext.RazmjeneBrojIndeksa
                .Include(r => r.Univerzitet)
                .ThenInclude(u => u.Drzava)
                .Where(r => r.StudentId == student.Id)
                .ToList();
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDrzava.SelectedValue != null)
            {
                cmbUniverzitet.UcitajPodatke(dbContext.UniverzitetiBrojIndeksa.Where(u => u.DrzavaId == (int)cmbDrzava.SelectedValue).ToList());
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbDrzava.SelectedValue == null || cmbUniverzitet.SelectedValue == null)
            {
                MessageBox.Show("Potrebno je unijeti validne vrijednosti za državu i univerzitet.", "Obavijest", MessageBoxButtons.OK);
                return;
            }

            if (String.IsNullOrWhiteSpace(txtECTS.Text) || int.Parse(txtECTS.Text) < 0)
            {
                MessageBox.Show("Potrebno je unijeti validne vrijednosti za polje 'Broj kredita'.", "Obavijest", MessageBoxButtons.OK);
                return;
            }

            if (dtpKraj.Value < dtpPocetak.Value)
            {
                MessageBox.Show("Datum završetka ne smije biti manji od datuma početka razmjene.", "Obavijest", MessageBoxButtons.OK);
                return;
            }

            var postojeceRazmjene = dbContext.RazmjeneBrojIndeksa.Where(r => r.StudentId == student.Id).ToList();

            for (int i = 0; i < postojeceRazmjene.Count(); i++)
            {
                if (dtpPocetak.Value <= postojeceRazmjene[i].KrajRazmjene && postojeceRazmjene[i].PocetakRazmjene <= dtpKraj.Value)
                {
                    MessageBox.Show("Student ne može imati dvije razmjene u istom periodu.", "Obavijest", MessageBoxButtons.OK);
                    return;
                }
            }

            if (dtpKraj.Value < dtpPocetak.Value)
            {
                MessageBox.Show("Datum završetka ne smije biti manji od datuma početka razmjene.", "Obavijest", MessageBoxButtons.OK);
                return;
            }

            var novaRazmjena = new RazmjenaBrojIndeksa
            {
                StudentId = student.Id,
                UniverzitetId = (int)cmbUniverzitet.SelectedValue,
                PocetakRazmjene = dtpPocetak.Value,
                KrajRazmjene = dtpKraj.Value,
                ECTS = int.Parse(txtECTS.Text),
                IsOkoncana = dtpKraj.Value < DateTime.Now
            };

            dbContext.RazmjeneBrojIndeksa.Add(novaRazmjena);
            dbContext.SaveChanges();

            OsvjeziRazmjene();
        }

        private void dgvRazmjene_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var kolona = dgvRazmjene.Columns[e.ColumnIndex].Name;
            var razmjena = dgvRazmjene.Rows[e.RowIndex].DataBoundItem as RazmjenaBrojIndeksa;

            if (kolona == "colUniverzitet")
            {
                e.Value = razmjena.Univerzitet.Naziv;
            }
        }

        private void dgvRazmjene_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRazmjene.Columns[e.ColumnIndex].Name == "colObrisi")
            {
                var selectedRazmjena = dgvRazmjene.Rows[e.RowIndex].DataBoundItem as RazmjenaBrojIndeksa;

                var potvrdaBrisanja = MessageBox.Show($"Da li ste sigurno da želite obrisati podatke o razmjeni ({student.BrojIndeksa}) {student.Ime} {student.Prezime} na {selectedRazmjena.Univerzitet.Naziv} ({selectedRazmjena.Univerzitet.Drzava.Naziv})", "Upit", MessageBoxButtons.YesNo);

                if (potvrdaBrisanja == DialogResult.Yes)
                {
                    dbContext.Remove(selectedRazmjena);
                    dbContext.SaveChanges();
                    OsvjeziRazmjene();
                }
            }
        }
    }
}
