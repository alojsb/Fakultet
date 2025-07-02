using DLWMS.Data.IspitBrojIndeksa;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
using DocumentFormat.OpenXml.Spreadsheet;
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
            dgvStudentiStipendije.AutoGenerateColumns = false;
        }

        private void frmPretragaBrojIndeksa_Load(object sender, EventArgs e)
        {
            cmbStipendija.UcitajPodatke(db.StipendijeBrojIndeksa.ToList());
            cmbStipendija.SelectedIndex = -1;

            FiltrirajStudenteStipendije();
        }

        private void FiltrirajStudenteStipendije()
        {
            var query = db.StudentiStipendijeBrojIndeksa
                //.AsNoTracking()
                .Include(ss => ss.Student)
                .Include(ss => ss.StipendijaGodina)
                .ThenInclude(sg => sg.Stipendija)
                .AsQueryable();

            if (cmbGodina.SelectedItem != null)
            {
                query = query.Where(ss => ss.StipendijaGodina.Godina == int.Parse(cmbGodina.SelectedItem.ToString()!));
            }

            if (cmbStipendija.SelectedValue != null)
            {
                query = query.Where(ss => ss.StipendijaGodina.StipendijaId == (int)cmbStipendija.SelectedValue);
            }

            var studentiStipendije = query.ToList();

            this.Text = $"Broj prikazanih studenata-stipendija: {studentiStipendije.Count()}";

            dgvStudentiStipendije.DataSource = studentiStipendije;

            if (studentiStipendije.Count() == 0)
            {
                MessageBox.Show($"U bazi nisu evidentirani studenti kojima je u {cmbGodina.Text}. godini dodijeljena {cmbStipendija.Text} stipendija.", "Obavijest", MessageBoxButtons.OK);
            }
        }

        private void dgvStudentiStipendije_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var kolona = dgvStudentiStipendije.Columns[e.ColumnIndex].Name;
            var studentStipendija = dgvStudentiStipendije.Rows[e.RowIndex].DataBoundItem as StudentStipendijaBrojIndeksa;

            if (kolona == "ImePrezime")
            {
                e.Value = $"({studentStipendija.Student.BrojIndeksa}) {studentStipendija.Student.Ime} {studentStipendija.Student.Prezime}";
            }
            else if (kolona == "Godina")
            {
                e.Value = studentStipendija.StipendijaGodina.Godina;
            }
            else if (kolona == "Stipendija")
            {
                e.Value = studentStipendija.StipendijaGodina.Stipendija.Naziv;
            }
            else if (kolona == "MjesecniIznos")
            {
                e.Value = studentStipendija.StipendijaGodina.Iznos;
            }
            else if (kolona == "Ukupno")
            {
                e.Value = IzracunUkupno(studentStipendija);
            }
        }

        private int IzracunUkupno(StudentStipendijaBrojIndeksa ss)
        {
            if (ss.StipendijaGodina.Godina == DateTime.Now.Year)
            {
                return ss.StipendijaGodina.Iznos * DateTime.Now.Month;
            }
            else
            {
                return ss.StipendijaGodina.Iznos * 12;
            }
        }

        private void cmbGodina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltrirajStudenteStipendije();
        }

        private void cmbStipendija_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltrirajStudenteStipendije();
        }

        private void dgvStudentiStipendije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudentiStipendije.Columns[e.ColumnIndex].Name == "Ukloni")
            {
                var odgovor = MessageBox.Show("Da li sigurno želite ukloni odabrani zapis o dodijeljenoj stipendiji?", "Upit", MessageBoxButtons.YesNo);

                if (odgovor == DialogResult.Yes)
                {
                    var studentStipendija = dgvStudentiStipendije.Rows[e.RowIndex].DataBoundItem as StudentStipendijaBrojIndeksa;

                    db.StudentiStipendijeBrojIndeksa.Remove(studentStipendija);
                    db.SaveChanges();
                    FiltrirajStudenteStipendije();
                }
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var novaForma = new frmStipendijaAddEditBrojIndeksa();
            if (novaForma.ShowDialog() == DialogResult.OK)
                FiltrirajStudenteStipendije();
        }


        private void dgvStudentiStipendije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // ✅ RE-FETCH the clicked row’s data from DB fresh (so the child can save it correctly)
            var id = (dgvStudentiStipendije.Rows[e.RowIndex].DataBoundItem as StudentStipendijaBrojIndeksa).Id;
            var freshModel = db.StudentiStipendijeBrojIndeksa
                .Include(ss => ss.StipendijaGodina)
                .Include(ss => ss.Student)
                .FirstOrDefault(ss => ss.Id == id);

            var forma = new frmStipendijaAddEditBrojIndeksa(freshModel);

            if (forma.ShowDialog() == DialogResult.OK)
                FiltrirajStudenteStipendije();
        }


    }
}
