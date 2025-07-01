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
        private Student student;
        private DLWMSContext db;

        public frmRazmjeneBrojIndeksa(Student student, DLWMSContext db)
        {
            InitializeComponent();
            this.student = student;
            this.db = db;

            dgvRazmjene.AutoGenerateColumns = false;
        }

        private void frmRazmjeneBrojIndeksa_Load(object sender, EventArgs e)
        {
            cmbDrzava.UcitajPodatke(db.Drzave.ToList());
            cmbDrzava.SelectedValue = -1;

            OsvjeziUniverzitete();
            cmbUniverzitet.SelectedValue = -1;

            OsvjeziRazmjene();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbDrzava.SelectedValue == null || cmbUniverzitet.SelectedValue == null)
            {
                MessageBox.Show("Vrijednosti za polje Država i polje Univerzitet moraju biti unešene.", "Obavijest", MessageBoxButtons.OK);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtECTS.Text) && int.Parse(txtECTS.Text) < 0)
            {
                MessageBox.Show("Vrijednost za polje 'Broj kredita' mora biti validna.", "Obavijest", MessageBoxButtons.OK);
                return;
            }

            if (dtpPocetak.Value >= dtpKraj.Value)
            {
                MessageBox.Show("Datum završetka ne smije biti manji od datuma početka razmjene.", "Obavijest", MessageBoxButtons.OK);
                return;
            }

            var postojeceRazmjene = db.RazmjeneBrojIndeksa.Where(r => r.StudentId == student.Id).ToList();

            foreach (var raz in postojeceRazmjene)
            {
                if (dtpPocetak.Value <= raz.Kraj && raz.Pocetak <= dtpKraj.Value)
                {
                    MessageBox.Show("Student ne može imati dvije razmjene u istom periodu.", "Obavijest", MessageBoxButtons.OK);
                    return;
                }
            }

            var novaRazmjena = new RazmjenaBrojIndeksa
            {
                StudentId = student.Id,
                UniverzitetId = (int)cmbUniverzitet.SelectedValue,
                Pocetak = dtpPocetak.Value,
                Kraj = dtpKraj.Value,
                ECTS = int.Parse(txtECTS.Text),
                IsOkoncana = dtpKraj.Value < DateTime.Now
            };

            db.RazmjeneBrojIndeksa.Add(novaRazmjena);
            db.SaveChanges();

            OsvjeziRazmjene();
        }

        private void OsvjeziRazmjene()
        {
            dgvRazmjene.DataSource = db.RazmjeneBrojIndeksa
                .Include(r => r.Univerzitet)
                .ThenInclude(u => u.Drzava)
                .Where(r => r.StudentId == student.Id)
                .ToList();
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OsvjeziUniverzitete();
        }

        private void OsvjeziUniverzitete()
        {
            if (cmbDrzava.SelectedValue != null)
            {
                cmbUniverzitet.UcitajPodatke(db.UniverzitetiBrojIndeksa.Where(u => u.DrzavaId == (int)cmbDrzava.SelectedValue).ToList());
            }
        }

        private void dgvRazmjene_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var kolona = dgvRazmjene.Columns[e.ColumnIndex].Name;
            var razmjena = dgvRazmjene.Rows[e.RowIndex].DataBoundItem as RazmjenaBrojIndeksa;

            if (kolona == "Univerzitet")
            {
                e.Value = razmjena.Univerzitet.Naziv;
            }
        }

        private void dgvRazmjene_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRazmjene.Columns[e.ColumnIndex].Name == "Obrisi")
            {
                var razmjena = dgvRazmjene.Rows[e.RowIndex].DataBoundItem as RazmjenaBrojIndeksa;

                var upit = MessageBox.Show($"Da li ste sigurni da želite obrisati podatke o razmjeni ({student.BrojIndeksa}) {student.Ime} {student.Prezime} na {razmjena.Univerzitet.Naziv} ({razmjena.Univerzitet.Drzava.Naziv})", "Upit", MessageBoxButtons.YesNo);

                if (upit == DialogResult.Yes)
                {
                    db.RazmjeneBrojIndeksa.Remove(razmjena);
                    db.SaveChanges();

                    OsvjeziRazmjene();                    
                }
            }
        }
    }
}
