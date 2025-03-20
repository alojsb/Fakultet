using DLWMS.Data;
using DLWMS.Data.IspitBrojIndeksa;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
using DLWMS.WinApp.IspitBrojIndeksa.Izvjestaji;
using DocumentFormat.OpenXml.Wordprocessing;
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
        private Student student = new Student();
        private readonly DLWMSContext db = new DLWMSContext();

        public frmRazmjeneBrojIndeksa(Student student, DLWMSContext db)
        {
            this.student = student;
            this.db = db;
            InitializeComponent();
        }

        private void frmRazmjeneBrojIndeksa_Load(object sender, EventArgs e)
        {
            this.Text = $"Razmjene studenta: ({student.BrojIndeksa} {student.Ime} {student.Prezime})";

            // ucitaj drzave u cmb
            cmbDrzava.UcitajPodatke(db.Drzave.ToList());
            cmbDrzava.SelectedIndex = -1;

            //dgvRazmjene.DataSource = db.Razmjene.ToList();
            UcitajRazmjene();

            // ucitaj donji spisak svih univerziteta
            cmbUniverzitet2.UcitajPodatke(db.Univerziteti.ToList());
            cmbUniverzitet2.SelectedIndex = -1;
        }

        private void UcitajRazmjene()
        {
            dgvRazmjene.AutoGenerateColumns = false;

            var razmjene = db.Razmjene
                .Include(r => r.Univerzitet)
                .ThenInclude(u => u.Drzava)
                .Where(r => r.StudentId == student.Id)
                .Select(r => new
                {
                    r.Id,
                    UniverzitetNaziv = r.Univerzitet.Naziv,
                    DrzavaNaziv = r.Univerzitet.Drzava.Naziv,
                    r.PocetakRazmjene,
                    r.KrajRazmjene,
                    r.ECTS,
                    r.isOkoncana
                })
                .ToList();

            // Ensure column bindings
            colUniverzitet.DataPropertyName = "UniverzitetNaziv";
            colPocetak.DataPropertyName = "PocetakRazmjene";
            colKraj.DataPropertyName = "KrajRazmjene";
            colEcts.DataPropertyName = "ECTS";
            colOkoncana.DataPropertyName = "isOkoncana";

            // Set data source
            dgvRazmjene.DataSource = razmjene;
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDrzava.SelectedValue != null)
            {
                int selectedDrzavaId = (int)cmbDrzava.SelectedValue;

                // Filter universities by selected country
                var univerzitetiList = db.Univerziteti.Where(u => u.DrzavaId == selectedDrzavaId).ToList();

                // Load filtered universities into cmbUniverzitet
                cmbUniverzitet.UcitajPodatke(univerzitetiList);
                cmbUniverzitet.SelectedIndex = -1;
            }
        }

        private void dgvRazmjene_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvRazmjene.Rows[e.RowIndex];
            var razmjena = row.DataBoundItem as Razmjena;

            if (razmjena == null)
                return;

            var colName = dgvRazmjene.Columns[e.ColumnIndex].Name;

            if (colName == "Univerzitet")
            {
                e.Value = $"{razmjena.Univerzitet.Naziv} ({razmjena.Univerzitet.Drzava.Naziv})";
            }
            else if (colName == "Pocetak")
            {
                e.Value = razmjena.PocetakRazmjene.ToString("dd.MM.yyyy. HH:mm");
            }
            else if (colName == "Kraj")
            {
                e.Value = razmjena.KrajRazmjene.ToString("dd.MM.yyyy. HH:mm");
            }
            else if (colName == "ECTS")
            {
                e.Value = razmjena.ECTS;
            }
            else if (colName == "Okoncana")
            {
                e.Value = razmjena.isOkoncana ? "✔" : "✘"; // Show checkmarks instead of `true/false`
            }
        }

        private bool ValidanUnos()
        {
            if (cmbDrzava.SelectedIndex == -1 || cmbUniverzitet.SelectedIndex == -1)
            {
                MessageBox.Show("Molimo odaberite državu i univerzitet.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEcts.Text) || !int.TryParse(txtEcts.Text, out _))
            {
                MessageBox.Show("Molimo unesite ispravan broj ECTS kredita.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidanOpsegDatuma()
        {
            if (dtpPocetak.Value >= dtpKraj.Value)
            {
                MessageBox.Show("Početak razmjene mora biti prije kraja razmjene.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidanDatum()
        {
            var existingRazmjene = db.Razmjene
                .Where(r => r.StudentId == student.Id)
                .ToList();

            foreach (var razmjena in existingRazmjene)
            {
                if ((dtpPocetak.Value < razmjena.KrajRazmjene && dtpKraj.Value > razmjena.PocetakRazmjene) ||
                    (dtpPocetak.Value >= razmjena.PocetakRazmjene && dtpPocetak.Value <= razmjena.KrajRazmjene) ||
                    (dtpKraj.Value >= razmjena.PocetakRazmjene && dtpKraj.Value <= razmjena.KrajRazmjene))
                {
                    MessageBox.Show($"Period razmjene se preklapa s postojećom razmjenom ({razmjena.PocetakRazmjene:dd.MM.yyyy} - {razmjena.KrajRazmjene:dd.MM.yyyy}).",
                                    "Sukob datuma",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!ValidanUnos() || !ValidanOpsegDatuma() || !ValidanDatum())
                return; // Stop execution if any validation fails

            var novaRazmjena = new Razmjena
            {
                StudentId = student.Id,
                UniverzitetId = (int)cmbUniverzitet.SelectedValue,
                PocetakRazmjene = dtpPocetak.Value,
                KrajRazmjene = dtpKraj.Value,
                ECTS = int.Parse(txtEcts.Text),
                isOkoncana = dtpKraj.Value <= DateTime.Now // If end date is in the past, mark as completed
            };

            db.Razmjene.Add(novaRazmjena);
            db.SaveChanges();

            MessageBox.Show("Razmjena je uspješno sačuvana!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UcitajRazmjene(); // Refresh DataGridView
        }

        private void dgvRazmjene_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid row and the "Obriši" button column
            if (e.RowIndex >= 0 && dgvRazmjene.Columns[e.ColumnIndex].Name == "colObrisi")
            {
                var selectedRow = dgvRazmjene.Rows[e.RowIndex];

                // Retrieve Id from DataGridView or DataBoundItem
                int razmjenaId = ((dynamic)selectedRow.DataBoundItem).Id;

                // Fetch the Razmjena record with related data
                var razmjenaToDelete = db.Razmjene
                    .Include(r => r.Univerzitet)
                    .ThenInclude(u => u.Drzava)
                    .FirstOrDefault(r => r.Id == razmjenaId);

                // Generate a confirmation message using student's data and exchange details
                string message = $"Da li ste sigurni da želite obrisati podatke o razmjeni\n" +
                                 $"({student.BrojIndeksa}) {student.Ime} {student.Prezime} na\n" +
                                 $"{razmjenaToDelete.Univerzitet.Naziv} ({razmjenaToDelete.Univerzitet.Drzava.Naziv})?";

                var confirmResult = MessageBox.Show(message, "Upit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                if (confirmResult == DialogResult.Yes)
                {
                    db.Razmjene.Remove(razmjenaToDelete);
                    db.SaveChanges();

                    MessageBox.Show("Razmjena je uspješno obrisana.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UcitajRazmjene(); // Refresh DataGridView
                }
            }
        }

        private void btnPotvrda_Click(object sender, EventArgs e)
        {
            // Fetch the list of Razmjene for the student
            var razmjeneList = db.Razmjene
                .Include(r => r.Univerzitet)
                .ThenInclude(u => u.Drzava)
                .Where(r => r.StudentId == student.Id)
                .ToList();

            var frmIzvjestajLoaded = new frmIzvjestaj(razmjeneList, student);
            frmIzvjestajLoaded.ShowDialog();
        }

        public DateTime GetNextStartDate(int studentId)
        {
            // Retrieve the last razmjena for the student (ordered by end date descending)
            var lastRazmjena = db.Razmjene
                .Where(r => r.StudentId == studentId)
                .OrderByDescending(r => r.KrajRazmjene)
                .FirstOrDefault();

            // If the student has previous razmjene, start from the next day after the last end date.
            if (lastRazmjena != null)
            {
                return lastRazmjena.KrajRazmjene.AddDays(1);
            }

            // If no razmjene exist, start from 1st January 2025.
            return new DateTime(2025, 1, 1);
        }

        //private void btnGenerisiRazmjene_Click(object sender, EventArgs e)
        //{
        //    var brojRazmjena = int.Parse(txtBrojRazmjena.Text);
        //    DateTime startDate = GetNextStartDate(student.Id);
        //    var sb = new StringBuilder(); // To accumulate the new razmjene for txtInfo

        //    for (int i = 0; i < brojRazmjena; i++)
        //    {
        //        var endDate = startDate.AddDays(int.Parse(txtBrojKredita.Text) + (i + 1));

        //        var novaRazmjena = new Razmjena
        //        {
        //            StudentId = student.Id,
        //            UniverzitetId = (int)cmbUniverzitet2.SelectedValue,
        //            PocetakRazmjene = startDate,
        //            KrajRazmjene = endDate,
        //            ECTS = int.Parse(txtBrojKredita.Text),
        //            isOkoncana = endDate <= DateTime.Now // If end date is in the past, mark as completed
        //        };

        //        db.Razmjene.Add(novaRazmjena);
        //        db.SaveChanges();

        //        // The next razmjena should start the day after the current one ends
        //        startDate = endDate.AddDays(1);

        //        // Append to txtInfo instead of overwriting
        //        sb.AppendLine($"{i + 1}. razmjena za ({student.BrojIndeksa}) {student.Ime} {student.Prezime} na {novaRazmjena.Univerzitet.Naziv} ({novaRazmjena.PocetakRazmjene:dd.MM.yyyy} - {novaRazmjena.KrajRazmjene:dd.MM.yyyy})");
        //    }

        //    // Update the text field
        //    txtInfo.Text = sb.ToString();

        //    // Refresh DataGridView to immediately display the new records
        //    UcitajRazmjene();
        //}

        private void btnGenerisiRazmjene_Click(object sender, EventArgs e)
        {
            if (!ValidanUnos2())
            {
                return;
            }

            btnGenerisiRazmjene.Enabled = false; // Disable button to prevent multiple clicks
            int univerzitetId = (int)cmbUniverzitet2.SelectedValue;
            int ects = int.Parse(txtBrojKredita.Text);

            Task.Run(() =>
            {
                var brojRazmjena = int.Parse(txtBrojRazmjena.Text);
                var startDate = new DateTime(2025, 1, 1);
                var sb = new StringBuilder(); // To accumulate the new razmjene for txtInfo

                using (var dbContext = new DLWMSContext()) // Create a new DbContext instance for thread safety
                {
                    var univerzitet = dbContext.Univerziteti
                        .Where(u => u.Id == univerzitetId)
                        .Select(u => u.Naziv)
                        .FirstOrDefault();

                    for (int i = 0; i < brojRazmjena; i++)
                    {
                        var endDate = startDate.AddDays(int.Parse(txtBrojKredita.Text) + (i + 1));
                        var novaRazmjena = new Razmjena
                        {
                            StudentId = student.Id,
                            UniverzitetId = univerzitetId,
                            PocetakRazmjene = startDate,
                            KrajRazmjene = endDate,
                            ECTS = ects,
                            isOkoncana = endDate <= DateTime.Now // If end date is in the past, mark as completed
                        };

                        db.Razmjene.Add(novaRazmjena);
                        db.SaveChanges();

                        // Append details to StringBuilder (no need to Invoke)
                        sb.AppendLine($"{i + 1}. razmjena za ({student.BrojIndeksa}) {student.Ime} {student.Prezime} na {univerzitet} ({novaRazmjena.PocetakRazmjene:dd.MM.yyyy} - {novaRazmjena.KrajRazmjene:dd.MM.yyyy})");

                        Thread.Sleep(300); // Pause execution for 300ms
                    }
                }

                // Refresh DataGridView (must be done on UI thread)
                this.Invoke((MethodInvoker)delegate
                {
                    // Update the text field
                    txtInfo.Text = sb.ToString();

                    // Refresh DataGridView to immediately display the new records
                    UcitajRazmjene();

                    // Re-enable button after completion
                    btnGenerisiRazmjene.Enabled = true;

                    // inform the user of completion
                    MessageBox.Show("Razmjene uspješno dodane", "Info");
                });
            });
        }

        private bool ValidanUnos2()
        {
            if (cmbUniverzitet2.SelectedIndex == -1)
            {
                MessageBox.Show("Molimo odaberite univerzitet.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtBrojRazmjena.Text, out int brojRazmjena) || brojRazmjena <= 0)
            {
                MessageBox.Show("Molimo unesite validan pozitivan cijeli broj za broj razmjena.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtBrojKredita.Text, out int brojKredita) || brojKredita <= 0)
            {
                MessageBox.Show("Molimo unesite validan pozitivan cijeli broj za broj kredita.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

    }
}
