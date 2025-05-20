using DLWMS.Data;
using DLWMS.Data.IB220347;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
using DocumentFormat.OpenXml.Math;
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

namespace DLWMS.WinApp.IB220347
{
    public partial class frmRazmjene : Form
    {
        private Student student;
        List<Razmjene> razmjene = new List<Razmjene>();
        DLWMSContext db = new DLWMSContext();

        public frmRazmjene(Student student)
        {
            InitializeComponent();
            this.student = student;
            dgvRazmjene.AutoGenerateColumns = false;
        }

        private void frmRazmjene_Load(object sender, EventArgs e)
        {
            this.Text = $"Razmjene studenta: {student.BrojIndeksa} {student.Ime} {student.Prezime}";
            cmbDrzava.DataSource = db.Drzave.ToList();
            var drz = cmbDrzava.SelectedValue as Drzava;
            cmbUni.DataSource = db.Univerziteti.Where(x => x.Drzava == drz).ToList();
            cmbUNiThread.DataSource = db.Univerziteti.ToList();
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            razmjene = db.Razmjene.Include(x => x.Univerzitet).Where(x => x.StudentId == student.Id).ToList();
            var Tabela = new DataTable();
            Tabela.Columns.Add("Univerzitet");
            Tabela.Columns.Add("Pocetak");
            Tabela.Columns.Add("Kraj");
            Tabela.Columns.Add("ECTS");
            Tabela.Columns.Add("Okoncana");
            for (int i = 0; i < razmjene.Count; i++)
            {
                var razmjena = razmjene[i];
                var Red = Tabela.NewRow();
                Red["Univerzitet"] = razmjena.Univerzitet;
                Red["Pocetak"] = razmjena.PocetakRazmjene.ToShortDateString();
                Red["Kraj"] = razmjena.KrajRazmjene.ToShortDateString();
                Red["ECTS"] = razmjena.BrojECTS;
                Red["Okoncana"] = razmjena.Okoncana;
                Tabela.Rows.Add(Red);
            }
            dgvRazmjene.DataSource = null;
            dgvRazmjene.DataSource = Tabela;
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var drz = cmbDrzava.SelectedValue as Drzava;
            cmbUni.DataSource = db.Univerziteti.Where(x => x.Drzava == drz).ToList();
            UcitajPodatke();
        }

        private void cmbUni_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void btnSpasi_Click(object sender, EventArgs e)
        {
            if (ValidanUnos() && ValidanDatum() && ValidanOpsegDatuma())
            {
                var novo = new Razmjene()
                {
                    StudentId = student.Id,
                    Univerzitet = cmbUni.SelectedValue as Univerziteti,
                    BrojECTS = int.Parse(tbECTS.Text),
                    PocetakRazmjene = dtpPocetak.Value,
                    KrajRazmjene = dtpKraj.Value,
                    Okoncana = dtpKraj.Value > DateTime.Now ? false : true,
                };
                db.Razmjene.Add(novo);
                db.SaveChanges();
                UcitajPodatke();
            }
        }

        private bool ValidanOpsegDatuma()
        {
            if (dtpPocetak.Value < dtpKraj.Value) return true;
            else
            {
                MessageBox.Show("Datum za Pocetak razmjene je veci od datuma kraja razmjene");
                return false;
            }
        }

        private bool ValidanDatum()
        {
            for (int i = 0; i < razmjene.Count; i++)
            {
                var pdatum = razmjene[i].PocetakRazmjene;
                var kdatum = razmjene[i].KrajRazmjene;

                if ((dtpPocetak.Value <= pdatum && dtpKraj.Value > pdatum) || (dtpPocetak.Value >= pdatum && dtpKraj.Value <= kdatum) || (dtpPocetak.Value >= pdatum && dtpPocetak.Value <= kdatum) || (dtpKraj.Value >= pdatum && dtpKraj.Value <= kdatum) || (dtpPocetak.Value >= pdatum && dtpPocetak.Value <= kdatum))
                {
                    MessageBox.Show("Sukob datuma!");
                    return false;
                }
            }
            return true;
        }

        private bool ValidanUnos()
        {
            if (Validator.ProvjeriUnos(cmbDrzava, err, Kljucevi.RequiredField) &&
               Validator.ProvjeriUnos(cmbUni, err, Kljucevi.RequiredField) &&
               Validator.ProvjeriUnos(tbECTS, err, Kljucevi.RequiredField) &&
               Validator.ProvjeriUnos(dtpPocetak, err, Kljucevi.RequiredField) &&
               Validator.ProvjeriUnos(dtpKraj, err, Kljucevi.RequiredField) == true) return true;
            else
            {
                MessageBox.Show("Morate unijeti sve podatke");
                return false;
            }
        }

        private void dgvRazmjene_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                DialogResult drst = MessageBox.Show("Jeste li sigurni da zelite obrisati?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drst == DialogResult.Yes)
                {
                    db.Razmjene.Remove(razmjene[e.RowIndex]);
                    db.SaveChanges();
                    UcitajPodatke();
                }
            }
        }

        private void btnGenerisi_Click(object sender, EventArgs e)
        {
            int broj;
            try
            {
                int.TryParse(tbBrojRazmjena.Text, out broj);
            }
            catch (Exception){
                MessageBox.Show("Morate unijeti broj ponavljanja");
                return;
            }
            Univerziteti uni = cmbUni.SelectedItem as Univerziteti;
            int ects = int.Parse(tbBrojEcts.Text);
            var thr = new Thread(() => GenerisiRazmjene(student,uni,broj,ects));
            thr.Start();
        }

        private async void GenerisiRazmjene(Student student, Univerziteti? uni, int broj, int ects)
        {
            var dtmrazmj = new DateTime(2025, 01, 01);
            var krajdtm = new DateTime(2025, 01, 01);
            krajdtm = krajdtm.AddDays(ects);
            for (int i = 0; i < broj; i++)
            {
               
                var novi = new Razmjene()
                {
                    BrojECTS = ects,
                    StudentId = student.Id,
                    PocetakRazmjene = dtmrazmj,
                    KrajRazmjene = krajdtm,
                    Okoncana = krajdtm>DateTime.Now ? true : false,
                    Univerzitet=uni,
                };
                db.Razmjene.Add(novi);
                db.SaveChanges();
                Action action = () =>
                {
                    tbInfo.Text += $"{i + 1}. razmjena za ({student.BrojIndeksa} {student.Ime} {student.Prezime} na {uni.Naziv} ({dtmrazmj.Date} - {krajdtm.Date}){Environment.NewLine}";
                };
                BeginInvoke(action);
                BeginInvoke(UcitajPodatke);
                Thread.Sleep(300);
                krajdtm = krajdtm.AddDays(1);
            }
        }
    }
}
